
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

namespace DuoLegend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(UserDAO.getRandomInGameName());
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
