using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=SK-20190915MKOH;Initial Catalog=no_data_DuoDatabase_version-1.0.5;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-5d105c8d-a632-49b4-8a62-e1fae35673bc";
        
    }
}
