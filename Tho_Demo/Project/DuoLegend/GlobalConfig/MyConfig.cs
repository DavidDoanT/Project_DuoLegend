using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=ADMIN;Initial Catalog=no_data_DuoDatabase_version-1.0.4;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-4cf7015a-d05a-40c0-86d1-ff45f709e3d7";
    }
}
