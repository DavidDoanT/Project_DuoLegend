using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{

    public class User
    {
        private string _id;
        private string _accountId;
        private string _puuid;
        private string _inGameName;
        private string _server;
        private string _email;
        private string _password;
        private int _summonerLevel;
        private int _profileIconId;
        private bool _hasMic;
        private string _lane;
        private string _note;
        private string _facebookLink;
        private int _isVerified;
        private int _isDeleted;
        private int _userId;

        public int UserID
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public int IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }

        public int IsVerified {
            get { return _isVerified; }
            set { _isVerified = value; }
        }

        public string FacebookLink
        {
            get { return _facebookLink; }
            set { _facebookLink = value; }
        }
        public int ProfileIconId
        {
            get { return _profileIconId; }
            set { _profileIconId = value; }
        }

        public int SummonerLevel
        {
            get { return _summonerLevel; }
            set { _summonerLevel = value; }
        }

        public User()
        {

        }
        public string Puuid
        {
            get { return _puuid; }
            set { _puuid = value; }
        }

        public string AccountId
        {
            get { return _accountId; }
            set { _accountId = value; }
        }


        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Please enter password contains 8 to 16 letters")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }
        [Required(ErrorMessage = "Ingame name is required")]
        public string InGameName
        {
            get { return _inGameName; }
            set { _inGameName = value; }
        }

        public bool HasMic
        {
            get { return _hasMic; }
            set { _hasMic = value; }
        }

        public string Lane
        {
            get { return _lane; }
            set { _lane = value; }
        }
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
    }
}
