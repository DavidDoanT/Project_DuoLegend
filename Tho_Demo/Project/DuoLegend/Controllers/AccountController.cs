using DuoLegend.DAO;
using DuoLegend.GlobalConfig;
using DuoLegend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Controllers
{

    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginInfor acc)
        {
            if (UserDAO.CheckLogin(acc.email, acc.password))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.isCorrect = false;
                return View("LoginPage");
            }
        
        }



        public IActionResult RedirectLoginPage()
        {
            return View("LoginPage");
        }

    }
}

