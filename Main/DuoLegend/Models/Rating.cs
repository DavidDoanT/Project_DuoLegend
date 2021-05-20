using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class Rating
    {
        private string _raterId;
        private string _ratedId;
        private int _skillScore;
        private int _behaviorScore;

        public string RaterId { get; set; }
        public string RatedId { get; set; }
        public int SkillScore { get; set; }
        public int BehaviorScore { get; set; }
    }
}
