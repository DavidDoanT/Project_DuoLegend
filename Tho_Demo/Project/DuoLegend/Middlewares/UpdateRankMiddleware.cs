using System.Threading.Tasks;
using DuoLegend.DAO;
using Microsoft.AspNetCore.Http;

namespace DuoLegend.Middlewares
{
    public class UpdateRankMiddleware
    {
        private readonly RequestDelegate _next;

        public UpdateRankMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            //Kiểm tra người dùng đã đăng nhập chưa
            int? userId = httpContext.Session.GetInt32("id");
            if (userId != null)
            {
                //Kiểm tra đã 3 ngày trôi qua từ lần cập nhật rank gần nhất chưa
                if (httpContext.Request.Cookies[SessionKeys.Keys.RankUpdated] == null)
                {
                    //Add cookie
                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = System.DateTime.Now.Date.AddDays(1);
                    httpContext.Response.Cookies.Append(SessionKeys.Keys.RankUpdated, "1", cookieOptions);

                    //Update Rank
                    UserDAO.UpdateRank((int) userId);
                }
            }

            await _next(httpContext);
        }
    }
}