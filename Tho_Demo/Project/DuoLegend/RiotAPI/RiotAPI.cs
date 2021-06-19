using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Newtonsoft.Json;
using DuoLegend.Models;
using DuoLegend.DAO;
using DuoLegend.ViewModels;

namespace DuoLegend.RiotAPI
{
    static public class RiotAPI
    {
        private static string RiotKey = GlobalConfig.MyConfig.RiotKey;
        
        public static RankInfor getRankByEncryptedSummonerId(string id, string server)
        {
            WebRequest request = WebRequest.Create("https://"+server+".api.riotgames.com/lol/league/v4/entries/by-summoner/"+id+"?api_key="+RiotKey);
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);

            dynamic resultFromRiot = JsonConvert.DeserializeObject(responseFromServer);
            RankInfor rankInfor = new RankInfor();
           
            try {
                rankInfor.Rank = resultFromRiot[0].tier;
                rankInfor.Tier = resultFromRiot[0].rank;
                rankInfor.Lp = resultFromRiot[0].leaguePoints;
                rankInfor.Win = resultFromRiot[0].wins;
                rankInfor.Lose = resultFromRiot[0].losses;
            }
            catch(Exception e)
            {
                rankInfor.Rank = "unranked";
                rankInfor.Tier = "unranked";
                rankInfor.Lp = 0;
                rankInfor.Win = 0;
                rankInfor.Lose = 0;
            }
            
            reader.Close();
            dataStream.Close();
            response.Close();

            return rankInfor;

        }
        //public static string getRankTierByEncryptedSummonerId(string id, string server)
        //{
        //    WebRequest request = WebRequest.Create("https://" + server + ".api.riotgames.com/lol/league/v4/entries/by-summoner/" + id + "?api_key=" + RiotKey);

        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    Stream dataStream = response.GetResponseStream();
        //    StreamReader reader = new StreamReader(dataStream);
        //    string responseFromServer = reader.ReadToEnd();
        //    // Display the content.
        //    Console.WriteLine(responseFromServer);

        //    dynamic resultFromRiot = JsonConvert.DeserializeObject(responseFromServer);
        //    string tier;
        //    try
        //    {
        //        tier = resultFromRiot[0].rank;
        //    }
        //    catch (Exception e)
        //    {
        //        tier = "unranked";
        //    }

        //    reader.Close();
        //    dataStream.Close();
        //    response.Close();

        //    return tier;

        //}

        //public static int getLeaguePointByEncryptedSummonerId(string id, string server)
        //{
        //    WebRequest request = WebRequest.Create("https://" + server + ".api.riotgames.com/lol/league/v4/entries/by-summoner/" + id + "?api_key=" + RiotKey);

        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    Stream dataStream = response.GetResponseStream();
        //    StreamReader reader = new StreamReader(dataStream);
        //    string responseFromServer = reader.ReadToEnd();
        //    // Display the content.
        //    Console.WriteLine(responseFromServer);

        //    dynamic resultFromRiot = JsonConvert.DeserializeObject(responseFromServer);
        //    int tier = 0;
        //    try
        //    {
        //        tier = resultFromRiot[0].leaguePoints;
        //    }
        //    catch (Exception e)
        //    {
                
        //    }

        //    reader.Close();
        //    dataStream.Close();
        //    response.Close();

        //    return tier;

        //}

        public static string[] getListMatchIDbyPuuId(string id, string server)
        {
            WebRequest request = WebRequest.Create("https://"+server+".api.riotgames.com/lol/match/v5/matches/by-puuid/"+id+"/ids?start=0&count=3&api_key="+RiotKey);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            
            dynamic resultFromRiot = JsonConvert.DeserializeObject(responseFromServer);
            string[] matchList = new string[3];

            for (int i = 0; i < 3; i++)
            {
                matchList[i] = resultFromRiot[i];
            }

            reader.Close();
            dataStream.Close();
            response.Close();
            return matchList;
        }

        public static MatchInfor getMatchInfor(string id, string server, string summonerID)
        {
            WebRequest request = WebRequest.Create("https://"+server+".api.riotgames.com/lol/match/v5/matches/"+id+"?api_key="+RiotKey);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            dynamic resultFromRiot = JsonConvert.DeserializeObject(responseFromServer);

            MatchInfor infor = new MatchInfor();
            int flag=0; //luu lai nguoi dung muon lay infor o index so may, vi tra ve infor cua ca 10 nguoi choi 1 luc
            for(int i=0; i<10; i++)
            {
                if (summonerID.Equals((string)resultFromRiot.info.participants[i].summonerId))
                {
                    flag = i;
                    break;
                }
            }
            //gan tung so lieu cua tran dau vao player cua profile (1 player)
            infor.Kill = resultFromRiot.info.participants[flag].kills;
            infor.Death = resultFromRiot.info.participants[flag].deaths;
            infor.Assist = resultFromRiot.info.participants[flag].assists;
            infor.IsWin = resultFromRiot.info.participants[flag].win;
            infor.ChampName = resultFromRiot.info.participants[flag].championName;
            infor.ChampId = resultFromRiot.info.participants[flag].championId;
            infor.MatchMode = resultFromRiot.info.gameMode;
            infor.Gold = resultFromRiot.info.participants[flag].goldEarned;
            infor.MinionsKill = resultFromRiot.info.participants[flag].totalMinionsKilled;
            infor.Spell1Id = resultFromRiot.info.participants[flag].summoner1Id;
            infor.Spell2Id = resultFromRiot.info.participants[flag].summoner2Id;
            infor.ChampLevel = resultFromRiot.info.participants[flag].champLevel;

            infor.ItemId[0] = resultFromRiot.info.participants[flag].item0;
            infor.ItemId[1] = resultFromRiot.info.participants[flag].item1;
            infor.ItemId[2] = resultFromRiot.info.participants[flag].item2;
            infor.ItemId[3] = resultFromRiot.info.participants[flag].item3;
            infor.ItemId[4] = resultFromRiot.info.participants[flag].item4;
            infor.ItemId[5] = resultFromRiot.info.participants[flag].item5;
            infor.ItemId[6] = resultFromRiot.info.participants[flag].item6;

            reader.Close();
            dataStream.Close();
            response.Close();
            return infor;
        }
        public static MatchInfor getMatchInfor1(string id, string server, string summonerID)
        {
            WebRequest request = WebRequest.Create("https://" + server + ".api.riotgames.com/lol/match/v5/matches/" + id + "?api_key=" + RiotKey);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            dynamic resultFromRiot = JsonConvert.DeserializeObject(responseFromServer);

            MatchInfor infor = new MatchInfor();
            int flag = 0; //luu lai nguoi dung muon lay infor o index so may, vi tra ve infor cua ca 10 nguoi choi 1 luc
            for (int i = 0; i < 10; i++)
            {
                if (summonerID.Equals((string)resultFromRiot.info.participants[i].summonerId))
                {
                    flag = i;
                    break;
                }
            }
            //gan tung so lieu cua tran dau vao player cua profile (1 player)
            infor.Kill = resultFromRiot.info.participants[flag].kills;
            infor.Death = resultFromRiot.info.participants[flag].deaths;
            infor.Assist = resultFromRiot.info.participants[flag].assists;
            infor.IsWin = resultFromRiot.info.participants[flag].win;
            infor.ChampName = resultFromRiot.info.participants[flag].championName;
            infor.ChampId = resultFromRiot.info.participants[flag].championId;
            infor.MatchMode = resultFromRiot.info.gameMode;
            infor.Gold = resultFromRiot.info.participants[flag].goldEarned;
            infor.MinionsKill = resultFromRiot.info.participants[flag].totalMinionsKilled;
            infor.Spell1Id = resultFromRiot.info.participants[flag].summoner1Id;
            infor.Spell2Id = resultFromRiot.info.participants[flag].summoner2Id;
            infor.ChampLevel = resultFromRiot.info.participants[flag].champLevel;

            infor.ItemId[0] = resultFromRiot.info.participants[flag].item0;
            infor.ItemId[1] = resultFromRiot.info.participants[flag].item1;
            infor.ItemId[2] = resultFromRiot.info.participants[flag].item2;
            infor.ItemId[3] = resultFromRiot.info.participants[flag].item3;
            infor.ItemId[4] = resultFromRiot.info.participants[flag].item4;
            infor.ItemId[5] = resultFromRiot.info.participants[flag].item5;
            infor.ItemId[6] = resultFromRiot.info.participants[flag].item6;

            //gan so lieu cua tran dau vao 10 player trong muc chi tiet tran dau
            for (int i = 0; i < 10; i++)
            {
                

                //infor.matchDetailPlayer[i].ItemId[0] = resultFromRiot.info.participants[i].item0;
                //infor.matchDetailPlayer[i].ItemId[1] = resultFromRiot.info.participants[i].item1;
                //infor.matchDetailPlayer[i].ItemId[2] = resultFromRiot.info.participants[i].item2;
                //infor.matchDetailPlayer[i].ItemId[3] = resultFromRiot.info.participants[i].item3;
                //infor.matchDetailPlayer[i].ItemId[4] = resultFromRiot.info.participants[i].item4;
                //infor.matchDetailPlayer[i].ItemId[5] = resultFromRiot.info.participants[i].item5;
                //infor.matchDetailPlayer[i].ItemId[6] = resultFromRiot.info.participants[i].item6;
                int kill= resultFromRiot.info.participants[i].kills;
                int death = resultFromRiot.info.participants[i].deaths;
                int assist = resultFromRiot.info.participants[i].assists;
                bool isWin = resultFromRiot.info.participants[i].win;
                string champName = resultFromRiot.info.participants[i].championName;
                int champId = resultFromRiot.info.participants[i].championId;
                int spell1Id = resultFromRiot.info.participants[i].summoner1Id;
                int spell2Id = resultFromRiot.info.participants[i].summoner2Id;
                int champLevel = resultFromRiot.info.participants[i].champLevel;
                int gold = resultFromRiot.info.participants[i].goldEarned;
                int minionsKill = resultFromRiot.info.participants[i].totalMinionsKilled;
                string summmonerName = resultFromRiot.info.participants[i].summonerName;
                int damage = resultFromRiot.info.participants[i].totalDamageDealtToChampions;
                int[] itemId = new int[7];
                itemId[0] = resultFromRiot.info.participants[i].item0;
                itemId[1] = resultFromRiot.info.participants[i].item1;
                itemId[2] = resultFromRiot.info.participants[i].item2;
                itemId[3] = resultFromRiot.info.participants[i].item3;
                itemId[4] = resultFromRiot.info.participants[i].item4;
                itemId[5] = resultFromRiot.info.participants[i].item5;
                itemId[6] = resultFromRiot.info.participants[i].item6;
                infor.matchDetailPlayer[i] = new MatchDetailPlayer(kill, death,assist, isWin,champName, champId, spell1Id, spell2Id, champLevel, gold, minionsKill, summmonerName, damage,itemId);
            }
            reader.Close();
            dataStream.Close();
            response.Close();
            return infor;
        }
        public static bool isRealInGameName(string name, string server)
        {
            WebRequest request = WebRequest.Create("https://"+server+".api.riotgames.com/lol/summoner/v4/summoners/by-name/"+name+"?api_key="+RiotKey);

            //try
            //{
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                dataStream.Close();
                response.Close();
            //}
            //catch( Exception e)
            //{
            //    return false;
            //}
            return true;
        }

        public static User GetAccountIdInfor (string name, string server)
        {
            try
            {
                WebRequest request = WebRequest.Create("https://" + server + ".api.riotgames.com/lol/summoner/v4/summoners/by-name/" + name + "?api_key=" + RiotKey);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                dynamic resultFromRiot = JsonConvert.DeserializeObject(responseFromServer);

                var acc = new User();
                acc.AccountId = resultFromRiot.accountId;
                acc.Id = resultFromRiot.id;
                acc.Puuid = resultFromRiot.puuid;
                acc.SummonerLevel = resultFromRiot.summonerLevel;
                acc.ProfileIconId = resultFromRiot.profileIconId;

                reader.Close();
                dataStream.Close();
                response.Close();
                return acc;
            }
            catch(Exception e)
            {
                return null;
            }           
        }
        public static ProfileViewModel gettop3mastery(string inGameName, string server)
        {
            string id = UserDAO.getEncryptedSummonerId(inGameName, server);
            WebRequest request = WebRequest.Create("https://" + server + ".api.riotgames.com/lol/champion-mastery/v4/champion-masteries/by-summoner/" + id + "?api_key=" + RiotKey);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            dynamic resultFromRiot = JsonConvert.DeserializeObject(responseFromServer);
            ProfileViewModel result = new ProfileViewModel();

            for (int i = 0; i < 3; i++)
            {
                result.Top3MasteryCode[i] = resultFromRiot[i].championId;
                result.Top3MasteryName[i] = DAO.ChampionDAO.getChampionName(result.Top3MasteryCode[i]);
                result.Top3MasteryPoint[i] = resultFromRiot[i].championPoints;
                result.Top3MasteryLevel[i] = resultFromRiot[i].championLevel;
            }
            
            reader.Close();
            dataStream.Close();
            response.Close();
            return result;
        }

        public static void setChampionInfor()
        {

            WebRequest request = WebRequest.Create("https://ddragon.leagueoflegends.com/cdn/11.11.1/data/en_US/champion.json");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            dynamic resultFromRiot1 = JsonConvert.DeserializeObject(responseFromServer);

            dynamic resultFromRiot2 = resultFromRiot1.data;
            foreach (dynamic champName in resultFromRiot2)
            {
                foreach (var infor in champName)
                {
                    string championID = infor.key;
                    string championName = infor.id;
                    string iconpath = "img/Champions/" + championName + ".png";
                    UserDAO.addChamp(championID, championName, iconpath);
                }
            }
            ////string championID = resultFromRiot[i].key;
            ////string championName = resultFromRiot[i].id;
            ////string iconpath = "~/img/Champions/" + resultFromRiot[i].id + ".png";
            ////UserDAO.addChamp(championID, championName, iconpath);
            reader.Close();
            dataStream.Close();
            response.Close();
        }
        public static void setItemInfo()
        {
            WebRequest request = WebRequest.Create("http://ddragon.leagueoflegends.com/cdn/11.12.1/data/en_US/item.json");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            dynamic resultFromRiot1 = JsonConvert.DeserializeObject(responseFromServer);
            dynamic resultFromRiot2 = resultFromRiot1.data;
            foreach (dynamic item in resultFromRiot2)
            {
                foreach (var infor in item)
                {
                    string it = infor.image.full;
                    string[] itArr = it.Split(".");
                    string itemID = itArr[0];
                    string itName = infor.name;
                    string iconpath = "img/Items/" + itemID + ".png";
                    UserDAO.addItem(itemID, itName, iconpath);
                }
            }
        }
    }
}
