using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=ADMIN;Initial Catalog=no_data_DuoDatabase_version-1.1.1;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-1434105a-9a30-4583-b3ad-f31b7d3016b4";
        
    }
}
