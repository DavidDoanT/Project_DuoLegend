using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    public class userInforMainPage
    {
        public userInforMainPage()
        {
            champName = new string[3];
        }
        public double Kill { get; set; }
        public double Death { get; set; }

        public double Assist { get; set; }
        public double WinRate { get; set; }
        public string[] champName { get; set; }
    }
}
