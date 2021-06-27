
using System.Data.SqlClient;
using DuoLegend.DatabaseConnection;

namespace DuoLegend.DAO.AdminDAO
{
    /// <summary>
    /// Contains methods for accessing Admin related information
    /// </summary>
    public class AdminInfoDAO
    {
        /// <summary>
        /// Get admin's id from email
        /// </summary>
        /// <param name="email">The admin's email</param>
        /// <returns>
        /// An integer representing the admin's id. 
        /// If admin id is not found, -1 is returned   
        /// </returns>
        public static int GetAdminId(string email)
        {
            int adminId = -1;

            DbConnection.Connect();

            DbConnection.Cmd.CommandText = "SELECT adminId"
                                            + "WHERE email = @email"
                                            + "FROM [Admin]";

            DbConnection.Cmd.Parameters.AddWithValue("email", email);
            
            SqlDataReader dr = DbConnection.Cmd.ExecuteReader();

            if(dr.Read())
            {
                adminId = int.Parse(dr["adminId"].ToString());
            }

            return adminId;
        }
    }
}