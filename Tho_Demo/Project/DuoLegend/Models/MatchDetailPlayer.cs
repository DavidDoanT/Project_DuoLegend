using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class MatchDetailPlayer
    {

        public MatchDetailPlayer(int kill, int death, int assist, bool isWin, string champName, int champId, int spell1Id, int spell2Id,int mainRuneId, int champLevel, int gold, int minionsKill, string summmonerName, int damage, int[]itemId)
        {
            Kill = kill;
            Death = death;
            Assist = assist;
            IsWin = isWin;
            ChampName = champName;
            ChampId = champId;
            Spell1Id = spell1Id;
            Spell2Id = spell2Id;
            MainRuneId = mainRuneId;
            ChampLevel = champLevel;
            Gold = gold;
            MinionsKill = minionsKill;
            SummmonerName = summmonerName;
            Damage = damage;
            ItemId = itemId;
        }

        public int Kill {get; set; }
        public int Death { get; set; }

        public int Assist { get; set; }
        public bool IsWin { get; set; }
        public string ChampName { get; set; }
        public int ChampId { get; set; }
        public int Spell1Id { get; set; }
        public int Spell1Name { get; set; }
        public int Spell2Id { get; set; }
        public int Spell2Name { get; set; }
        public int MainRuneId { get; set; }
        public int ChampLevel { get; set; }
        public int Gold { get; set; }
        public int MinionsKill { get; set; }
        public string SummmonerName { get; set; }
        public int Damage { get; set; }
        
        public int[] ItemId { get; set; } = new int[7];
    }
}
