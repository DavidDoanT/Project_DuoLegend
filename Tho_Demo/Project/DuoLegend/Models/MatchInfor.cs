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
        public string MatchMode { get; set; }
        public int Spell1Id { get; set; }
        public int Spell1Name { get; set; }
        public int Spell2Id { get; set; }
        public int Spell2Name { get; set; }
        public int ChampLevel { get; set; }
        public int Gold { get; set; }
        public int MinionsKill { get; set; }
        public int[] ItemId { get; set; } = new int[7];
        public MatchDetailPlayer[] matchDetailPlayer { get; set; }
        public MatchInfor()
        {
            matchDetailPlayer = new MatchDetailPlayer[10];
        }
    }
}
