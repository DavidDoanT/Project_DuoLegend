using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get;} = "Data Source=SUPER-KT;Initial Catalog=DuoDatabase;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-28f4707a-62fd-48c5-879e-06cbce684aca";
        
    }
}
