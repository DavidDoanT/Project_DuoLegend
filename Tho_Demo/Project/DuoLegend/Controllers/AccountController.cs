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
        /// <summary>
        /// redirect to login view
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// check login
        /// </summary>
        /// <param name="acc"> email and password for check login </param>
        /// <returns>if login sucess redirect to homepage, if not redirect to loginPage but with viewBag isCorrect=false</returns>
        [HttpPost]
        public IActionResult Login(LoginInfor acc)
        {
            if (UserDAO.CheckLogin(acc.Email, acc.Password))
            {
                if(acc.RememberMe)
                {
                    CookieOptions newCookie = new CookieOptions();
                    newCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Append("email", acc.Email, newCookie);
                }
                
                HttpContext.Session.SetString("email", acc.Email);
                User user = UserDAO.getUserByEmail(acc.Email);
                HttpContext.Session.SetString("inGameName", user.InGameName);
                HttpContext.Session.SetString("server", user.Server);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.isCorrect = false;
                return View("LoginPage");
            }   
        }
        /// <summary>
        /// clear all session available
        /// </summary>
        /// <returns> redirect to homePage </returns>
        public IActionResult Logout()
        {
            Response.Cookies.Delete("email");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// receive register information, call DAO for insert to database
        /// </summary>
        /// <param name="register">register information</param>
        /// <returns></returns>
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

        //ham thua, se xoa trong tuong lai
        public IActionResult RedirectRegisterPage()
        {
            return View("Register");
        }
        //ham thua, se xoa trong tuong lai
        public IActionResult RedirectLoginPage()
        {
            return View("LoginPage");
        }

    }
}

