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
            //get info from Riot API 
            RankInfor rankInfor = RiotAPI.RiotAPI.getRankByEncryptedSummonerId(DAO.UserDAO.getEncryptedSummonerId(inGameName, server), server);
            infor.Rank = rankInfor.Rank;
            infor.FacebookLink = UserDAO.getFacebookLink(inGameName, server);
            infor.Tier = rankInfor.Tier;
            infor.RankScore = rankInfor.Lp;
            infor.Lane = UserDAO.getLane(inGameName, server);
            infor.SummonerName = inGameName;
            User userInfor = RiotAPI.RiotAPI.GetAccountIdInfor(inGameName, server);
            infor.SummonerLevel = userInfor.SummonerLevel;
            infor.ProfileIconId = userInfor.ProfileIconId;
            infor.Win = rankInfor.Win;
            infor.Lose = rankInfor.Lose;
            infor.Server = server;
            infor.Id = UserDAO.getIdByInGameNameServer(inGameName, server);
            infor.ListRate = ProfileDAO.getAllRating(infor.Id);
            //get match history
            string[] listMatchId = RiotAPI.RiotAPI.getListMatchIDbyPuuId(UserDAO.getPuuId(infor.SummonerName,infor.Server), Service.ProcessMainPage.getContinent(server));
            if (listMatchId.Length == 0) { ViewBag.hasHistory = false; }
                for (int i = 0; i < listMatchId.Length; i++)
                {
                    
                    infor.MatchList[i] = RiotAPI.RiotAPI.getFullMatchInfor(listMatchId[i], Service.ProcessMainPage.getContinent(server), UserDAO.getEncryptedSummonerId(infor.SummonerName, server));
                }
            //Check rating condition
            ViewBag.ratingCondition = false;
            for (int i = 0; i < listMatchId.Length; i++)
            {
                if (RiotAPI.RiotAPI.checkRatingCondition(listMatchId[i], Service.ProcessMainPage.getContinent(server), infor.Id, HttpContext.Session.GetInt32("id")))
                {
                    ViewBag.ratingCondition = true;
                break;
                }
            }
            if (ProfileDAO.checkLiked(HttpContext.Session.GetInt32("id"), infor.Id))
            {
                TempData["delLike"] = false;
            }
            else { TempData["delLike"] = true; }
            return View("Index",infor);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inGameName"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public IActionResult ViewChat(string inGameName, string server)
        {
            ViewBag.viewChat = true;
            return Index(inGameName, server);
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
                return View("Update");
            }
            else
            {
                if (UserDAO.Update(userIn, HttpContext.Session.GetString("email")))
                {
                    return RedirectToAction("Index", "Profile", new {inGameName = userIn.InGameName, server = userIn.Server});
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
            var emailuser = HttpContext.Session.GetString("email");
            if(emailuser is null)
            {
                return RedirectToAction("RedirectLoginPage", "Account");
            }
            var userInfo = UserDAO.getUserByEmail(emailuser);
            return View("Update",userInfo);
        }
        /// <summary>
        /// Rate user
        /// </summary>
        /// <param name="r"></param>
        /// <returns>Redirect to profile</returns>
        [HttpPost]
        public IActionResult RateUser([Bind("RaterId,UserId,SkillScore,BehaviorScore,Comment")] Rating r)
        {
            string[] nameAndServer = UserDAO.getInGameNameServerById(r.UserId);

            if (ProfileDAO.addRating(r))
            {
                return RedirectToAction("Index", new { inGameName =nameAndServer[0], server =nameAndServer[1]});
            }
            else
            {
                ProfileDAO.updateRating(r);
                return RedirectToAction("Index", new { inGameName = nameAndServer[0], server = nameAndServer[1] });
            }  
        }

        public IActionResult LikedList(int likerId)
        {
            List<User> LikedUsers = ProfileDAO.getLikedList(likerId);
            return View(LikedUsers);
        }
    }
}
