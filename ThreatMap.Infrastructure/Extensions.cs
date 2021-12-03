using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ThreatMap.Application.Shared.Common.Identity;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Infrastructure.Common.DateService;
using ThreatMap.Infrastructure.Identity.Services;
using ThreatMap.Infrastructure.Repositories;

namespace ThreatMap.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IDateService, DateService>();
        services.AddScoped<IReportRepository, ReportRepository>();

        return services;
    }
}