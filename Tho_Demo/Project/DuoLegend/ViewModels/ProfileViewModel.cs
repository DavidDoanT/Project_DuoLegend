using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.ViewModels
{
    public class ProfileViewModel
    {
        private string[] _top3MasteryCode;
        private string[] _top3MasteryName;

        public string[] Top3MasteryName
        {
            get { return _top3MasteryName; }
            set { _top3MasteryName = value; }
        }

        public string[] Top3MasteryCode
        {
            get { return _top3MasteryCode; }
            set { _top3MasteryCode = value; }
        }

    }
}
