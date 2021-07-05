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
        public string gameDuration { get; set; }
        public string gameStart { get; set; }
        public bool IsWin { get; set; }
        public string ChampName { get; set; }
        public int ChampId { get; set; }
        public string MatchMode { get; set; }
        public int MainRuneId { get; set; }
        public int SubRuneId { get; set; }
        public int Spell1Id { get; set; }
        public string Spell1Name { get; set; }
        public int Spell2Id { get; set; }
        public string Spell2Name { get; set; }
        public int ChampLevel { get; set; }
        public int Gold { get; set; }
        public int MinionsKill { get; set; }
        public int[] ItemId { get; set; } = new int[7];
        public MatchDetailPlayer[] matchDetailPlayer { get; set; }
        public MatchHeader[] matchHeader { get; set; } = new MatchHeader[2];
        public MatchInfor()
        {
            matchDetailPlayer = new MatchDetailPlayer[10];
        }
    }
}
