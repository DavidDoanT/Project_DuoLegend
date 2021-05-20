using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class User
    {
        private string _userId;
        private string _inGameName;
        private string _facebookLink;
        private string _password;
        private string _avatarPath;
        private bool _isVerified;
        private bool _isDeleted;
        private string _server;

        public string UserId { get; set; }
        public string InGameName { get; set; }
        public string FacebookLink { get; set; }
        public string Password { get; set; }
        public string AvatarPath { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDeleted { get; set; }
        public string Server { get; set; }
    }
}
