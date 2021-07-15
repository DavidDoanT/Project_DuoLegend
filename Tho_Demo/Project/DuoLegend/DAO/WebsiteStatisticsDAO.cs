using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
                                            + "FROM WebsiteStatistics "
                                            + "WHERE [date] = @today";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);

            DbConnection.Dr = DbConnection.Cmd.ExecuteReader();

            if (DbConnection.Dr.Read())
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
        /// Performs increment update for selected field in database
        /// </summary>
        /// <param name="field"></param>
        private static void Increment(string field)
        {
            string sqlQuery = "UPDATE WebsiteStatistics "
                                + "SET " + field + " = " + field + " + 1 "
                                + "WHERE [date] = @today";
            _today = DateTime.Now.Date;

            DbConnection.Connect();
            DbConnection.Cmd.CommandText = sqlQuery;
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);

            DbConnection.Cmd.EndExecuteNonQuery(DbConnection.Cmd.BeginExecuteNonQuery());
            DbConnection.Disconnect();
        }

        /// <summary>
        /// Increment the uniqueVisitor of today by one
        /// </summary>
        public static void IncrementUniqueVisitorCount()
        {
            Increment("uniqueVisitor");
        }

        /// <summary>
        /// Increment new account column of today by one
        /// </summary>
        public static void IncrementNewAccCount()
        {
            Increment("newAccount");
        }

        /// <summary>
        /// Increment siteVisit column by 1
        /// </summary>
        public static void IncrementSiteVisit()
        {
            Increment("siteVisit");
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
                                            + "FROM WebsiteStatistics";

            DbConnection.Dr = DbConnection.Cmd.ExecuteReader();

            while (DbConnection.Dr.Read())
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
        /// Get a specified number of Record from the database
        /// </summary>
        /// <param name="numberOfRecord">The number of records to get</param>
        /// <returns>A list containing n number of records</returns>
        public static IList<WebsiteStatistics> GetRecords(int numberOfRecord)
        {
            string sqlQuery = "SELECT TOP(@numberOfRecord) [date], siteVisit, uniqueVisitor, newAccount "
                            + "FROM WebsiteStatistics "
                            + "ORDER BY [date] DESC";
            IList<WebsiteStatistics> webStats = new List<WebsiteStatistics>();

            DbConnection.Connect();
            DbConnection.Cmd.CommandText = sqlQuery;
            DbConnection.Cmd.Parameters.AddWithValue("numberOfRecord", numberOfRecord);

            DbConnection.Dr = DbConnection.Cmd.ExecuteReader();

            //Create list of records
            while (DbConnection.Dr.Read())
            {
                WebsiteStatistics stats = new WebsiteStatistics();

                stats.Date = DateTime.Parse(DbConnection.Dr["date"].ToString());
                stats.SiteVisit = int.Parse(DbConnection.Dr["siteVisit"].ToString());
                stats.UniqueVisitor = int.Parse(DbConnection.Dr["uniqueVisitor"].ToString());
                stats.NewAccount = int.Parse(DbConnection.Dr["newAccount"].ToString());

                webStats.Add(stats);
            }
            DbConnection.Disconnect();
            webStats = webStats.Reverse().ToList();

            return webStats;
        }

        /// <summary>
        /// Get statistic records grouped by an interval of time
        /// </summary>
        /// <param name="interval">An sql keyword representing an interval of time</param>
        /// <returns></returns>
        private static IList<WebsiteStatistics> GetRecords(string interval)
        {
            IList<WebsiteStatistics> webStats = new List<WebsiteStatistics>();
            try
            {
                string sqlQuery = "SELECT MIN([date]), "
                                        + "SUM(uniqueVisitor), "
                                        + "SUM(siteVisit), "
                                        + "SUM(newAccount) "
                                    + "FROM WebsiteStatistics "
                                    + "GROUP BY DATEPART(" + interval + ",[date])";

                DbConnection.Connect();
                DbConnection.Cmd.CommandText = sqlQuery;
                DbConnection.Dr = DbConnection.Cmd.ExecuteReader();

                while (DbConnection.Dr.Read())
                {
                    WebsiteStatistics stat = new WebsiteStatistics();
                    stat.Date = DbConnection.Dr.GetDateTime(0);
                    stat.UniqueVisitor = DbConnection.Dr.GetInt32(1);
                    stat.SiteVisit = DbConnection.Dr.GetInt32(2);
                    stat.NewAccount = DbConnection.Dr.GetInt32(3);

                    webStats.Add(stat);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                DbConnection.Disconnect();
            }

            return webStats;
        }

        public static IList<WebsiteStatistics> GetRecordsWeekly()
        {
            return GetRecords("week");
        }

        public static IList<WebsiteStatistics> GetRecordsMonthly()
        {
            return GetRecords("month");
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
                                            + "WHERE [date] = @today";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);

            DbConnection.Dr = DbConnection.Cmd.ExecuteReader();

            if (DbConnection.Dr.Read())
            {
                DbConnection.Disconnect();
                return true;
            }
            DbConnection.Disconnect();
            return false;
        }
    }
}