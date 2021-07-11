using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DuoLegend.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //Check if the url is leading to the Admin site
            if(httpContext.Request.Path.ToString().Contains("Admin"))
            {
                if(!httpContext.Request.Path.StartsWithSegments("/Admin/Login"))
                {
                    //Check if a user has authentication required to access admin site
                    if(httpContext.Session.GetInt32(SessionKeys.Keys.AdminId) == null)
                    {
                        httpContext.Response.Redirect("Not Found"); //Redirect to not found page
                    }
                }
            }

            await _next(httpContext);
        }
    }
}