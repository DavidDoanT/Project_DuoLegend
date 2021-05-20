using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class BannedUser
    {
        private string _banId;
        private string _userId;
        private string _adminId;
        private string _expirationDate;
        private string _reason;

        public string BanId { get; set; }
        public string UserId { get; set; }
        public string AdminId { get; set; }
        public string ExpirationDate { get; set; }
        public string Reason { get; set; }
    }
}
