using Microsoft.AspNetCore.Builder;

namespace DuoLegend.Middlewares.MiddlewareExtensions
{
    public static class AuthenticationMiddlewareExtension
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}