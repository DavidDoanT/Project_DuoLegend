using DuoLegend.GlobalConfig;
using DuoLegend.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.DAO
{
    public class RatingDAO
    {
        private static SqlConnection conn = new SqlConnection();
        private static SqlCommand com = new SqlCommand();
        public static void addRating(Rating r)
        {
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;
            conn.Open();
            com.Connection = conn;
            com.CommandText = "INSERT INTO Rating(raterId,userId,skillScore,behaviorScore) VALUES(@raterId,@userId,@skillScore,@behaviorScore)";
            com.Parameters.AddWithValue("@raterId", r.RaterId);
        }
    }
}
