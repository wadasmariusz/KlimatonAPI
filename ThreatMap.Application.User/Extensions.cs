using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ThreatMap.Application.User;

public static class Extensions
{
    public static IServiceCollection AddApplicationUser(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}