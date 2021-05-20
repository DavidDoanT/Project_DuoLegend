using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class Champion
    {
        private string _championId;
        private string _championName;
        private string _iconPath;

        public string ChampionId { get; set; }
        public string ChampionName { get; set; }
        public string IconPath { get; set; }
    }
}
