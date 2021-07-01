using System;
using DuoLegend.DAO.AdminDAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuoLegend.Controllers
{
    public class AdminManagementController : Controller
    {
        /// <summary>
        /// Perform the action of banning a user
        /// </summary>
        /// <param name="userId">User's id to ban</param>
        /// <param name="daysToBan">The number of days to ban</param>
        /// <param name="reason">The reason for banning</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Ban(int userId, int daysToBan, string reason = "Not specified")
        {
            DateTime expirationDate = DateTime.Now.Date.AddDays(daysToBan);           
            int? adminId = HttpContext.Session.GetInt32(SessionKeys.Keys.AdminId);  //Get the admin's Id

            if(adminId != null)
            {
                AdminManagementDAO.BanUser(userId, (int)adminId, expirationDate, reason);

                return RedirectToAction("UserList", "Admin");    //Returns the admin to user's List
            }

            return NotFound();
        }
    }
}