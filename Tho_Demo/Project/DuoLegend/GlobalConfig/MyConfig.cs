using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=ADMIN;Initial Catalog=no_data_DuoDatabase_version-1.1.0;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-86e58ce7-6619-4116-ab20-4329e508bc39";
        
    }
}
