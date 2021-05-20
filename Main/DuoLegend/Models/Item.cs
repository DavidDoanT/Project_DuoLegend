using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class Item
    {
        private string _itemId;
        private string _championName;
        private string _iconPath;

        public string ItemId { get; set; }
        public string ChampionName { get; set; }
        public string IconPath { get; set; }
    }
}
