using DuoLegend.DAO;
using DuoLegend.Models;
using DuoLegend.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DuoLegend.Controllers
{
    public class ProfileController : Controller
    {
        /// <summary>
        /// return index with approriate data
        /// </summary>
        /// <param name="inGameName"> real ingame name of user</param>
        /// <param name="server">server in game which user are using</param>
        /// <returns></returns>
        public IActionResult Index(string inGameName, string server)
        {
            ProfileViewModel infor = new ProfileViewModel();
            infor = RiotAPI.RiotAPI.gettop3mastery(inGameName, server);
            RankInfor rankInfor = RiotAPI.RiotAPI.getRankByEncryptedSummonerId(DAO.UserDAO.getEncryptedSummonerId(inGameName, server), server);
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

        /// <summary>
        /// update user information, allow user to update their note and mic status
        /// </summary>
        /// <param name="userIn">object userIn which have inGameName and Server</param>
        /// <returns></returns>
        public IActionResult UpdateUser(User userIn)
        {
            //check if the new in game name is valid
            if (!RiotAPI.RiotAPI.isRealInGameName(userIn.InGameName, userIn.Server))
            {
                ViewBag.isRealInGameNameUpdate = false;
                return View();
            }
            else
            {
                if (UserDAO.Update(userIn, HttpContext.Session.GetString("email")))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.isCorrect = false;
                    return View("Update");
                }
            }
        }

        /// <summary>
        /// redirect to view update
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UpdateUser()
        {
            return View("Update");
        }
    }
}
