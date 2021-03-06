using DuoLegend.DAO;
using DuoLegend.Models;
using DuoLegend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Service
{
    public class ProcessMainPage
    {
        public static MainPageViewModel getRandomList()
        {
            var infor = UserDAO.get3InGameNameByServer("KR");
            for (int i = 0; i < infor.InGameName.Length; i++)
            {
                var userInfor = new userInforMainPage();
                int totalGameWin = 0;
                int totalKill = 0;
                int totalDeath = 0;
                int totalAssist = 0;
                if (infor.InGameName[i] is null)
                {
                    break;
                }

                infor.Lane[i] = UserDAO.getLane(infor.InGameName[i], "KR");
                infor.Note[i] = UserDAO.getNote(infor.InGameName[i], "KR");
                infor.HasMic[i] = UserDAO.isHaveMic(infor.InGameName[i], "KR");

                infor.Rank[i] = RiotAPI.RiotAPI.getRankByEncryptedSummonerId(UserDAO.getEncryptedSummonerId(infor.InGameName[i],"KR"), "KR").Rank; //hard code server KR
                string[] listMatch = RiotAPI.RiotAPI.getListMatchIDbyPuuId(UserDAO.getPuuId(infor.InGameName[i], "KR"), "ASIA");
                for (int j = 0; j < listMatch.Length; j++)
                {
                    var smallMatchInfor = RiotAPI.RiotAPI.getMatchInfor(listMatch[j], "ASIA", UserDAO.getEncryptedSummonerId(infor.InGameName[i], "KR"));
                    userInfor.champName[j] = smallMatchInfor.ChampName;
                    if (smallMatchInfor.IsWin)
                    {
                        totalGameWin++;
                    }
                    totalKill += smallMatchInfor.Kill;
                    totalDeath += smallMatchInfor.Death;
                    totalAssist += smallMatchInfor.Assist;
                }
                userInfor.WinRate = Math.Round(((double)totalGameWin / listMatch.Length) * 100, 1);
                userInfor.Kill = Math.Round((double)totalKill / listMatch.Length, 1);
                userInfor.Death = Math.Round((double)totalDeath / listMatch.Length, 1);
                userInfor.Assist = Math.Round((double)totalAssist / listMatch.Length, 1);
                infor.Server[i] = "KR";
                infor.ListUserInfor[i] = userInfor;
            }
            return infor;
        }

        public static string getContinent(string server)
        {
            if(server.Equals("JP1") || server.Equals("KR") || server.Equals("OC1"))
            {
                return "ASIA";
            }
            if (server.Equals("LA1") || server.Equals("LA2") || server.Equals("NA1") || server.Equals("BR1"))
            {
                return "AMERICAS";
            }
            if (server.Equals("EUN1") || server.Equals("EUW2") || server.Equals("NA1") || server.Equals("RU") || server.Equals("TR1"))
            {
                return "EUROPE";
            }
            return null;
        }

        public static MainPageViewModel ProcessResultList(string server, Search searchInfor)
        {
            var infor = Find(searchInfor);
            for (int i = 0; i < infor.InGameName.Length; i++)
            {
                var userInfor = new userInforMainPage();
                int totalGameWin = 0;
                int totalKill = 0;
                int totalDeath = 0;
                int totalAssist = 0;
                if (infor.InGameName[i] is null)
                {
                    break;
                }

                infor.Note[i] = UserDAO.getNote(infor.InGameName[i], server);
                infor.HasMic[i] = UserDAO.isHaveMic(infor.InGameName[i], server);
                infor.Lane[i] = UserDAO.getLane(infor.InGameName[i], server);
                infor.Rank[i] = RiotAPI.RiotAPI.getRankByEncryptedSummonerId(UserDAO.getEncryptedSummonerId(infor.InGameName[i], server), server).Rank; //hard code server KR
                string[] listMatch = RiotAPI.RiotAPI.getListMatchIDbyPuuId(UserDAO.getPuuId(infor.InGameName[i], server), getContinent(server));
                for (int j = 0; j < listMatch.Length; j++)
                {
                    var smallMatchInfor = RiotAPI.RiotAPI.getMatchInfor(listMatch[j], getContinent(server), UserDAO.getEncryptedSummonerId(infor.InGameName[i], server));
                    userInfor.champName[j] = smallMatchInfor.ChampName;
                    if (smallMatchInfor.IsWin)
                    {
                        totalGameWin++;
                    }
                    totalKill += smallMatchInfor.Kill;
                    totalDeath += smallMatchInfor.Death;
                    totalAssist += smallMatchInfor.Assist;
                }
                userInfor.WinRate = Math.Round(((double)totalGameWin / listMatch.Length) * 100, 1);
                userInfor.Kill = Math.Round((double)totalKill / listMatch.Length, 1);
                userInfor.Death = Math.Round((double)totalDeath / listMatch.Length, 1);
                userInfor.Assist = Math.Round((double)totalAssist / listMatch.Length, 1);
                infor.Server[i] = server;
                infor.ListUserInfor[i] = userInfor;
            }
            return infor;
        }

        public static MainPageViewModel Find(Search searchInfor)
        {
            MainPageViewModel result = new MainPageViewModel();
            List<User> ListUser;
            if (searchInfor.Purpose.Equals("win"))
            {
                ListUser = ProfileDAO.getListUserSortByAvgSkillScore();
            }
            else
            {
                ListUser = ProfileDAO.getListUserSortByAvgBehaviorScore();
            }
            int count = 0;
            foreach (var user in ListUser)
            {
                if (user.Rank.Equals(searchInfor.Rank) && user.Lane.Equals(searchInfor.Lane))
                {
                    result.InGameName[count] = user.InGameName;
                    count++;
                }
                if (count >= 3)
                {
                    break;
                }
            }
            return result;
        }
    }
}
