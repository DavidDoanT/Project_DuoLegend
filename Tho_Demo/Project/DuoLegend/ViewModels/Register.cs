using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.ViewModels
{
    public class Register
    {
        private string _inGameName;
        private string _server;
        private string _email;
        private string _password;

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
