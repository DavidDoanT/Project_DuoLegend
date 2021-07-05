using DuoLegend.DAO;
using DuoLegend.Models;
using DuoLegend.DAO.AdminDAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuoLegend.Controllers
{
    public class AdminController : Controller
    {
        /// <summary>
        /// Go to Login view
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Log the admin in through email and password
        /// If email and password is valid, set the session for the admin and redirect them to the admin's main page
        /// If not, return to login page with error message.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="adminPassword"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(string email, string adminPassword)
        {
            bool isLoginAllowed = AdminLoginDAO.Login(email, adminPassword);

            //If email exist and has a corresponding password with inputted password,
            //login succeed and redirect to main page
            if (isLoginAllowed)
            {
                HttpContext.Session.SetInt32(SessionKeys.Keys.AdminId, AdminInfoDAO.GetAdminId(email));
                return View("Main");
            }

            ViewBag.loginFailed = true;

            return View();
        }

        public IActionResult UserList()
        {
            IEnumerable<User> userList = DAO.UserDAO.getAllUser();
            return View(userList);
        }

        public IActionResult BanUser()
        {
            return View();
        }

        /// <summary>
        /// Log the admin out
        /// Clears all session
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
