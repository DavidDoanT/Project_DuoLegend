using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class MatchInfor
    {
        public int Kill { get; set; }
        public int Death { get; set; }

        public int Assist { get; set; }
        public bool IsWin { get; set; }
        public string ChampName { get; set; }
        public int ChampId { get; set; }
    }
}
