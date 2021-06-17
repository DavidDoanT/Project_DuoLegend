
using DuoLegend.DatabaseConnection;
using System.Data.SqlClient;
using DuoLegend.GlobalConfig;

namespace DuoLegend.DAO
{
    public class AdminLoginDAO
    {

        public static bool Login(string email, string adminPassword)
        {
            DbConnection.Connect();

            DbConnection.Cmd.CommandText = "SELECT email, adminPassword FROM admin WHERE email = @email";
            DbConnection.Cmd.Parameters.AddWithValue("email", email);

            SqlDataReader reader = DbConnection.Cmd.ExecuteReader();

            string dbPassword;
            //Get adminPassword from database and check for validity of inputted password;
            if (reader.Read())
            {
                dbPassword = reader["adminPassword"].ToString();

                if (adminPassword.Equals(dbPassword))
                {
                    DbConnection.Disconnect();
                    return true;
                }
            }
            DbConnection.Disconnect();
            return false;
        }

    }
}