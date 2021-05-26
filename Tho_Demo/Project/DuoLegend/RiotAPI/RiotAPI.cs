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

namespace DuoLegend.RiotAPI
{
    static public class RiotAPI
    {
        private static string RiotKey = GlobalConfig.MyConfig.RiotKey;
        
        public static string getRankByEncryptedSummonerId(string id, string server)
        {
            WebRequest request = WebRequest.Create("https://"+server+".api.riotgames.com/lol/league/v4/entries/by-summoner/"+id+"?api_key="+RiotKey);
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);

            dynamic resultFromRiot = JsonConvert.DeserializeObject(responseFromServer);
            string tier = resultFromRiot[0].tier;
            reader.Close();
            dataStream.Close();
            response.Close();

            return tier;

        }

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
                if(summonerID.Equals(resultFromRiot.info.participants[i].summonerId))
                {
                    flag = i;
                    break;
                }
            }
            infor.Kill = resultFromRiot.info.participants[flag].kills;
            infor.Death = resultFromRiot.info.participants[flag].deaths;
            infor.Assist = resultFromRiot.info.participants[flag].assists;
            infor.IsWin = resultFromRiot.info.participants[flag].win;
            infor.ChampName = resultFromRiot.info.participants[flag].championName;
            infor.ChampId = resultFromRiot.info.participants[flag].championId;
            reader.Close();
            dataStream.Close();
            response.Close();
            return infor;
        }
    }
}
