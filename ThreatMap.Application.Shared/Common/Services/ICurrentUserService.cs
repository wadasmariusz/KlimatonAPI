using System.Security.Claims;

namespace ThreatMap.Application.Shared.Common.Services;

public interface ICurrentUserService
{
    string Email { get;  }
    string UserId { get;  }
    public ClaimsPrincipal User { get; }
}