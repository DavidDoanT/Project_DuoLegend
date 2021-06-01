using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=DESKTOP-B97EA2J;Initial Catalog=no_data_DuoDatabase_version-1.0.4;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-c9bd1984-c885-47ef-a191-d93df0389f43";
    }
}
