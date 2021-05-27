using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=DESKTOP-B97EA2J;Initial Catalog=no_data_DuoDatabase_version-1.0.2;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-3e4a57ad-2b91-498a-a3cb-5238bc87721c";
    }
}
