using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=DESKTOP-ACK104U;Initial Catalog=no_data_DuoDatabase_version-1.1.1;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-d3c60177-cc64-45e8-b780-0e0d7a577cff";
        
    }
}
