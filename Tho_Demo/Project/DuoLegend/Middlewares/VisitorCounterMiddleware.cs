using System.Threading.Tasks;
using DuoLegend.DAO;
using DuoLegend.Models;
using Microsoft.AspNetCore.Http;

namespace DuoLegend.Middlewares
{
    public class VisitorCounterMiddleware
    {
        private readonly RequestDelegate _next;

        public VisitorCounterMiddleware(RequestDelegate next)
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
            if (httpContext.Request.Cookies["VisitedToday"] == null)
            {
                //Add visitedToday cookie
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = System.DateTime.Now.Date.AddDays(1);
                httpContext.Response.Cookies.Append(SessionKeys.Keys.VisitedToday, "1", cookieOptions);

                //Check if today record exist in database
                if (IsTodayRecordExistHelper())
                {
                    WebsiteStatisticsDAO.IncrementVisitorCount();
                }
                else
                {
                    WebsiteStatisticsDAO.CreateTodayRecord();
                    WebsiteStatisticsDAO.IncrementVisitorCount();
                }
            }
            await _next(httpContext);
        }


        /// <summary>
        /// Helper method to check if there exist a record of today
        /// </summary>
        /// <returns>True if exist, otherwise false</returns>
        private bool IsTodayRecordExistHelper()
        {
            WebsiteStatistics todayStats = WebsiteStatisticsDAO.GetTodayRecord();

            if (todayStats == null)
            {
                return false;
            }
            return true;
        }
    }
}