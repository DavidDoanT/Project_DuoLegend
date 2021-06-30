using Microsoft.AspNetCore.Builder;

namespace DuoLegend.Middlewares.MiddlewareExtensions
{
    public static class CheckBannedUserMiddlewareExtension
    {
        public static IApplicationBuilder UseCheckBannedUserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckBannedUserMiddleware>();
        }
    }
}