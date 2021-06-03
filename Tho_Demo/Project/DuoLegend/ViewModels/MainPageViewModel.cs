using DuoLegend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.ViewModels
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            InGameName = new string[3];
            Rank = new string[3];
            ListUserInfor = new userInforMainPage[3];
        }
        public string[] Rank { get; set; }
        public string[] InGameName { get; set; }

        public userInforMainPage[] ListUserInfor { get; set; }

        //public string[] LatestPlayByName { get; set; }
        //public int[] LatestPlayById { get; set; }
        //public float WinRate { get; set; }
        //public int[] KDA { get; set; }
    }
}
