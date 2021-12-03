using Microsoft.Extensions.DependencyInjection;

namespace ThreatMap.Application.User;

public static class Extensions
{
    public static IServiceCollection AddApplicationUser(this IServiceCollection services)
    {
        return services;
    }
}