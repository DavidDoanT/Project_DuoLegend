using DuoLegend.GlobalConfig;
using DuoLegend.Models;
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
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;
            com.CommandText = "select top 3  inGameName from testUser order by NEWID() ";
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

        //ve sau doi para thanh email
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
        public static string getPuuId(string inGameName)
        {

            com.Parameters.Clear();
            if (inGameName is null)
            {
                return null;
            }
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select puuid  from testUser where inGameName = @inGameName";

            com.Parameters.AddWithValue("@inGameName", inGameName);
            SqlDataReader reader = com.ExecuteReader();
            string temp;
            if (reader.Read())
            {

                temp = (string)reader["puuid"];

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
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;
            com.CommandText = "select * from TestUser where email = '" + email + "' and password = '" + password + "' ";
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                conn.Close();
                reader.Close();
                return true;

            }
            else
            {
                conn.Close();
                reader.Close();
                return false;
            }

        }

        public static bool isDuplicateUser(string email)
        {
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select email from testUser where email = @email";
            com.Parameters.AddWithValue("@email", email);
            
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                conn.Close();
                return true;

            }
            else
            {
                reader.Close();
                conn.Close();
                return false;
            }
        }

        public static void addUser(User user)
        {
            com.Parameters.Clear();
        
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "INSERT INTO testUser(inGameId,inGameName,password,server,email,id,accountId,puuid) VALUES(@inGameId,@inGameName,@password,@server,@email,@id,@accountId,@puuid)";
            com.Parameters.AddWithValue("@inGameId", user.Id);
            com.Parameters.AddWithValue("@inGameName", user.InGameName );
            com.Parameters.AddWithValue("@password", user.Password );
            com.Parameters.AddWithValue("@server", user.Server);
            com.Parameters.AddWithValue("@email", user.Email);
            com.Parameters.AddWithValue("@id", user.Id);
            com.Parameters.AddWithValue("@accountId", user.AccountId);
            com.Parameters.AddWithValue("@puuid", user.Puuid);
            com.EndExecuteNonQuery(com.BeginExecuteNonQuery());
            conn.Close();
        }
    }
}
