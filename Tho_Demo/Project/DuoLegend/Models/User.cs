﻿using System;
using System.Collections.Generic;
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


        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


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
