using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=ADMIN;Initial Catalog=no_data_DuoDatabase_version-1.1.1;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-91f9e69f-96a6-47be-97c2-d5696af27db2";
        
    }
}
