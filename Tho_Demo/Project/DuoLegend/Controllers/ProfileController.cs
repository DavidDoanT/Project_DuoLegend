using DuoLegend.DAO;
using DuoLegend.Models;
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
            RankInfor rankInfor = RiotAPI.RiotAPI.getRankByEncryptedSummonerId(DAO.UserDAO.getEncryptedSummonerId(inGameName,server), server);
            infor.Rank = rankInfor.Rank;
            infor.Tier = rankInfor.Tier;
            infor.RankScore = rankInfor.Lp;
            infor.SummonerName = inGameName;
            User userInfor = RiotAPI.RiotAPI.GetAccountIdInfor(inGameName, server); 
            infor.SummonerLevel = userInfor.SummonerLevel;
            infor.ProfileIconId = userInfor.ProfileIconId;
            infor.Win = rankInfor.Win;
            infor.Lose = rankInfor.Lose;
            infor.Server = server;
            return View(infor);
        }
    }
}
