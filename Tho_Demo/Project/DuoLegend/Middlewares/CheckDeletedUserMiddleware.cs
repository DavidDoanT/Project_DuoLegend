using System;
using System.Threading.Tasks;
using DuoLegend.DAO;
using Microsoft.AspNetCore.Http;

namespace DuoLegend.Middlewares
{
    public class CheckDeletedUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckDeletedUserMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string userEmail = context.Session.GetString("email");
            if (userEmail != null)
            {
                if (DAO.UserDAO.isDeleted(userEmail) == 1)
                {
                    if (context.Request.Path.Value != "/Home/Deleted")
                    {
                        context.Response.Redirect("/Home/Deleted");
                    }
                }
            }

            await _next(context);
        }
    }
}