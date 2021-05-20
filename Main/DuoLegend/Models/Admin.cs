using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class Admin
    {
        private string _adminId;
        private string _adminPassword;
        private string _userName;
        private string _dob;
        private string _email;

        public string AdminId { get; set; }
        public string AdminPassword { get; set; }
        public string UserName { get; set; }
        public string Dob { get; set; }
        public string Email { get; set; }
    }
}
