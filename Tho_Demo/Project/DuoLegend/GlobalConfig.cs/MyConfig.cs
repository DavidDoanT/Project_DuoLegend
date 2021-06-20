using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.GlobalConfig
{
    public static class MyConfig
    {
        public static string ConnectionString { get; } = "Data Source=SUPER-KT;Initial Catalog=DuoDatabase5;Integrated Security=True";
        public static string RiotKey { get; set; } = "RGAPI-a1a02539-2fc4-4057-9c16-5a98a06ee9de";

    }
}