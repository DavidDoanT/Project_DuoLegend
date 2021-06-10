using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=SK-20190915MKOH;Initial Catalog=no_data_DuoDatabase_version-1.1.1;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-b0d406b6-1b16-4973-8e16-04936e4e848b";
        
    }
}
