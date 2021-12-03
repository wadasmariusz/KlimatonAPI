using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThreatMap.API.Attributes;
using ThreatMap.Application.Shared.Common.DTO.Identity;
using ThreatMap.Application.Shared.Common.Identity;
using ThreatMap.Domain.Identity.Entities;
using ThreatMap.Domain.Identity.Static;

namespace ThreatMap.API.Areas.Public.Controllers;

[Route("account")]
[ApiAuthorize(Roles = UserRoles.User)]
public class AccountController : BaseController
{
    private readonly IIdentityService _identityService;
    private readonly RoleManager<IdentityRole<long>> _roleManager;
    private readonly UserManager<User> _userManager;

    public AccountController(IIdentityService identityService, RoleManager<IdentityRole<long>> roleManager,
        UserManager<User> userManager)
    {
        _identityService = identityService;
        _roleManager = roleManager;
        _userManager = userManager;
    }


    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<ActionResult<JsonWebToken>> SignIn([FromBody] SignInDto dto)
    {
        var jwt = await _identityService.SignInAsync(dto);
        SetTokenCookie(jwt.RefreshToken);
        return Ok(jwt);
    }


    [HttpPost("sign-up")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUpAsync([FromBody] SignUpDto dto)
    {
        await _identityService.SignUpAsync(dto);
        return NoContent();
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<AccountDto>> GetAccountDetails(long id)
    {
        var account = await _identityService.GetAsync(id);
        return Ok(account);
    }

    [AllowAnonymous]
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
        var token = Request.Cookies["refreshToken"];
        var response = await _identityService.RefreshToken(token);
        SetTokenCookie(response.RefreshToken);

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("revoke-token")]
    public async Task<IActionResult> RevokeToken(RevokeTokenDto dto)
    {
        var token = dto.Token ?? Request.Cookies["refreshToken"]; // możliwe wyrzucenie błędu

        if (string.IsNullOrEmpty(token))
            return BadRequest(new { message = "Token is required" }); // można to ładniej ogarnąć

        await _identityService.RevokeToken(token);
        return Ok();
    }

    private void SetTokenCookie(string token)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7)
        };
        Response.Cookies.Append("refreshToken", token, cookieOptions);
    }


    [HttpGet("create-roles")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAdmin()
    {
        List<string> roles = new List<string>()
        {
            UserRoles.Admin,
            UserRoles.User,
        };

        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                var newRole = new IdentityRole<long>(role);
                var res = await _roleManager
                    .CreateAsync(
                        newRole);

                if (!res.Succeeded)
                {
                    return BadRequest("Problem with creating roles");
                }
            }
        }

        var admin = new User()
        {
            UserName = "admin@threatmap.com",
            Email = "admin@threatmap.com",
            EmailConfirmed = true
        };

        IdentityResult result;

        if (!await _userManager.Users.AnyAsync(a => a.Email == admin.Email))
        {
            result = await _userManager.CreateAsync(admin, "!23Haslo");
        }
        else
        {
            return BadRequest("This user already exists");
        }

        if (result.Succeeded)
        {
            result = await _userManager.AddToRoleAsync(admin, UserRoles.Admin);
            result = await _userManager.AddToRoleAsync(admin, UserRoles.User);
        }
        else
        {
            return BadRequest("There is a problem with adding roles to user");
        }

        return Ok("User was successfully created");
    }
}