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
            Server = new string[3];
            search = new Search();
            Note = new string[3];
            HasMic = new bool[3];
        }
        public Search search { get; set; }
        public string[] Rank { get; set; }
        public string[] InGameName { get; set; }
        public string[] Server { get; set; }
        public string[] Note { get; set; }
        public bool[] HasMic { get; set; }
        public userInforMainPage[] ListUserInfor { get; set; }

        //public string[] LatestPlayByName { get; set; }
        //public int[] LatestPlayById { get; set; }
        //public float WinRate { get; set; }
        //public int[] KDA { get; set; }
    }
}
