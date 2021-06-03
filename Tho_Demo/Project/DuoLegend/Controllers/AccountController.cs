using DuoLegend.DAO;
using DuoLegend.GlobalConfig;
using DuoLegend.Models;
using DuoLegend.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
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
        public IActionResult Login(LoginInfor acc)
        {
            if (UserDAO.CheckLogin(acc.Email, acc.Password))
            {
                if(acc.RememberMe)
                {
                    
                }
                HttpContext.Session.SetString("email", acc.Email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.isCorrect = false;
                return View("LoginPage");
            }
        
        }

        public IActionResult Register(User register)
        {
            if(!RiotAPI.RiotAPI.isRealInGameName(register.InGameName, register.Server))
            {
                ViewBag.isRealInGameName = false;
                return View();
            }
            if (DAO.UserDAO.isDuplicateUser(register.Email))
            {
                ViewBag.isDuplicateUser = true;
                return View();
            }
            var user = RiotAPI.RiotAPI.GetAccountIdInfor(register.InGameName, register.Server);
            user.Email = register.Email;
            user.InGameName = register.InGameName;
            user.Server = register.Server;
            user.Password = register.Password;
            DAO.UserDAO.addUser(user);
            return View("RegisterSuccess");
        }

        public IActionResult RedirectRegisterPage()
        {
            return View("Register");
        }

        public IActionResult RedirectLoginPage()
        {
            return View("LoginPage");
        }

    }
}

