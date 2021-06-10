using DuoLegend.GlobalConfig;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.DAO
{
    /// <summary>
    /// this class use to update img to local server and Database
    /// </summary>
    public static class ChampionDAO
    {
        private static SqlConnection conn = new SqlConnection();
        private static SqlCommand com = new SqlCommand();
        /// <summary>
        /// get image URL in local server
        /// </summary>
        /// <param name="id"> champion Id </param>
        /// <returns>image URL in local server</returns>
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
        /// <summary>
        /// get champion name by champion id
        /// </summary>
        /// <param name="id"> id of champion </param>
        /// <returns>champion id</returns>
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
