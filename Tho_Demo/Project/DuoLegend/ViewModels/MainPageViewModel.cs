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
            inGameName = new string[3];
        }
        public string[] inGameName { get; set; }
    }
}
