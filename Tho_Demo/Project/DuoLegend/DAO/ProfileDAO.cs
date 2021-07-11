using DuoLegend.DatabaseConnection;
using DuoLegend.GlobalConfig;
using DuoLegend.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.DAO
{
    public class ProfileDAO
    {
        private static SqlConnection conn = new SqlConnection();
        private static SqlCommand com = new SqlCommand();
        public static bool addRating(Rating r)
        {
            if (r.RaterId == r.UserId) return false;
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "INSERT INTO Rating(raterId,userId,skillScore,behaviorScore,comment) VALUES(@raterId,@userId,@skillScore,@behaviorScore,@comment)";
            DbConnection.Cmd.Parameters.AddWithValue("@raterId", r.RaterId);
            DbConnection.Cmd.Parameters.AddWithValue("@userId", r.UserId);
            DbConnection.Cmd.Parameters.AddWithValue("@skillScore", r.SkillScore);
            DbConnection.Cmd.Parameters.AddWithValue("@behaviorScore", r.BehaviorScore);
            DbConnection.Cmd.Parameters.AddWithValue("@comment", r.Comment);
            try
            {
                DbConnection.Cmd.ExecuteNonQuery();
                DbConnection.Disconnect();
                return true;
            }
            catch (SqlException)
            {
                DbConnection.Disconnect();
                return false;
            }
            
            
        }
        public static void updateRating(Rating r)
        {
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "UPDATE Rating SET skillScore = @skillScore, behaviorScore = @behaviorScore, comment = @comment WHERE raterId = @raterId and userId=@userId";
            DbConnection.Cmd.Parameters.AddWithValue("@raterId", r.RaterId);
            DbConnection.Cmd.Parameters.AddWithValue("@userId", r.UserId);
            DbConnection.Cmd.Parameters.AddWithValue("@skillScore", r.SkillScore);
            DbConnection.Cmd.Parameters.AddWithValue("@behaviorScore", r.BehaviorScore);
            DbConnection.Cmd.Parameters.AddWithValue("@comment", r.Comment);
            DbConnection.Cmd.ExecuteNonQuery();
            DbConnection.Disconnect();
        }
       
        public static List<Rating> getAllRating(int userId)
        {
            List<Rating> listRate = new();
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "SELECT raterId,[userId],skillScore,behaviorScore,comment FROM Rating WHERE [userId]=@userId ";
            DbConnection.Cmd.Parameters.AddWithValue("@userId", userId);
            DbConnection.Dr = DbConnection.Cmd.ExecuteReader();
            while (DbConnection.Dr.Read())
            {
                Rating r = new Rating();
                r.RaterId = (int)DbConnection.Dr["raterId"];
                r.UserId = (int)DbConnection.Dr["userId"];
                r.SkillScore = (int)DbConnection.Dr["skillScore"];
                r.BehaviorScore = (int)DbConnection.Dr["behaviorScore"];
                r.Comment = (string)DbConnection.Dr["comment"];
                listRate.Add(r);
            }
            DbConnection.Disconnect();
            return listRate;
        }
        public static bool addLike(int likerId,int userId)
        {
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "INSERT INTO [Like](likerId,userId) VALUES(@likerId,@userId)";
            DbConnection.Cmd.Parameters.AddWithValue("@likerId", likerId);
            DbConnection.Cmd.Parameters.AddWithValue("@userId", userId);
            try
            {
                DbConnection.Cmd.ExecuteNonQuery();
                DbConnection.Disconnect();
                return true;
            }
            catch (SqlException)
            {
                DbConnection.Disconnect();
                return false;
            }
        }
        public static void deleteLike(int likerId, int userId)
        {
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "DELETE FROM [Like] WHERE likerId = @likerId and userId=@userId";
            DbConnection.Cmd.Parameters.AddWithValue("@likerId", likerId);
            DbConnection.Cmd.Parameters.AddWithValue("@userId", userId);
            DbConnection.Cmd.ExecuteNonQuery();
            DbConnection.Disconnect();
        }
        public static bool checkLiked(int? likerId, int userId)
        {
            if (likerId is null) return false;
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "SELECT likerId,userId FROM [Like] WHERE likerId = @likerId and userId=@userId ";
            DbConnection.Cmd.Parameters.AddWithValue("@likerId", likerId);
            DbConnection.Cmd.Parameters.AddWithValue("@userId", userId);
            DbConnection.Dr = DbConnection.Cmd.ExecuteReader();
            if (DbConnection.Dr.Read())
            {
                DbConnection.Disconnect();
                return true;
            }
            DbConnection.Disconnect();
            return false;
        }
        public static List<User> getLikedList(int likerId)
        {
            List <User> LikedList = new();
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "SELECT ingameName, server,hasMic,lane,note FROM[User] INNER JOIN[Like] ON[User].userId = [Like].userId WHERE[Like].likerId =@likerId";
            DbConnection.Cmd.Parameters.AddWithValue("@likerId", likerId);
            DbConnection.Dr = DbConnection.Cmd.ExecuteReader();
            while (DbConnection.Dr.Read())
            {
                User user = new();
                user.InGameName = DbConnection.Dr["inGameName"].ToString();
                user.Server = DbConnection.Dr["server"].ToString();
                user.HasMic = (bool)DbConnection.Dr["hasMic"];
                user.Lane = DbConnection.Dr["lane"].ToString();
                user.Note = DbConnection.Dr["note"].ToString();
                LikedList.Add(user);
            }
            DbConnection.Disconnect();
            return LikedList;
        }

        public static List<User> getListUserSortByAvgSkillScore()
        {
            List<User> list = new();
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "SELECT [User].userId,[User].inGameName,[User].server,AVG(Cast(skillScore as Float)) as skillAvg"+
                                            "FROM Rating inner join[User] on Rating.userId = [User].userId"+
                                           "GROUP BY [User].userId, [User].inGameName, [User].server"+
                                           "order by skillAvg desc";
            DbConnection.Dr = DbConnection.Cmd.ExecuteReader();
            while (DbConnection.Dr.Read())
            {
                User user = new();
                user.UserID = (int)DbConnection.Dr["userId"];
                user.InGameName = DbConnection.Dr["inGameName"].ToString();
                user.Server = DbConnection.Dr["server"].ToString();
                
                list.Add(user);
            }
            DbConnection.Disconnect();
            return list;
        }
        public static List<User> getListUserSortByAvgBehaviorScore()
        {
            List<User> list = new();
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "SELECT [User].userId,[User].inGameName,[User].server,AVG(Cast(behaviorScore as Float)) as behaviorAvg" +
                                            "FROM Rating inner join[User] on Rating.userId = [User].userId" +
                                           "GROUP BY [User].userId, [User].inGameName, [User].server" +
                                           "order by behaviorAvg desc";
            DbConnection.Dr = DbConnection.Cmd.ExecuteReader();
            while (DbConnection.Dr.Read())
            {
                User user = new();
                user.UserID = (int)DbConnection.Dr["userId"];
                user.InGameName = DbConnection.Dr["inGameName"].ToString();
                user.Server = DbConnection.Dr["server"].ToString();

                list.Add(user);
            }
            DbConnection.Disconnect();
            return list;
        }
    }
    
}
