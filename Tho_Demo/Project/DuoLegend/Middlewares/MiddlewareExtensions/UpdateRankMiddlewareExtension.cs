using Microsoft.AspNetCore.Builder;

namespace DuoLegend.Middlewares.MiddlewareExtensions
{
    public static class UpdateRankMiddlewareExtension
    {
        public static IApplicationBuilder UseUpdateRankMiddlware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UpdateRankMiddleware>();
        }
    }
}