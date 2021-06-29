using System;
using DuoLegend.DatabaseConnection;
using DuoLegend.Models;

namespace DuoLegend.DAO
{
    //Name subjects to be changed
    public static class WebsiteStatisticsDAO
    {
        private static DateTime _today;

        /// <summary>
        /// Get today's statistic
        /// </summary>
        /// <returns>A WebsiteStatistics object, containing the statistic of today</returns>
        public static WebsiteStatistics GetTodayRecord()
        {
            _today = DateTime.Now.Date;

            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "SELECT [date], visitorCount, newAccountCount "
                                            +"FROM WebsiteStatistics "
                                            +"WHERE [date] = @today";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);

            DbConnection.Dr = DbConnection.Cmd.ExecuteReader();

            if(DbConnection.Dr.Read())
            {
                WebsiteStatistics todayStatistic = new WebsiteStatistics();
                todayStatistic.Date = DateTime.Parse(DbConnection.Dr["date"].ToString());
                todayStatistic.VisitorCount = int.Parse(DbConnection.Dr["visitorCount"].ToString());
                todayStatistic.NewAccountCount = int.Parse(DbConnection.Dr["newAccountCount"].ToString());

                return todayStatistic;
            }

            return null;
        }

        /// <summary>
        /// Create a record of today to store statistic
        /// </summary>
        public static void CreateTodayRecord()
        {
            _today = DateTime.Now.Date;

            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "INSERT INTO WebsiteStatistics ([date], visitorCount, newAccountCount) VALUES (@today, 0, 0)";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);

            DbConnection.Cmd.ExecuteNonQuery();

            DbConnection.Disconnect();
        }

        /// <summary>
        /// Increment the visitorcount of today by one
        /// </summary>
        public static void IncrementVisitorCount()
        {
            _today = DateTime.Now.Date;

            DbConnection.Connect();

            DbConnection.Cmd.CommandText = "UPDATE WebsiteStatistics SET visitorCount = visitorCount + 1 WHERE [date] = @today";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);
            
            DbConnection.Cmd.ExecuteNonQuery();

            DbConnection.Disconnect();
        }

        /// <summary>
        /// Increment new account count of today by one
        /// </summary>
        public static void IncrementNewAccCount()
        {
            _today = DateTime.Now.Date;

            DbConnection.Connect();

            DbConnection.Cmd.CommandText = "UPDATE WebsiteStatistics SET newAccountCount = newAccountCount + 1 WHERE [date] = @today";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);
            
            DbConnection.Cmd.ExecuteNonQuery();

            DbConnection.Disconnect();
        }
    }
}