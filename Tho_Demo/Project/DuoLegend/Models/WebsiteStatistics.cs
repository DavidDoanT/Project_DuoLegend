using System;
using System.ComponentModel.DataAnnotations;

namespace DuoLegend.Models
{
    public class WebsiteStatistics
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int VisitorCount { get; set; }
        public int NewAccountCount { get; set; }
    }
}