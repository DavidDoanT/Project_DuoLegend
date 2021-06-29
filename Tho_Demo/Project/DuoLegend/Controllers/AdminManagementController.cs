using System;
using DuoLegend.DAO.AdminDAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuoLegend.Controllers
{
    public class AdminManagementController : Controller
    {
        [HttpPost]
        public IActionResult Ban(int userId, int daysToBan, string reason = "Not specified")
        {
            DateTime expirationDate = DateTime.Now.Date.AddDays(daysToBan);           
            int? adminId = HttpContext.Session.GetInt32(SessionKeys.Keys.AdminId);  //Get the admin's Id

            if(adminId != null)
            {
                AdminManagementDAO.BanUser(userId, (int)adminId, expirationDate, reason);

                return RedirectToAction("");    //Returns the admin to user's List
            }

            return NotFound();
        }
    }
}