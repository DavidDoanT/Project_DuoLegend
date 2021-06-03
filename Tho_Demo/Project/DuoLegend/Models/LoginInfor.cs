using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Models
{
    /// <summary>
    /// information that pass to login function
    /// </summary>
    public class LoginInfor
    {

        public string Email { get; set; }
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
