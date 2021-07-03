using DuoLegend.GlobalConfig;
using DuoLegend.Models;
using DuoLegend.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;


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
            com.CommandText = "select top 3  inGameName from [User] where server=@server order by NEWID() ";
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

            com.CommandText = "select id  from [User] where inGameName = @inGameName and server = @server";
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

            com.CommandText = "select puuid  from [User] where inGameName = @inGameName";

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
            com.CommandText = "select * from [User] where email = '" + email + "' and password = '" + password + "' ";
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

            com.CommandText = "select email from [User] where email = @email";
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

            com.CommandText = "INSERT INTO [User](inGameName,password,server,email,id,accountId,puuid,isDeleted,isVerified) VALUES(@inGameName,@password,@server,@email,@id,@accountId,@puuid,@isDeleted,@isVerified)";
            com.Parameters.AddWithValue("@inGameName", user.InGameName);
            com.Parameters.AddWithValue("@password", user.Password);
            com.Parameters.AddWithValue("@server", user.Server);
            com.Parameters.AddWithValue("@email", user.Email);
            com.Parameters.AddWithValue("@id", user.Id);
            com.Parameters.AddWithValue("@accountId", user.AccountId);
            com.Parameters.AddWithValue("@puuid", user.Puuid);
            com.Parameters.AddWithValue("@isDeleted", 0);
            com.Parameters.AddWithValue("@isVerified", 0);
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
        public static void addItem(string id, string name, string path)
        {
            com.Parameters.Clear();

            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "INSERT INTO Item(itemId,itemName,iconPath) VALUES(@itemId,@itemName,@iconPath)";
            com.Parameters.AddWithValue("@itemId", id);
            com.Parameters.AddWithValue("@itemName", name);
            com.Parameters.AddWithValue("@iconPath", path);
            com.EndExecuteNonQuery(com.BeginExecuteNonQuery());
            conn.Close();
        }
        public static void addSpell(int id, string name, string path)
        {
            com.Parameters.Clear();

            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;
            //com.CommandText = "SET IDENTITY_INSERT Spell ON";
            com.CommandText = "INSERT INTO Spell(spellId,spellName,iconPath) VALUES(@spellId,@spellName,@iconPath)";
            com.Parameters.AddWithValue("@spellId", id);
            com.Parameters.AddWithValue("@spellName", name);
            com.Parameters.AddWithValue("@iconPath", path);
            //com.CommandText = "SET IDENTITY_INSERT Spell OFF";
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

            com.CommandText = "select inGameName,server,hasMic,lane,note from [User] where email = @email";

            com.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {

                user.Note = (string)reader["note"];
                user.Lane = (string)reader["lane"];
                user.HasMic = (bool)reader["hasMic"];
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

        public static int getIdByInGameNameServer(string inGameName, string server)
        {
            int id;
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select userid  from [User] where inGameName=@inGameName and server=@server";

            com.Parameters.AddWithValue("@inGameName", inGameName);
            com.Parameters.AddWithValue("@server", server);
            SqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {

                id = Int32.Parse(reader["userid"].ToString());
                conn.Close();
                return id;
            }
            else
            {
                conn.Close();
                return 0;
            }
        }
        /// <summary>
        /// DAO for update user information
        /// </summary>
        /// <param name="userIn"></param> Object user contain new user information
        /// <param name="oldEmail"></param> Email of user that are committing updating
        /// <returns>boolean value</returns>
        public static bool Update(User userIn, string oldEmail)
        {
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            if (userIn.Note == null)
            {
                userIn.Note = "";
            }

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

            com.CommandText = "UPDATE [User] SET inGameName = @NewInGameName, server = @NewServer, hasMic = @NewHasMic,note = @NewNote, lane = @NewLane  WHERE email = @oldEmail";
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

            com.CommandText = "select Note  from [User] where inGameName = @inGameName and server=@server";

            com.Parameters.AddWithValue("@inGameName", inGameName);
            com.Parameters.AddWithValue("@server", server);
            SqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {

                try
                {
                    string temp = (string)reader["Note"];
                    conn.Close();
                    return temp;
                }
                catch (Exception)
                {
                    conn.Close();
                    return "";
                }
            }
            else
            {
                conn.Close();
                return null;
            }

        }

        public static string getLane(string inGameName, string server)
        {
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select Lane  from [User] where inGameName = @inGameName and server=@server";

            com.Parameters.AddWithValue("@inGameName", inGameName);
            com.Parameters.AddWithValue("@server", server);
            SqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {

                try
                {
                    string temp = (string)reader["Lane"];
                    conn.Close();
                    return temp;
                }
                catch (Exception)
                {
                    conn.Close();
                    return "";
                }
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

            com.CommandText = "select hasMic  from [User] where inGameName = @inGameName and server=@server";

            com.Parameters.AddWithValue("@inGameName", inGameName);
            com.Parameters.AddWithValue("@server", server);
            SqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {
                try
                {
                    bool temp = (bool)reader["hasMic"];
                    if (temp)
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
                catch (Exception)
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

        public static void addActivationCode(string code, string email)
        {
            com.Parameters.Clear();

            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "UPDATE [User] SET activationCode=@code WHERE email=@email";
            com.Parameters.AddWithValue("@code", code);
            com.Parameters.AddWithValue("@email", email);
            com.EndExecuteNonQuery(com.BeginExecuteNonQuery());
            conn.Close();
        }

        public static bool isActivationCodeExist(string code)
        {
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;
            conn.Open();
            com.Connection = conn;
            com.CommandText = "SELECT activationCode FROM [User] WHERE activationCode=@code";
            com.Parameters.AddWithValue("@code", code);

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

        public static void verifyAccount(string code)
        {
            com.Parameters.Clear();

            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "UPDATE [User] SET isVerified=1 WHERE activationCode=@code";
            com.Parameters.AddWithValue("@code", code);
            com.EndExecuteNonQuery(com.BeginExecuteNonQuery());
            conn.Close();
        }

        public static int isVerified(string email)
        {
            int isVerified;
            com.Parameters.Clear();

            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "SELECT isVerified FROM [User] WHERE email=@email";
            com.Parameters.AddWithValue("@email", email);

            SqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {

                isVerified = Int32.Parse(reader["isVerified"].ToString());
                conn.Close();
                return isVerified;
            }
            else
            {
                conn.Close();
                return -1;
            }

        }
        public static void addResetPasswordCode(string code, string email)
        {
            com.Parameters.Clear();

            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "UPDATE [User] SET resetPasswordCode=@resetPasswordCode WHERE email=@email";
            com.Parameters.AddWithValue("@resetPasswordCode", code);
            com.Parameters.AddWithValue("@email", email);
            com.EndExecuteNonQuery(com.BeginExecuteNonQuery());
            conn.Close();
        }

        public static bool isResetPasswordCodeExist(string code)
        {
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;
            conn.Open();
            com.Connection = conn;
            com.CommandText = "SELECT resetPasswordCode FROM [User] WHERE resetPasswordCode=@resetPasswordCode";
            com.Parameters.AddWithValue("@resetPasswordCode", code);

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

        public static void resetPassword(string code, string newPassword)
        {
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;
            conn.Open();
            com.Connection = conn;
            com.CommandText = "UPDATE [User] SET password=@newPassword WHERE resetPasswordCode=@resetPasswordCode";
            com.Parameters.AddWithValue("@newPassword", newPassword);
            com.Parameters.AddWithValue("@resetPasswordCode", code);
            com.ExecuteNonQuery();

            //Xóa reset password code sau khi đã đổi password
            com.CommandText = "UPDATE [User] SET resetPasswordCode=@resetCode WHERE resetPasswordCode=@code";
            com.Parameters.AddWithValue("@resetCode", "");
            com.Parameters.AddWithValue("@code", code);
            com.ExecuteNonQuery();
            conn.Close();
        }

        public static string[] getInGameNameServerById(int id)
        {
            string[] result = new string[2];
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select inGameName, server from [User] where userid = @userid";

            com.Parameters.AddWithValue("@userid", id);

            SqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {

                result[0] = (string)reader["inGameName"];
                result[1] = (string)reader["server"];
                conn.Close();
                return result;
            }
            else
            {
                conn.Close();
                return null;
            }
        }

        public static List<User> getAllUser()
        {
            List<User> userList = new List<User>();
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "SELECT userId,email,inGameName,server,facebookLink,isVerified,isDeleted FROM [User]";
            SqlDataReader reader = com.ExecuteReader();
            User user;
            while (reader.Read())
            {
                user = new User();
                user.UserID = (int)reader["userId"];
                user.Email = reader["email"].ToString();
                user.InGameName = reader["inGameName"].ToString();
                user.Server = reader["server"].ToString();
                user.FacebookLink = reader["facebookLink"].ToString();
                user.IsVerified = (byte)reader["isVerified"];
                user.IsDeleted = (byte)reader["isDeleted"];
                userList.Add(user);
            }
            conn.Close();
            return userList;
        }

    }
}
