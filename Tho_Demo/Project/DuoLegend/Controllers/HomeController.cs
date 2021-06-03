
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
            if (HttpContext.Session.GetString("email") is null)
            {
                ViewBag.isLogin = false;
            }
            else
            {
                ViewBag.isLogin = true;
            }
            return View(Service.ProcessMainPage.getRandomList());
        }
        
    }
}
