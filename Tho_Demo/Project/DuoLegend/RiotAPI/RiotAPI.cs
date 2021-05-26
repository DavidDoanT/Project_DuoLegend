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
    }
}
