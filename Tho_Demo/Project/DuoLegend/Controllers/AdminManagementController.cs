using System;
using System.Collections.Generic;
using DuoLegend.DAO.AdminDAO;
using DuoLegend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuoLegend.Controllers
{
    public class AdminManagementController : Controller
    {

        public IActionResult UserList()
        {
            IEnumerable<User> userList = DAO.UserDAO.getAllUser();
            if (TempData["deleteFailMsg"] != null)
            {
                ViewBag.deleteFail = TempData["deleteFailMsg"];
            }
            return View(userList);
        }

        public IActionResult BanUser(int id)
        {
            ViewBag.userId = id;
            return View();
        }

        /// <summary>
        /// Perform the action of banning a user
        /// </summary>
        /// <param name="userId">User's id to ban</param>
        /// <param name="daysToBan">The number of days to ban</param>
        /// <param name="reason">The reason for banning</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Ban(int userId, int daysToBan, string reason)
        {
            DateTime expirationDate = DateTime.Now.Date.AddDays(daysToBan);
            int? adminId = HttpContext.Session.GetInt32(SessionKeys.Keys.AdminId);  //Get the admin's Id

            if (adminId != null)
            {
                AdminManagementDAO.BanUser(userId, (int)adminId, expirationDate, reason);

                return RedirectToAction("UserList");    //Returns the admin to user's List
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteUser(int UserID)
        {
            int? adminId = HttpContext.Session.GetInt32(SessionKeys.Keys.AdminId);  //Get the admin's Id
            if (adminId != null)
            {
                if (AdminManagementDAO.DeleteUser(UserID))
                {
                    return RedirectToAction("UserList");
                }
                else
                {
                    TempData["deleteFailMsg"] = "There is some error deleting this user. Please try again!";
                    return RedirectToAction("UserList");
                }
            }
            return NotFound();
        }
    }
}