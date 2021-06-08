using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.ViewModels
{

    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
            _top3MasteryCode = new string[3];
            _top3MasteryName = new string[3];
            _top3MasteryPoint = new int[3];
            _top3MasteryLevel = new int[3];
        }
        private string[] _top3MasteryCode;
        private string[] _top3MasteryName;
        private int[] _top3MasteryPoint;
        private string _rank;
        private string _rankImgPath;
        private int[] _top3MasteryLevel;
        private int _rankScore;

        public int RankScore
        {
            get { return _rankScore; }
            set { _rankScore = value; }
        }



        public int[] Top3MasteryLevel
        {
            get {
                
                return _top3MasteryLevel; 
            }
            set { _top3MasteryLevel = value;}
        }

        public string RankImgPath
        {
            get { return _rankImgPath; }
            set { _rankImgPath = value; }
        }

        private string _tier;

        public string Tier
        {
            get { return _tier; }
            set { _tier = value; }
        }

        public string Rank
        {
            get { return _rank; }
            set 
            {
                _rankImgPath = "img/" + value.ToLower() + "Icon.png";
                _rank = value; 

            }
        }

        public int[] Top3MasteryPoint
        {
            get { return _top3MasteryPoint; }
            set { _top3MasteryPoint = value; }
        }

        public string[] Top3MasteryName
        {
            get { return _top3MasteryName; }
            set { _top3MasteryName = value; }
        }

        public string[] Top3MasteryCode
        {
            get { return _top3MasteryCode; }
            set { _top3MasteryCode = value; }
        }

    }
}
