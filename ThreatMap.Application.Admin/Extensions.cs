using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ThreatMap.Application.Admin;

public static class Extensions
{
    public static IServiceCollection AddApplicationAdmin(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}