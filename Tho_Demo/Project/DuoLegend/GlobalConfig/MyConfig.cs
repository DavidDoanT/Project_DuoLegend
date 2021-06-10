using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=SUPER-KT;Initial Catalog=DuoDatabase;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-3a007dd7-b200-46cf-9194-111cce390b10";
        
    }
}
