using System.Threading.Tasks;
using DuoLegend.DAO;
using Microsoft.AspNetCore.Http;

namespace DuoLegend.Middlewares
{
    public class SiteVisitCounterMiddleware
    {
        private readonly RequestDelegate _next;

        public SiteVisitCounterMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if(httpContext.Session.GetInt32(SessionKeys.Keys.VisitingSession) == null)
            {
                httpContext.Session.SetInt32(SessionKeys.Keys.VisitingSession, 1);

                //If today record exists, increment siteVisit
                //Else create new record, then increment siteVisit
                if(WebsiteStatisticsDAO.IsTodayRecordExist())
                {
                    WebsiteStatisticsDAO.IncrementSiteVisit();
                }
                else
                {
                    WebsiteStatisticsDAO.CreateTodayRecord();
                    WebsiteStatisticsDAO.IncrementSiteVisit();
                }
            }
            await _next(httpContext);
        }
    }
}