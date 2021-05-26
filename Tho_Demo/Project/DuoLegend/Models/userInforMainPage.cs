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
            champID = new int[3];
        }
        public int Kill { get; set; }
        public int Death { get; set; }

        public int Assist { get; set; }
        public float WinRate { get; set; }
        public int[] champID { get; set; }
    }
}
