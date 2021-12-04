using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ThreatMap.AirlyAPI.Services;

namespace ThreatMap.AirlyAPI
{
    public static class Extensions
    {
        public static IServiceCollection AddAirlyApiPublic(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IAirlyHttpClient, AirlyHttpClient>();
            return services;
        }
    }
}
