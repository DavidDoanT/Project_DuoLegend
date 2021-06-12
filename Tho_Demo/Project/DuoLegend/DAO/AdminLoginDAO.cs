

using System.Data.SqlClient;
using DuoLegend.GlobalConfig;

namespace DuoLegend.DAO
{
    public class AdminLoginDAO    
    {
        private static SqlConnection conn = new SqlConnection();
        private static SqlCommand   cmd = new SqlCommand();

        public static bool Login(string email, string password)
        {
            cmd.Parameters.Clear();
            conn.ConnectionString = MyConfig.ConnectionString;

            conn.Open();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT email, adminPassword FROM admin WHERE email = @email";
            cmd.Parameters.AddWithValue("email", email);

            SqlDataReader reader = cmd.ExecuteReader();

            string dbPassword;
            //Get adminPassword from database;
            if(reader.Read())
            {
                dbPassword = reader["adminPassword"].ToString();
            }
            else
            {
                conn.Close();
                reader.Close();
                return false;
            }
            
            //Compare adminPassword with password
            if(password.Equals(dbPassword))
            {
                conn.Close();
                reader.Close();
                return true;
            }
            
            return false;
            
        }
    
    }
}