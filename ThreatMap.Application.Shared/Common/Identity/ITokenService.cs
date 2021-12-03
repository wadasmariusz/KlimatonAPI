using System.Security.Claims;
using ThreatMap.Application.Shared.Common.DTO.Identity;
using ThreatMap.Domain.Identity.Entities;

namespace ThreatMap.Application.Shared.Common.Identity;
public interface ITokenService
{
    JsonWebToken GenerateAccessToken(long userId, ICollection<string> roles = null,
        ICollection<Claim> claims = null);

    RefreshToken GenerateRefreshToken();
    void RemoveOldRefreshTokens(User user);
    void RevokeDescendantRefreshTokens(RefreshToken refreshToken, User user, string reason);
    void RevokeRefreshToken(RefreshToken token, string reason = null, string replacedByToken = null);
    RefreshToken RotateRefreshToken(RefreshToken refreshToken);
}