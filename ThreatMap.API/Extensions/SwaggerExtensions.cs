﻿using Microsoft.OpenApi.Models;

namespace ThreatMap.API.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(swagger =>
        {
            //This is to generate the Default UI of Swagger Documentation    
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ThreatMap.API",
                Version = "v1",
                Contact = new OpenApiContact()
                {
                    Name = "ConnectedLife",
                }
            });
            // To Enable authorization using Swagger (JWT)    
            swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description =
                    "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
            });
            swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
        return services;
    }
}