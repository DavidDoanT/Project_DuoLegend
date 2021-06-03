using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    /// <summary>
    ///all information of user
    /// </summary>
    public class User
    {
        private string _id;
        private string _accountId;
        private string _puuid;
        private string _inGameName;
        private string _server;
        private string _email;
        private string _password;
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

    }
}
