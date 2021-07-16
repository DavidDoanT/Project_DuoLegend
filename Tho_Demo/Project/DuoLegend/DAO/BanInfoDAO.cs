using System;
using System.Data.SqlClient;
using DuoLegend.DatabaseConnection;
using DuoLegend.Models;

namespace DuoLegend.DAO
{
    public class BanInfoDAO
    {
        /// <summary>
        /// Get the expiration date of the latest ban
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns>The latest ban's expiration date</returns>
        public static DateTime? GetBanExpirationDate(string email)
        {
            DateTime? expirationDate;

            try
            {
                DbConnection.Connect();

                DbConnection.Cmd.CommandText = "SELECT TOP (1) expirationDate "
                                                + "FROM [BannedUser] JOIN [User] "
                                                + "ON [BannedUser].UserId = [User].UserId "
                                                + "WHERE [User].email = @email "
                                                + "ORDER BY [BannedUser].banId DESC";

                DbConnection.Cmd.Parameters.AddWithValue("email", email);
                SqlDataReader dr = DbConnection.Cmd.ExecuteReader();

                if (dr.Read())
                {
                    expirationDate = DateTime.Parse(dr["expirationDate"].ToString());
                    DbConnection.Disconnect();
                    return expirationDate;
                }
            }
            catch (InvalidOperationException ioe)
            {
                string message = ioe.Message;
            }
            finally
            {
                DbConnection.Disconnect();
            }
            return null;
        }

        /// <summary>
        /// Get all information regarding the latest ban
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns>BanInfo</returns>
        public static BanInfo GetBanInfo(int userId)
        {
            BanInfo banInfo = new BanInfo();
            
            try
            {
                DbConnection.Connect();
                DbConnection.Cmd.CommandText = "SELECT TOP (1) userId, expirationDate, reason "
                                                + "FROM [BannedUser] JOIN [Admin] "
                                                + "ON [BannedUser].adminId = [Admin].adminId "
                                                + "WHERE [BannedUser].userId = @userId "
                                                + "ORDER BY [BannedUser].banId DESC";
                DbConnection.Cmd.Parameters.AddWithValue("userId", userId);

                SqlDataReader dr = DbConnection.Cmd.ExecuteReader();

                if (dr.Read())
                {
                    banInfo.UserId = int.Parse(dr["userId"].ToString());
                    banInfo.ExpirationDate = DateTime.Parse(dr["expirationDate"].ToString());
                    banInfo.Reason = dr["reason"].ToString();

                    DbConnection.Disconnect();
                    return banInfo;
                }
            }
            catch (InvalidOperationException ioe)
            {
                string message = ioe.Message;
            }
            finally
            {
                DbConnection.Disconnect();
            }

            return null;
        }
    }
}