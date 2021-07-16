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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;

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
                if (UserDAO.isVerified(acc.Email) == 1)
                {
                    if (acc.RememberMe)
                    {
                        CookieOptions newCookie = new CookieOptions();
                        newCookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Append("email", acc.Email, newCookie);
                    }

                    HttpContext.Session.SetString("email", acc.Email);
                    User user = UserDAO.getUserByEmail(acc.Email);
                    HttpContext.Session.SetString("inGameName", user.InGameName);
                    HttpContext.Session.SetString("server", user.Server);
                    HttpContext.Session.SetInt32("id", UserDAO.getIdByInGameNameServer(user.InGameName, user.Server));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.email = acc.Email;
                    return View("VerifyRequest");
                }
            }
            else
            {
                ViewBag.isCorrect = false;
                return View("Login");
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
            if (!RiotAPI.RiotAPI.isRealInGameName(register.InGameName, register.Server))
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
            if (ModelState.IsValid)
            {
                DAO.UserDAO.addUser(user);
                DAO.WebsiteStatisticsDAO.IncrementNewAccCount(); //Increment new account counter

                string activationCode = Guid.NewGuid().ToString();
                SendEmail(user.Email, activationCode, "VerifyAccount");
                DAO.UserDAO.addActivationCode(activationCode, user.Email);
                string msg = "Registration successfully done. Account verification link " +
                " has been sent to your email: " + user.Email;
                ViewBag.Message = msg;
                return RedirectToAction("Login", "Account");
            }
            else return View();

        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (DAO.UserDAO.isDuplicateUser(model.Email))
                {
                    string resetCode = Guid.NewGuid().ToString();
                    SendEmail(model.Email, resetCode, "ResetPassword");
                    DAO.UserDAO.addResetPasswordCode(resetCode, model.Email);
                    return View("ForgotPasswordConfirmation");
                }
                return View("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        public IActionResult ResetPassword(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return RedirectToAction("error", "Home");
            }
            else
            {
                if (DAO.UserDAO.isResetPasswordCodeExist(code))
                {
                    ResetPasswordViewModel model = new ResetPasswordViewModel();
                    model.ResetCode = code;
                    return View(model);
                }
                else
                {
                    return RedirectToAction("error", "Home");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (DAO.UserDAO.isResetPasswordCodeExist(model.ResetCode))
                {
                    DAO.UserDAO.resetPassword(model.ResetCode, model.NewPassword);
                    return View("ResetPasswordConfirmation");
                }
                return RedirectToAction("error", "Home");
            }
            return View(model);
        }

        public IActionResult VerifyAccount(string code)
        {
            if (DAO.UserDAO.isActivationCodeExist(code))
            {
                DAO.UserDAO.verifyAccount(code);
                return View("VerifyConfirmation");
            }
            return RedirectToAction("error", "Home");
        }

        public IActionResult ResendVerification(string email)
        {
            string activationCode = Guid.NewGuid().ToString();
            SendEmail(email, activationCode, "VerifyAccount");
            DAO.UserDAO.addActivationCode(activationCode, email);
            string msg = "Account verification link " +
            " has been sent to your email: " + email;
            ViewBag.Message = msg;
            return View("RegisterSuccess");
        }

        [NonAction]
        public void SendEmail(string emailID, string code, string emailFor)
        {
            var verifyUrl = "/Account/" + emailFor + "/" + code;
            var link = Url.Action(emailFor, "Account", new { code = code }, Request.Scheme);
            // create email message
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Duo Legend", "duolegendstaff@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailID));
            if (emailFor == "VerifyAccount")
            {
                email.Subject = "Please verify your email address in Duo Legend.";
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = "<h1>Almost done," + emailID + "!</h1><br/>" +
                    "We are excited to tell you that your Duo Legend account is" +
                    " successfully created. Please click on the link below to verify your account.<br/>" +
                    "<a href='" + link + "' class='btn btn-primary'>VERIFY EMAIL ADDRESS</a>"
                };
            }
            else if (emailFor == "ResetPassword")
            {
                email.Subject = "Password Reset Instructions For Duo Legend Account";
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = "<h1>Password Reset Instructions</h1><br/>" +
                    "Hello,<br/>Click the link below to reset your password for your Duo Legend account.<br/>" +
                    "<a href='" + link + "' class='btn btn-primary'>RESET PASSWORD</a>"
                };
            }
            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("duolegendstaff@gmail.com", "legend2021");
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        //ham thua, se xoa trong tuong lai
        public IActionResult RedirectRegisterPage()
        {
            return View("Register");
        }
        //ham thua, se xoa trong tuong lai
        public IActionResult RedirectLoginPage()
        {
            return View("Login");
        }

    }
}

