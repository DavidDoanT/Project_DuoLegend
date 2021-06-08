using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class RankInfor
    {
        private string _rank;
        private string _tier;
        private int _lp;

        public int Lp
        {
            get { return _lp; }
            set { _lp = value; }
        }

        public string Tier
        {
            get { return _tier; }
            set { _tier = value; }
        }

        public string Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

    }
}
