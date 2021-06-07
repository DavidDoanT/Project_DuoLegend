using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.ViewModels
{
    public class ProfileViewModel
    {
        private string[] _top3Mastery;

        public string[] Top3Mastery
        {
            get { return _top3Mastery; }
            set { _top3Mastery = value; }
        }

    }
}
