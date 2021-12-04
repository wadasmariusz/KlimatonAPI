using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ThreatMap.Admin;
using ThreatMap.Admin.Extensions;
using ThreatMap.Admin.RazorView;
using ThreatMap.Application.Shared;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Domain.Identity.Entities;
using ThreatMap.Infrastructure;
using ThreatMap.Infrastructure.Common.UserServices;
using ThreatMap.Infrastructure.Identity.Configuration;
using ThreatMap.Persistence;

var builder = WebApplication.CreateBuilder(args);
var factory = LoggerFactory.Create(opt => { opt.AddConsole(); });

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;

    // this piece of code imposes authorization on all controllers
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
    // this piece of code imposes authorization on all controllers - end
});
// Add CORS policy
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
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});
// Add your configs object here
builder.Services.AddOptions();
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    //options.Cookie.Expiration = TimeSpan.FromSeconds(5); //Old code
    options.LoginPath =
        "/account/login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
    options.LogoutPath =
        "/account/logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
    options.AccessDeniedPath =
        "/account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(10);
    // options.EventsType = typeof(CustomCookieAuthenticationEvents);
});

//Configure SecurityStamp object
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    //Configure how ofert securicy stamp should be validated
    options.ValidationInterval = TimeSpan.FromMinutes(30);
    options.OnRefreshingPrincipal = (context) => Task.CompletedTask;
});

builder.Services.AddAuthentication().AddCookie(cfg =>
{
    cfg.SlidingExpiration = true;
    //cfg.ExpireTimeSpan = TimeSpan.FromDays(7);
});
//LowerCaseURLs
builder.Services.AddRouting(options => { options.LowercaseUrls = true; });

//Add application session
builder.Services.AddSession(options =>
{
    // Set session timeout
    options.IdleTimeout = TimeSpan.FromDays(1);
});
builder.Services.AddHttpClient();

var ownBuilder = builder.Services.AddControllersWithViews()
    .AddMvcLocalization(o => o.ResourcesPath = "Resources")
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddFluentValidation()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );
if (builder.Environment.IsDevelopment())
{
    ownBuilder.AddRazorRuntimeCompilation();
}

var authConfig = new AuthConfig();
builder.Configuration.GetSection("Authentication").Bind(authConfig);

builder.Services.AddSingleton(authConfig);
        

builder.Services.TryAddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddIdentityServices();

builder.Services.TryAddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddScoped<IRazorViewRenderer, RazorViewRenderer>();




var app = builder.Build();


if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseWebExceptionHandler();

app.UseRequestLocalization();

app.UseForwardedHeaders(new ForwardedHeadersOptions()
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto | ForwardedHeaders.All
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action}/{id?}",
        new { controller = "Home", action = "Index" });
});

app.Run();