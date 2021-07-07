using Microsoft.AspNetCore.Builder;

namespace DuoLegend.Middlewares.MiddlewareExtensions
{
    public static class UniqueVisitorCounterMiddlewareExtension
    {
        public static IApplicationBuilder UseUniqueVisitorCounterMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UniqueVisitorCounterMiddleware>();
        }
    }
}   