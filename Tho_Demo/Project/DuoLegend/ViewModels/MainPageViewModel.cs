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
        }
        public string[] Rank { get; set; }
        public string[] InGameName { get; set; }
    }
}
