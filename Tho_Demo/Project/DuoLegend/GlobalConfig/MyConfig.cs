using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=SUPER-KT;Initial Catalog=DuoDatabase;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-76969a9c-d634-4647-be3e-208d1ffe9a9d";
        
    }
}
