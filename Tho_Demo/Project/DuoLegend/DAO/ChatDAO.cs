using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DuoLegend.DatabaseConnection;
using DuoLegend.GlobalConfig;
using DuoLegend.Models;

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

            com.CommandText = "select boxChatId  from boxChat where (user1=@user1 and user2=@user2)  OR (user1=@user2 and user2=@user1)";

            com.Parameters.AddWithValue("@user1", user1);
            com.Parameters.AddWithValue("@user2", user2 );
            SqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {

                id = Int32.Parse(reader["boxChatId"].ToString());
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

        public static void addChatContent(int boxChatId,string content, int sender)
        {
            DateTime time = new DateTime();
            time = DateTime.Now;
            com.Parameters.Clear();

            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "INSERT INTO boxChatDetail(boxChatId,timeSend,content,sendFrom) VALUES(@boxChatId,@timeSend,@content,@sendFrom)";
            com.Parameters.AddWithValue("@boxChatId", boxChatId);
            com.Parameters.AddWithValue("@timeSend", time);
            com.Parameters.AddWithValue("@content", content);
            com.Parameters.AddWithValue("@sendFrom", sender);


            com.EndExecuteNonQuery(com.BeginExecuteNonQuery());
            conn.Close();
        }

        public static List<BoxChatDetail> GetListBoxChatDetailById(int id)
        {
            List<BoxChatDetail> list = new List<BoxChatDetail>();
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select top 15 [content],sendFrom,timeSend,isSeen  from boxChatDetail where boxChatId=@id ORDER BY timeSend ";

            com.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                BoxChatDetail detail = new BoxChatDetail();
                detail.Content = reader["content"].ToString();
                detail.SendFrom = Int32.Parse(reader["sendFrom"].ToString());
                detail.TimeSend = (DateTime)reader["timeSend"];
                detail.IsSeen = (bool)reader["isSeen"];
                list.Add(detail);
            }
            conn.Close();
            return list;           
        }
        
        public static List<string[]> getUnseenList(int id)
        {
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "select boxChatId  from boxChat where user1 = @id1 or user2=@id1 ";

            com.Parameters.AddWithValue("@id1", id);

            SqlDataReader reader = com.ExecuteReader();
            List<int> listBoxChatId = new();
            while (reader.Read())
            {
                listBoxChatId.Add(Int32.Parse(reader["boxChatId"].ToString()));
            }
            conn.Close();
            List<string[]> result = new();
            foreach (var item in listBoxChatId)
            {
                com.Parameters.Clear();
                conn.Open();
                com.Connection = conn;

                com.CommandText = "select top 1 sendFrom  from boxChatDetail where boxChatId=@boxChatId AND sendFrom <> @id" +
                    " AND isSeen = 0" +
                    "   ORDER BY timeSend DESC ";

                com.Parameters.AddWithValue("@boxChatId", item);
                com.Parameters.AddWithValue("@id", id);

                reader = com.ExecuteReader();

                if (reader.Read())
                {
                    result.Add(UserDAO.getInGameNameServerById(Int32.Parse(reader["sendFrom"].ToString())));
                }
                conn.Close();
            }
            return result;
        }

        public static void changeSeenState(int sender, int boxChatId)
        {
            com.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            com.Connection = conn;

            com.CommandText = "UPDATE boxChatDetail SET isSeen = 1  WHERE boxChatId = @boxChatId AND sendFrom <> @sender AND isSeen = 0";
            com.Parameters.AddWithValue("@boxChatId", boxChatId);
            com.Parameters.AddWithValue("@sender", sender);
            com.EndExecuteNonQuery(com.BeginExecuteNonQuery());
            conn.Close();
        }
    }
}
