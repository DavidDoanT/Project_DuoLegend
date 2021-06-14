using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DuoLegend.GlobalConfig;
namespace DuoLegend.DAO
{
    public class ChatDAO
    {
        private static SqlConnection conn = new SqlConnection();
        private static SqlCommand com = new SqlCommand();

        public static int getBoxChatId(int user1 , int user2)
        {
            int id;
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select boxChatId  from boxChat where user1=@user1 and user2=@user2";

            com.Parameters.AddWithValue("@user1", user1);
            com.Parameters.AddWithValue("@user2", user2 );
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

        public static void addBoxChat(int user1, int user2)
        {
            com.Parameters.Clear();

            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "INSERT INTO boxChat(user1,user2) VALUES(@user1,@user2)";
            com.Parameters.AddWithValue("@user1", user1);
            com.Parameters.AddWithValue("@user2", user2);
            com.EndExecuteNonQuery(com.BeginExecuteNonQuery());
            conn.Close();
        }

    }
}
