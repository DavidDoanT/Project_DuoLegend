using DuoLegend.DAO;
using DuoLegend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index(string inGameName, string server)
        {
            ProfileViewModel infor = new ProfileViewModel();
            infor = RiotAPI.RiotAPI.gettop3mastery(inGameName, server);
            return View(infor);
        }
    }
}
