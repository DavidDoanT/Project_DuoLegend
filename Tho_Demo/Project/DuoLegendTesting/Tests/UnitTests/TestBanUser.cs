using DuoLegend.DAO;
using DuoLegend.DAO.AdminDAO;
using DuoLegend.DatabaseConnection;
using DuoLegend.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoLegendTesting
{
    [TestFixture]
    class TestBanUser
    {
        private User user;
        private const int _userId = 1;
        private const int _adminId = 1;
        private const string _email = "toantkce150269@fpt.edu.vn";
        [OneTimeSetUp]
        public void Setup()
        {
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "DELETE FROM [BannedUser] WHERE userId = @userId";
            DbConnection.Cmd.Parameters.AddWithValue("@userId", _userId);

            DbConnection.Cmd.ExecuteNonQuery();

            DbConnection.Disconnect();
        }
        [Test, Order(1)]
        [TestCase(_userId, _adminId, "2022-05-14", "none")]
        [TestCase(_userId, _adminId, "2021-05-30", "none")]
        public void TestBanUserSuccess(int userId, int adminId, DateTime expirationDate, string reason)
        {
            Assert.DoesNotThrow(() => AdminManagementDAO.BanUser(userId, adminId, expirationDate, reason));

        }

        [Test, Order(2)]
        [TestCase(5, 6, "2001-05-14", "no")]
        public void TestBanUserFail(int userId, int adminId, DateTime expirationDate, string reason)
        {
            int expect = 0;
            int result = AdminManagementDAO.BanUser(userId, adminId, expirationDate, reason);
            Assert.AreEqual(result,expect);
            //Assert.Throws<System.Data.SqlClient.SqlException>(() => AdminManagementDAO.BanUser(userId, adminId, expirationDate, reason));
        }

        [Test, Order(3)]
        [TestCase("2021-05-30")]
        public void TestBanInfoSuccess(DateTime? expect)
        {
            DateTime? result = BanInfoDAO.GetBanExpirationDate(_email);
            Assert.AreEqual(result, expect);
        }
        [Test, Order(4)]
        [TestCase("2021-05-31")]
        [TestCase("20224")]
        [TestCase("2021-01-11")]
        public void TestBanInfoFail(Object expect)
        {
            var result = BanInfoDAO.GetBanExpirationDate(_email);
            Assert.AreNotEqual(result, expect);
        }
    }
}