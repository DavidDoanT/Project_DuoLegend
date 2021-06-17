using System;
using DuoLegend.DatabaseConnection;

namespace DuoLegend.DAO
{
    //Name subjects to be changed
    public static class WebsiteStatisticDAO
    {
        private static DateTime _today;
        public static bool IsTodayRecordExist()
        {
            _today = DateTime.Now.Date;

            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "SELECT [date] FROM WebsiteStatistics WHERE [date] = @today";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);
            
            DbConnection.Dr = DbConnection.Cmd.ExecuteReader();

            if(DbConnection.Dr.Read()){
                DbConnection.Disconnect();
                return true;
            }

            DbConnection.Disconnect();
            return false;
        }

        public static void CreateTodayRecord()
        {
            _today = DateTime.Now.Date;

            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "INSERT INTO WebsiteStatistics ([date], visitorCount, newAccountCount) VALUES (@today, 0, 0)";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);

            DbConnection.Cmd.ExecuteNonQuery();

            DbConnection.Disconnect();
        }

        public static void IncrementVisitorCount()
        {
            _today = DateTime.Now.Date;

            DbConnection.Connect();

            DbConnection.Cmd.CommandText = "UPDATE WebsiteStatistics SET visitorCount = visitorCount + 1 WHERE [date] = @today";
            DbConnection.Cmd.Parameters.AddWithValue("today", _today);
            
            DbConnection.Cmd.ExecuteNonQuery();

            DbConnection.Disconnect();
        }

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