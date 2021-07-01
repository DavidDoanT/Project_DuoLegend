using System;
using System.Threading.Tasks;
using DuoLegend.DAO;
using Microsoft.AspNetCore.Http;

namespace DuoLegend.Middlewares
{
    public class CheckBannedUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckBannedUserMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string userEmail = context.Session.GetString("email");
            //Check if a user has established a session
            if (userEmail != null)
            {
                DateTime? expirationDate = BanInfoDAO.GetBanExpirationDate(userEmail);

                //If expirationDate exist and is in the future redirects the user to Banned Page
                if (expirationDate != null && DateTime.Compare((DateTime)expirationDate, DateTime.Now) > 0)
                {
                    if (context.Request.Path.Value != "/Home/Banned")
                    {
                        context.Response.Redirect("/Home/Banned");
                    }
                }
            }
            await _next(context);
        }
    }
}