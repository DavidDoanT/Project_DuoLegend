using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.ViewModels
{
    public class UserListViewModel
    {
        private int _userId;
        private string _inGameName;
        private string _server;
        private string _email;
        private string _facebookLink;
        private int _isVerified;
        private int _isDeleted;
        private DateTime? _expirationDate;


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

        public int IsVerified
        {
            get { return _isVerified; }
            set { _isVerified = value; }
        }

        public string FacebookLink
        {
            get { return _facebookLink; }
            set { _facebookLink = value; }
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

        public DateTime? ExpirationDate
        {
            get { return _expirationDate; }
            set { _expirationDate = value; }
        }
    }
}
