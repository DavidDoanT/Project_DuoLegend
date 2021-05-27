
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
                int totalGameWin = 0;
                int totalKill = 0;
                int totalDeath = 0;
                int totalAssist = 0;
                if(infor.InGameName[i] is null)
                {
                    break;
                }
                infor.Rank[i] = RiotAPI.RiotAPI.getRankByEncryptedSummonerId(UserDAO.getEncryptedSummonerId(infor.InGameName[i]), "KR"); //hard code server KR
                string[] listMatch = RiotAPI.RiotAPI.getListMatchIDbyPuuId(UserDAO.getPuuId(infor.InGameName[i]), "ASIA");
                for (int j = 0; j < listMatch.Length; j++)
                {
                    var smallMatchInfor = RiotAPI.RiotAPI.getMatchInfor(listMatch[j],"ASIA", UserDAO.getEncryptedSummonerId(infor.InGameName[i]));
                    userInfor.champID[j] = smallMatchInfor.ChampId;
                    if(smallMatchInfor.IsWin)
                    {
                        totalGameWin++;
                    }
                    totalKill += smallMatchInfor.Kill;
                    totalDeath += smallMatchInfor.Death;
                    totalAssist += smallMatchInfor.Assist;                  
                }
                userInfor.WinRate = Math.Round(((double)totalGameWin / listMatch.Length) * 100,1);
                userInfor.Kill = Math.Round((double)totalKill / listMatch.Length,1);
                userInfor.Death = Math.Round((double)totalDeath / listMatch.Length,1);
                userInfor.Assist = Math.Round((double)totalAssist / listMatch.Length,1);
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
