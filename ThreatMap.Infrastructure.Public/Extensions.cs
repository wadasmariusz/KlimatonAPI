using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ThreatMap.Infrastructure.Public;

public static class Extensions
{
    public static IServiceCollection AddPublicInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}