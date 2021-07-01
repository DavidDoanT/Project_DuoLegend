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
        private int _raterId;
        public int RaterId
        {
            get { return _raterId; }
            set { _raterId = value; }
        }
        private int _userId;
        public int UserId
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
        private string _comment;

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public Rating(int raterId, int userId, int skillScore, int behaviorScore, string comment)
        {
            RaterId = raterId;
            UserId = userId;
            SkillScore = skillScore;
            BehaviorScore = behaviorScore;
            Comment = comment;
        }
        public Rating()
        {

        }
    }
}
