using System;
using System.ComponentModel.DataAnnotations;

namespace DuoLegend.Models
{
    public class WebsiteStatistics
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int SiteVisit { get; set; }

        public int UniqueVisitor { get; set; }
        public int NewAccount { get; set; }
    }
}