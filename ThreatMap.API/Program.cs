using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Serilog;
using ThreatMap.API.Extensions;
using ThreatMap.API.Filters;
using ThreatMap.Application.Admin;
using ThreatMap.Application.Public;
using ThreatMap.Application.Shared;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.User;
using ThreatMap.Infrastructure;
using ThreatMap.Infrastructure.Common.UserServices;
using ThreatMap.Persistence;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers(opt => opt.Filters.Add(new ApiExceptionFilterAttribute())).AddFluentValidation();
builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    //Custom response from ModelValidation
    opt.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
            .Where(e => e.Value?.Errors.Count > 0)
            .ToDictionary(a => a.Key, a => a.Value?.Errors.Select(b => b.ErrorMessage).ToArray());

        return new BadRequestObjectResult(new
        {
            Title = "One or more validation failures have occurred",
            StatusCode = 400,
            Errors = errors
        });
    };
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
// builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
// builder.Services.AddHttpContextAccessor();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.TryAddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure();

// Pytanie czy dać Application dostęp do tych poniższych i wtedy po prostu użyć jednego wywowałnia AddApplication.
builder.Services.AddApplication();
builder.Services.AddApplicationAdmin();
builder.Services.AddApplicationPublic();
builder.Services.AddApplicationUser();

builder.Services.AddIdentityConfig(builder.Configuration);
builder.Services.AddSwaggerConfig();

builder.WebHost.UseSerilog();


var app = builder.Build();

// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ThreatMap.API v1"));
}

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Application starting up");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unable to run application");
}
finally
{
    Log.CloseAndFlush();
}