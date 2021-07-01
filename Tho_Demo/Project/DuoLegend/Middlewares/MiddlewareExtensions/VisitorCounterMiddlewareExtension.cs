using Microsoft.AspNetCore.Builder;

namespace DuoLegend.Middlewares.MiddlewareExtensions
{
    public static class VisitorCounterMiddlewareExtension
    {
        public static IApplicationBuilder UseVisitorCounterMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<VisitorCounterMiddleware>();
        }
    }
}