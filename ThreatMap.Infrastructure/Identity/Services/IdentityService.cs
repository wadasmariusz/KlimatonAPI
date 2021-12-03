using System.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Shared.Common.DTO.Identity;
using ThreatMap.Application.Shared.Common.Exceptions;
using ThreatMap.Application.Shared.Common.Identity;
using ThreatMap.Domain.Identity.Entities;
using ThreatMap.Domain.Identity.Static;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly ThreatMapDbContext _db;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;

    public IdentityService(ThreatMapDbContext db, UserManager<User> userManager, SignInManager<User> signInManager,
        ITokenService tokenService)
    {
        _db = db;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<AccountDto> GetAsync(long id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString()) ??
                   throw new NotFoundException($"User with provided id: '{id}' could not be found.");

        var roles = await _userManager.GetRolesAsync(user);
        var claims = await _userManager.GetClaimsAsync(user);

        return new AccountDto()
        {
            Id = user.Id,
            Email = user.Email,
            Roles = roles,
            Claims = claims.ToDictionary(a => a.Type, a => a.Value)
        };
    }

    public async Task<JsonWebToken> SignInAsync(SignInDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email) ??
                   throw new NotFoundException($"User with provided email: '{dto.Email}' could not be found.");

        if (user.EmailConfirmed == false && await _userManager.CheckPasswordAsync(user, dto.Password))
            throw new EmailNotConfirmedException();


        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, true);
        if (!result.Succeeded)
            throw new InvalidCredentialsException();

        var roles = await _userManager.GetRolesAsync(user);
        var claims = await _userManager.GetClaimsAsync(user);

        var jwt = _tokenService.GenerateAccessToken(user.Id, roles, claims: claims);
        jwt.Email = dto.Email;

        var refresh = _tokenService.GenerateRefreshToken();
        jwt.RefreshToken = refresh.Token;

        user.RefreshTokens.Add(refresh);
        _tokenService.RemoveOldRefreshTokens(user);

        await _db.SaveChangesAsync();

        return jwt;
    }

    public async Task SignUpAsync(SignUpDto dto)
    {
        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            UserName = dto.Email,
            Email = dto.Email,
        };


        await using var transaction = await _db.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
        var createUserResult = await _userManager.CreateAsync(user, dto.Password);

        if (!createUserResult.Succeeded)
            throw new CreateUserException(createUserResult.Errors);

        var addRoleResult = await _userManager.AddToRoleAsync(user, UserRoles.User);
        if (!addRoleResult.Succeeded)
            throw new AddToRoleException();
        
        var addClaimResult = await _userManager.AddClaimAsync(user, new Claim("email",user.Email));
        if (!addClaimResult.Succeeded)
            throw new AddClaimException();

        await _db.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    public async Task<JsonWebToken> RefreshToken(string token)
    {
        var user = await _db.Users.SingleOrDefaultAsync(a => a.RefreshTokens.Any(b => b.Token == token)) ??
                   throw new InvalidTokenException();
        var currentRefreshToken = user.RefreshTokens.Single(a => a.Token == token);

        if (currentRefreshToken.IsRevoked)
        {
            _tokenService.RevokeDescendantRefreshTokens(currentRefreshToken, user,
                $"Attempted reuse of revoked ancestor token: {token}");
            _db.Update(user);
            await _db.SaveChangesAsync();
        }

        if (!currentRefreshToken.IsActive)
            throw new NotActiveTokenException();

        var newRefreshToken = _tokenService.RotateRefreshToken(currentRefreshToken);
        user.RefreshTokens.Add(newRefreshToken);

        _tokenService.RemoveOldRefreshTokens(user);

        _db.Update(user); // not necessary - check
        await _db.SaveChangesAsync();

        var roles = await _userManager.GetRolesAsync(user);
        var claims = await _userManager.GetClaimsAsync(user);

        var jwt = _tokenService.GenerateAccessToken(user.Id, roles, claims);

        jwt.RefreshToken = newRefreshToken.Token;

        return jwt;
    }

    public async Task RevokeToken(string token)
    {
        var user = await _db.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token)) ??
                   throw new InvalidTokenException();

        var currentRefreshToken = user.RefreshTokens.Single(a => a.Token == token);

        if (!currentRefreshToken.IsActive)
            throw new NotActiveTokenException();

        _tokenService.RevokeRefreshToken(currentRefreshToken, "Revoked without replacement");
        _db.Update(user);
        await _db.SaveChangesAsync();
    }
}