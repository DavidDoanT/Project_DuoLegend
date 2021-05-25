using DuoLegend.GlobalConfig;
using DuoLegend.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.DAO
{
    public static class UserDAO
    {
        private static SqlConnection conn = new SqlConnection();
        private static SqlCommand com = new SqlCommand();
        public static MainPageViewModel  getRandomInGameName()
        {
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;
            com.CommandText = "select top(3) * from testUser";
            SqlDataReader reader = com.ExecuteReader();
            MainPageViewModel infor = new MainPageViewModel();
            int count = 0;
            while (reader.Read())
            {

                infor.inGameName[count] = (string)reader["inGameName"];
                count++;
            }
            conn.Close();
            return infor;
        }

        public static bool CheckLogin(string userName, string password)
        {
            return true;
        }
    }
}
