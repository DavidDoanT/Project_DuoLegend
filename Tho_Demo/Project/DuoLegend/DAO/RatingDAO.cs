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
    public class RatingDAO
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
        public static bool checkRated(int raterId, int userId)
        {
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "SELECT behaviorScore FROM Rating WHERE raterId = @raterId and userId=@userId ";
            DbConnection.Cmd.Parameters.AddWithValue("@raterId", raterId);
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
    }
}
