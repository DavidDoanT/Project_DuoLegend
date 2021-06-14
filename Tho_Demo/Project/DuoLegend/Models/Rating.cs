using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class Rating
    {
        // private string _raterId,_userId;
        // private int _skillScore, _behaviorScore;
        private string _raterId;
        public string RaterId
        {
            get { return _raterId; }
            set { _raterId = value; }
        }
        private string _userId;
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        private int _skillScore;
        public int SkillScore
        {
            get { return _skillScore; }
            set { _skillScore = value; }
        }
        private int _behaviorScore;
        public int BehaviorScore
        {
            get { return _behaviorScore; }
            set { _behaviorScore = value; }
        }
        
    }
}
