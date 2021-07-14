using Microsoft.AspNetCore.Builder;

namespace DuoLegend.Middlewares.MiddlewareExtensions
{
    public static class CheckDeletedUserMiddlewareExtension
    {
        public static IApplicationBuilder UseCheckDeletedUserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckDeletedUserMiddleware>();
        }
    }
}