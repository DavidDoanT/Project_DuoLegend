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

        public static MainPageViewModel getRandomInGameName()
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

                infor.InGameName[count] = (string)reader["inGameName"];
                count++;
            }
            conn.Close();
            return infor;
        }


        public static string getEncryptedSummonerId(string inGameName)
        {
            com.Parameters.Clear();
            if(inGameName is null)
            {
                return null;
            }
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select id  from testUser where inGameName = @inGameName";
            
            com.Parameters.AddWithValue("@inGameName", inGameName);
            SqlDataReader reader = com.ExecuteReader();
            string temp;
            if (reader.Read())
            {

                temp = (string)reader["id"];

            }
            else
            {
                conn.Close();
                return null;
            }
            conn.Close();
            return temp;

        }

        public static bool CheckLogin(string email, string password)
        {
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;
            com.CommandText = "select * from TestUser where email = '" + email + "' and password = '" + password + "' ";
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                conn.Close();
                return true;

            }
            else
            {
                conn.Close();
                return false;
            }

        }
    }
}
