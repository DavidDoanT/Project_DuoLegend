using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=ADMIN;Initial Catalog=no_data_DuoDatabase_version-1.0.3;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-70760658-adcd-441c-b7f2-0d0e95488b79";
    }
}
