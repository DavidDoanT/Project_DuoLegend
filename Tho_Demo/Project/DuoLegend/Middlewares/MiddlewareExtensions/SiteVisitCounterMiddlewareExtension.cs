using Microsoft.AspNetCore.Builder;

namespace DuoLegend.Middlewares.MiddlewareExtensions
{
    public static class SiteVisitCounterMiddlewareExtension
    {
        public static IApplicationBuilder UseSiteVisitCounterMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SiteVisitCounterMiddleware>();
        }
    }
}