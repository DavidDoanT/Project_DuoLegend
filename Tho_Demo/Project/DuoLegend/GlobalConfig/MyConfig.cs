using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=ADMIN;Initial Catalog=no_data_DuoDatabase_version-1.1.0;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-138a4c86-cea2-4883-8465-1bb7cb003f4a";
        
    }
}
