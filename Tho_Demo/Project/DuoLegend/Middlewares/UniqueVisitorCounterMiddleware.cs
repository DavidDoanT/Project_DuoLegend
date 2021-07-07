using System.Threading.Tasks;
using DuoLegend.DAO;
using DuoLegend.Models;
using Microsoft.AspNetCore.Http;

namespace DuoLegend.Middlewares
{
    public class UniqueVisitorCounterMiddleware
    {
        private readonly RequestDelegate _next;

        public UniqueVisitorCounterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Increment visitor count everytime a visitor visits the website
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Cookies[SessionKeys.Keys.VisitedToday] == null)
            {
                //Add visitedToday cookie
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = System.DateTime.Now.Date.AddDays(1);
                httpContext.Response.Cookies.Append(SessionKeys.Keys.VisitedToday, "1", cookieOptions);

                //Check if url path is of user or admin
                // if(httpContext.Request.Path.StartsWithSegments())
                //Check if today record exist in database
                if (WebsiteStatisticsDAO.IsTodayRecordExist())
                {
                    WebsiteStatisticsDAO.IncrementUniqueVisitorCount();
                }
                else
                {
                    WebsiteStatisticsDAO.CreateTodayRecord();
                    WebsiteStatisticsDAO.IncrementUniqueVisitorCount();
                }
            }
            await _next(httpContext);
        }
    }
}