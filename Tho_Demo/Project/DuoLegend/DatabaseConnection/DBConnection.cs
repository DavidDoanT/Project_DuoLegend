
using System.Data.SqlClient;
using DuoLegend.GlobalConfig;

namespace DuoLegend.DatabaseConnection
{
    public static class DbConnection
    {
        private static SqlConnection _conn = new SqlConnection();
        private static SqlCommand _cmd = new SqlCommand();
        private static SqlDataReader _dr;

        public static SqlCommand Cmd { get => _cmd; }
        public static SqlDataReader Dr { get => _dr; set => _dr = value; }

        /// <summary>
        /// Set up connection with the database, set the connection for SqlCommand to the connection
        /// </summary>
        public static void Connect()
        {
            if (_conn.State == System.Data.ConnectionState.Closed)
            {
                _conn.ConnectionString = MyConfig.ConnectionString;
                _conn.Open();
            }
            if (Cmd.Connection == null)
            {
                Cmd.Connection = _conn;
            }
        }

        /// <summary>
        /// Disconnect with the databaes
        /// Clear all Parameters in Cmd, closes DataReader and  closes connection
        /// </summary>
        public static void Disconnect()
        {
            Cmd.Parameters.Clear();

            if (Dr != null)
            {
                Dr.Close();
            }

            if (_conn.State != System.Data.ConnectionState.Closed)
            {
                _conn.Close(); 
            }
        }
    }
}