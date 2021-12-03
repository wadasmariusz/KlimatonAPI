using Microsoft.Extensions.DependencyInjection;
using ThreatMap.Application.Shared.Common.Identity;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Infrastructure.Common.DateService;
using ThreatMap.Infrastructure.Identity.Services;

namespace ThreatMap.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IDateService, DateService>();

        return services;
    }
}