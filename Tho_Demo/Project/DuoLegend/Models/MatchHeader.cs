using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class MatchHeader
    {
        public string Result { get; set; }
        public int TotalKills { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalAssists { get; set; }
        public int TotalGold { get; set; }

        public MatchHeader(string result, int totalKills, int totalDeaths, int totalAssists, int totalGold)
        {
            Result = result;
            TotalKills = totalKills;
            TotalDeaths = totalDeaths;
            TotalAssists = totalAssists;
            TotalGold = totalGold;
        }
    }
}
