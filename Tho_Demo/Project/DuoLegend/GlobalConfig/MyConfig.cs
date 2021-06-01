using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=DESKTOP-B97EA2J;Initial Catalog=no_data_DuoDatabase_version-1.0.4;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-25f14b96-5fb8-493c-9037-5eb27e7a8d5e";
    }
}
