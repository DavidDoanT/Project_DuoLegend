using System;

namespace DuoLegend.Models
{
    public class BanInfo
    {
        public int UserId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Reason { get; set; }
    }
}