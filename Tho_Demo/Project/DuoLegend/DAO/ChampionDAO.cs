using DuoLegend.GlobalConfig;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.DAO
{
    public static class ChampionDAO
    {
        private static SqlConnection conn = new SqlConnection();
        private static SqlCommand com = new SqlCommand();
        public static string getChampionImgURLbyID(string id)
        {
            com.Parameters.Clear();

            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select iconPath  from Champion where ChampionId = @id";

            com.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = com.ExecuteReader();
            string temp = null;
            if (reader.Read())
            {

                temp = (string)reader["iconPath"];

            }
            conn.Close();
            return temp;
        }
        public static string getChampionName(string id)
        {
            com.Parameters.Clear();

            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select championName  from Champion where ChampionId = @id";

            com.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = com.ExecuteReader();
            string temp = null;
            if (reader.Read())
            {

                temp = (string)reader["championName"];

            }
            conn.Close();
            return temp;
        }
    }
}
