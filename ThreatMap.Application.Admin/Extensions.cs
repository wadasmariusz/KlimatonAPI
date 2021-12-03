using Microsoft.Extensions.DependencyInjection;

namespace ThreatMap.Application.Admin;

public static class Extensions
{
    public static IServiceCollection AddApplicationAdmin(this IServiceCollection services)
    {
        return services;
    }
}