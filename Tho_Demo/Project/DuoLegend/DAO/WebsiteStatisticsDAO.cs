using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DuoLegend.DatabaseConnection;
using DuoLegend.Models;
using Microsoft.Extensions.Logging;

namespace DuoLegend.DAO
{
    //Name subjects to be changed
    public class WebsiteStatisticsDAO
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
            DbConnection.Cmd.CommandText = "SELECT [date], siteVisit, uniqueVisitor, newAccount "
                                            +"FROM WebsiteStatistics "
                                            +"WHERE [date] = @today";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);

            DbConnection.Dr = DbConnection.Cmd.ExecuteReader();

            if(DbConnection.Dr.Read())
            {
                WebsiteStatistics todayStatistic = new WebsiteStatistics();
                todayStatistic.Date = DateTime.Parse(DbConnection.Dr["date"].ToString());
                todayStatistic.SiteVisit = int.Parse(DbConnection.Dr["siteVisit"].ToString());
                todayStatistic.UniqueVisitor = int.Parse(DbConnection.Dr["uniqueVisitor"].ToString());
                todayStatistic.NewAccount = int.Parse(DbConnection.Dr["newAccount"].ToString());

                DbConnection.Disconnect();

                return todayStatistic;
            }

            DbConnection.Disconnect();

            return null;
        }

        /// <summary>
        /// Create a record of today to store statistic
        /// </summary>
        public static void CreateTodayRecord()
        {
            _today = DateTime.Now.Date;

            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "INSERT INTO WebsiteStatistics ([date], siteVisit, uniqueVisitor, newAccount) VALUES (@today, 0, 0, 0)";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);

            DbConnection.Cmd.ExecuteNonQuery();

            DbConnection.Disconnect();
        }

        /// <summary>
        /// Increment the uniqueVisitor of today by one
        /// </summary>
        public static void IncrementUniqueVisitorCount()
        {
            _today = DateTime.Now.Date;

            DbConnection.Connect();

            DbConnection.Cmd.CommandText = "UPDATE WebsiteStatistics SET uniqueVisitor = uniqueVisitor + 1 WHERE [date] = @today";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);
            
            DbConnection.Cmd.ExecuteNonQuery();

            DbConnection.Disconnect();
        }

        /// <summary>
        /// Increment new account column of today by one
        /// </summary>
        public static void IncrementNewAccCount()
        {
            _today = DateTime.Now.Date;

            DbConnection.Connect();

            DbConnection.Cmd.CommandText = "UPDATE WebsiteStatistics "
                                            +"SET newAccount = newAccount + 1 "
                                            +"WHERE [date] = @today";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);
            
            DbConnection.Cmd.ExecuteNonQuery();

            DbConnection.Disconnect();
        }

        /// <summary>
        /// Increment siteVisit column by 1
        /// </summary>
        public static void IncrementSiteVisit()
        {
            _today = DateTime.Now.Date;

            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "UPDATE WebsiteStatistics "
                                            +"SET siteVisit = siteVisit + 1 "
                                            +"WHERE [date] = @today";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);

            DbConnection.Cmd.ExecuteNonQuery();

            DbConnection.Disconnect();                                   
        }

        /// <summary>
        /// Get all website statistic record form the database
        /// </summary>
        /// <returns>A list containing all statistic record</returns>
        public static IList<WebsiteStatistics> GetRecords()
        {
            IList<WebsiteStatistics> webStats = new List<WebsiteStatistics>();

            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "SELECT [date], siteVisit, uniqueVisitor, newAccount "
                                            +"FROM WebsiteStatistics";
            
            DbConnection.Dr = DbConnection.Cmd.ExecuteReader();

            while(DbConnection.Dr.Read())
            {
                WebsiteStatistics stats = new WebsiteStatistics();

                stats.Date = DateTime.Parse(DbConnection.Dr["date"].ToString());
                stats.SiteVisit = int.Parse(DbConnection.Dr["siteVisit"].ToString());
                stats.UniqueVisitor = int.Parse(DbConnection.Dr["uniqueVisitor"].ToString());
                stats.NewAccount = int.Parse(DbConnection.Dr["newAccount"].ToString());

                webStats.Add(stats);
            }
            DbConnection.Disconnect();
            return webStats;
        }


        /// <summary>
        /// Check if a record of today's statistic already exist in databse
        /// </summary>
        /// <returns>A Boolean value</returns>
        public static bool IsTodayRecordExist()
        {
            _today = DateTime.Now.Date;

            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "SELECT [date] FROM WebsiteStatistics "
                                            +"WHERE [date] = @today";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);

            DbConnection.Dr = DbConnection.Cmd.ExecuteReader();

            if(DbConnection.Dr.Read())
            {
                DbConnection.Disconnect();
                return true;
            }
            DbConnection.Disconnect();
            return false;
        }
    }
}