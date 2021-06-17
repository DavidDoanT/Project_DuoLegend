using DuoLegend.Models;
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
        private string _summonerName;
        private int _summonerLevel;
        private int _win;
        private int _lose;
        private string _profileIconPath;
        private int _profileIconId;
        private string _server;
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        public string Server
        {
            get { return _server; }
            set { _server = value;}
        }

        public int ProfileIconId
        {           
            set { _profileIconId = value; }
        }


        public string ProfileIconPath
        {
            get { 
                return "http://ddragon.leagueoflegends.com/cdn/11.12.1/img/profileicon/"+_profileIconId.ToString()+".png"; 
            }          
        }


        public int Lose
        {
            get { return _lose; }
            set { _lose = value; }
        }

        public int Win
        {
            get { return _win; }
            set { _win = value; }
        }


        public int SummonerLevel
        {
            get { return _summonerLevel; }
            set { _summonerLevel = value; }
        }

        public string SummonerName
        {
            get { return _summonerName; }
            set { _summonerName = value; }
        }

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
        public MatchInfor[] MatchList { get; set; } = new MatchInfor[3];
    }
}
