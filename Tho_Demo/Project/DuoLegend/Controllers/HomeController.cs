
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DuoLegend.ViewModels;
using DuoLegend.GlobalConfig;
using DuoLegend.DAO;
using DuoLegend.RiotAPI;
using DuoLegend.Models;
using Microsoft.AspNetCore.Http;

namespace DuoLegend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// redirect to loginPage with approriate viewBag
        /// </summary>
        /// <returns>redirect to mainPage with randomList information</returns>
        public IActionResult Index()
        {
            RiotAPI.RiotAPI.setChampionInfor(); // bo cmt dong nay 
            RiotAPI.RiotAPI.setItemInfo();
            RiotAPI.RiotAPI.setSpellInfo();
            RiotAPI.RiotAPI.setRuneInfo();
            //check session
            if (HttpContext.Session.GetString("email") is null)
            {
                ViewBag.isLogin = false;
            }
            else
            {
                ViewBag.isLogin = true;
            }

            //check cookie
            if (Request.Cookies["email"] != null)
            {
                HttpContext.Session.SetString("email", Request.Cookies["email"]);
                User user = UserDAO.getUserByEmail(Request.Cookies["email"]);
                HttpContext.Session.SetString("inGameName", user.InGameName);
                HttpContext.Session.SetString("server", user.Server);
                HttpContext.Session.SetInt32("id", UserDAO.getIdByInGameNameServer(user.InGameName, user.Server));
                ViewBag.isLogin = true;
            }

            return View(Service.ProcessMainPage.getRandomList());
        }

        /// <summary>
        /// call search service and return information
        /// </summary>
        /// <param name="searchInfor"> information for search (rank, skil...) </param>
        /// <returns>view with approriate data</returns>
        [HttpPost]
        public IActionResult Search(MainPageViewModel searchInfor)
        {
            if (HttpContext.Session.GetString("email") is null)
            {
                ViewBag.isLogin = false;
            }
            else
            {
                ViewBag.isLogin = true;
            }
            return View("Index", Service.ProcessMainPage.Search(searchInfor.search.Server));
        }

        /// <summary>
        /// BANISH THE UNWORTHY TO BRAZIL
        /// </summary>
        /// <returns></returns>
        public IActionResult Banned()
        {
            string userEmail = HttpContext.Session.GetString("email");
            DateTime expirationDate = (DateTime)BanInfoDAO.GetBanExpirationDate(userEmail);

            string expirationDateString = expirationDate.ToString("dd/MM/yyyy");
            ViewBag.expirationDate = expirationDateString;

            return View();
        }
    }
}
