using DuoLegend.DAO;
using DuoLegend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DuoLegend.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string adminPassword)
        {
            bool isLoginAllowed = AdminLoginDAO.Login(email, adminPassword);

            //If email exist and has a corresponding password with inputted password,
            //login succeed and redirect to main page
            if(isLoginAllowed){
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

    }
}
