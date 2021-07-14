using System;
using System.Data.SqlClient;
using static DuoLegend.DatabaseConnection.DbConnection;

namespace DuoLegend.DAO.AdminDAO
{
    public class AdminManagementDAO
    {
        /// <summary>
        /// Insert into the database information about a banned user
        /// </summary>
        /// <param name="userId">The user's unique identifier to be banned</param>
        /// <param name="adminId">The id of the admin performing the ban action</param>
        /// <param name="expirationDate">The expiration date of the ban</param>
        /// <param name="reason">The reason for the ban</param>
        /// <returns>An integer indicating if the insert was successful. (1 = success, 0 = fail)</returns>
        public static int BanUser(int userId, int adminId, DateTime expirationDate, string reason)
        {
            int rowsAffected;
            try
            {
                Connect();

                Cmd.CommandText = "INSERT INTO [BannedUser] (userId, adminId, expirationDate, reason) "
                                    + "Values (@userId, @adminId, @expirationDate, @reason) ";

                Cmd.Parameters.AddWithValue("userId", userId);
                Cmd.Parameters.AddWithValue("adminId", adminId);
                Cmd.Parameters.AddWithValue("expirationDate", expirationDate);
                Cmd.Parameters.AddWithValue("reason", reason);

                rowsAffected = Cmd.ExecuteNonQuery();

            }catch (Exception)
            {
                rowsAffected = 0;
            }
            finally 
            { 
                Disconnect();
            }

            return rowsAffected;
        }

        public static bool DeleteUser(int userId)
        {
            Connect();

            Cmd.CommandText = "UPDATE [User] SET isDeleted=1 WHERE userId=@userId";
            Cmd.Parameters.AddWithValue("@userId", userId);

            SqlDataReader reader = Cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                Disconnect();
                return true;
            }
            else
            {
                reader.Close();
                Disconnect();
                return false;
            }
        }
    }
}