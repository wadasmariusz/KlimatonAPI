using ThreatMap.Application.Shared.Common.DTO.Identity;

namespace ThreatMap.Application.Shared.Common.Identity;

public interface IIdentityService
{
    Task<AccountDto> GetAsync(long id);
    Task<JsonWebToken> SignInAsync(SignInDto dto);
    Task SignUpAsync(SignUpDto dto);
    Task<JsonWebToken> RefreshToken(string token);
    Task RevokeToken(string token);
}