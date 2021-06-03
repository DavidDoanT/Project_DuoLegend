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
        public static string ConnectionString { get;} = "Data Source=DESKTOP-B97EA2J;Initial Catalog=no_data_DuoDatabase_version-1.0.4;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-d3d4172f-1e60-475f-b794-57224f7b376b";
    }
}
