﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ThreatMap.Domain.Identity.Entities;
using ThreatMap.Infrastructure.Identity.Configuration;
using ThreatMap.Persistence;

namespace ThreatMap.API.Extensions;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration _config)
    {
        var authConfig = new AuthConfig();
        _config.GetSection("Authentication").Bind(authConfig);

        services.AddSingleton(authConfig);
        
        
        ////Configure identity
            services.AddIdentity<User, IdentityRole<long>>()
                .AddEntityFrameworkStores<ThreatMapDbContext>()
                .AddDefaultTokenProviders();
            
            //Configure it for production
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 4;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true; 
            });

            //// configure DI for application services
            services.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddCookie(cfg => cfg.SlidingExpiration = true)
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = authConfig.JwtIssuer,
                        ValidAudience = authConfig.JwtIssuer,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfig.JwtKey)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            
            //Configure SecurityStamp object
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                //Configure how ofert securicy stamp should be validated
                options.ValidationInterval = TimeSpan.FromMinutes(30);
                options.OnRefreshingPrincipal = (context) => Task.CompletedTask;
            });
        
        return services;
    }
}