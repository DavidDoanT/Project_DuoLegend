using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    /// <summary>
    /// contain config for different server
    /// </summary>
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=ADMIN;Initial Catalog=no_data_DuoDatabase_version-1.0.4;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-8b07addf-e940-4021-b4a6-a6d135251011";
    }
}
