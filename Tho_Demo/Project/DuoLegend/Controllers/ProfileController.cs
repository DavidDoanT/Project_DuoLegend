using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index(string InGameName, string Server)
        {
            ViewBag.inGameName = InGameName;
            ViewBag.server = Server;
            return View();
        }
    }
}
