using DuoLegend.DAO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            bool isLoginAllowed = AdminLoginDAO.Login(email, password);

            if (isLoginAllowed)
            {
                return View("AdminMain");   //AdminMain not yet implemented
            }

            return View();
        }
    }
}
