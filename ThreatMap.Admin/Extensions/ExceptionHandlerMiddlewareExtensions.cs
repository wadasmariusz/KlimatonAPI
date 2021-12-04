using ThreatMap.Admin.Middlewares;

namespace ThreatMap.Admin.Extensions
{
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseWebExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WebExceptionMiddleware>();
        }
    }
}
