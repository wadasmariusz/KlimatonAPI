using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ThreatMap.Application.Shared.Common.Services;

namespace ThreatMap.Infrastructure.Common.UserServices;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    public string Email => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);

    public ClaimsPrincipal User => _httpContextAccessor?.HttpContext?.User;

}