using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=ADMIN;Initial Catalog=no_data_DuoDatabase_version-1.2.0;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-6d869d2d-14a5-4258-bec1-64ef62dfd1ef";
        
    }
}
