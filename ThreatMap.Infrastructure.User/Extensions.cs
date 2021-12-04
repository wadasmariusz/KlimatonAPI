using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ThreatMap.Infrastructure.User;

public static class Extensions
{
    public static IServiceCollection AddUserInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}