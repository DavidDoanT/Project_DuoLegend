
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
            var infor = UserDAO.getRandomInGameName();
            for (int i = 0; i < infor.InGameName.Length; i++)
            {
                var userInfor = new userInforMainPage();
                if(infor.InGameName[i] is null)
                {
                    break;
                }
                infor.Rank[i] = RiotAPI.RiotAPI.getRankByEncryptedSummonerId(UserDAO.getEncryptedSummonerId(infor.InGameName[i]), "KR"); //hard code server KR
                string[] listMatch = RiotAPI.RiotAPI.getListMatchIDbyPuuId(UserDAO.getPuuId(infor.InGameName[i]), "ASIA");
                for (int j = 0; j < 3; j++)
                {
                    var smallMatchInfor = RiotAPI.RiotAPI.getMatchInfor(listMatch[j],"ASIA", UserDAO.getEncryptedSummonerId(infor.InGameName[i]));
                    userInfor.champID[j] = smallMatchInfor.ChampId;
                }
                infor.ListUserInfor[i] = userInfor;
            }
            return View(infor);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
