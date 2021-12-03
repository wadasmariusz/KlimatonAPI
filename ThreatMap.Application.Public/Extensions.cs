using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ThreatMap.Application.Public;

public static class Extensions
{
    public static IServiceCollection AddApplicationPublic(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}