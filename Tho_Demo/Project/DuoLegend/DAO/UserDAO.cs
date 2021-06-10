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

        /// <summary>
        /// get 3 in game name with is match with server
        /// </summary>
        /// <param name="server"> server of user </param>
        /// <returns>3 in game name that available in that server</returns>
        public static MainPageViewModel get3InGameNameByServer(string server)
        {
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;
            com.CommandText = "select top 3  inGameName from testUser where server=@server order by NEWID() ";
            com.Parameters.AddWithValue("@server", server);
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

        /// <summary>
        /// ID use for API
        /// </summary>
        /// <param name="inGameName"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public static string getEncryptedSummonerId(string inGameName, string server)
        {
            com.Parameters.Clear();
            if (inGameName is null)
            {
                return null;
            }
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select id  from testUser where inGameName = @inGameName and server = @server";
            com.Parameters.AddWithValue("@server", server);
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

            com.CommandText = "INSERT INTO testUser(inGameId,inGameName,password,server,email,id,accountId,puuid,isDeleted) VALUES(@inGameId,@inGameName,@password,@server,@email,@id,@accountId,@puuid,@isDeleted)";
            com.Parameters.AddWithValue("@inGameId", user.Id);
            com.Parameters.AddWithValue("@inGameName", user.InGameName);
            com.Parameters.AddWithValue("@password", user.Password);
            com.Parameters.AddWithValue("@server", user.Server);
            com.Parameters.AddWithValue("@email", user.Email);
            com.Parameters.AddWithValue("@id", user.Id);
            com.Parameters.AddWithValue("@accountId", user.AccountId);
            com.Parameters.AddWithValue("@puuid", user.Puuid);
            com.Parameters.AddWithValue("@isDeleted", false);
            com.EndExecuteNonQuery(com.BeginExecuteNonQuery());
            conn.Close();
        }

        public static void addChamp(string id, string name, string path)
        {
            com.Parameters.Clear();

            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "INSERT INTO Champion(championid,championName,iconPath) VALUES(@championid,@championName,@iconPath)";
            com.Parameters.AddWithValue("@championid", id);
            com.Parameters.AddWithValue("@championName", name);
            com.Parameters.AddWithValue("@iconPath", path);
            com.EndExecuteNonQuery(com.BeginExecuteNonQuery());
            conn.Close();
        }

        public static User getUserByEmail(string email)
        {
            User user = new User();
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select inGameName,server  from testUser where email = @email";

            com.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {

                user.InGameName = (string)reader["inGameName"];
                user.Server = (string)reader["server"];
            }
            else
            {
                conn.Close();
                return user;
            }
            conn.Close();
            return user;
        }
        public static bool Update(User userIn, string oldEmail)
        {
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;
            

            int temp;
            //convert bool datatype to int because hasMic in DB is bit type
            if (userIn.HasMic)
            {
                temp = 1;
            }
            else
            {
                temp = 0;
            }

            com.CommandText = "UPDATE TestUser SET inGameName = @NewInGameName, server = @NewServer, hasMic = @NewHasMic,note = @NewNote, lane = @NewLane  WHERE email = @oldEmail";
            com.Parameters.AddWithValue("@NewInGameName", userIn.InGameName);
            com.Parameters.AddWithValue("@NewServer", userIn.Server);
            com.Parameters.AddWithValue("@NewHasMic", temp);
            com.Parameters.AddWithValue("@oldEmail", oldEmail);
            com.Parameters.AddWithValue("@NewNote", userIn.Note);
            com.Parameters.AddWithValue("@NewLane", userIn.Lane);
            com.EndExecuteNonQuery(com.BeginExecuteNonQuery());
            conn.Close();
            return true;
        }

        public static string getNote(string inGameName, string server)
        {
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select Note  from testUser where inGameName = @inGameName and server=@server";

            com.Parameters.AddWithValue("@inGameName", inGameName);
            com.Parameters.AddWithValue("@server", server);
            SqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {
                string temp= (string)reader["Note"];
                conn.Close();
                return temp;
            }
            else
            {
                conn.Close();
                return null;
            }
            
        }

        public static bool isHaveMic(string inGameName, string server)
        {
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select hasMic  from testUser where inGameName = @inGameName and server=@server";

            com.Parameters.AddWithValue("@inGameName", inGameName);
            com.Parameters.AddWithValue("@server", server);
            SqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {
                bool temp = (bool)reader["hasMic"];
                if(temp)
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
            else
            {
                conn.Close();
                return false;
            }
        }

    }
}
