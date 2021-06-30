using System;
using DuoLegend.DAO;
using DuoLegend.DatabaseConnection;
using DuoLegend.Models;
using NUnit.Framework;

namespace DuoLegendTesting
{
    [TestFixture]
    public class TestUserDAO
    {

        private User user;
        private const string _inGameId = "GCFI2GfeHshL3tzK5MDg5En9yiAKbLdhIL8-NFtFAW_fdwI";
        private const string _inGameName = "9614";
        private const string _password = "A123456789a";
        private const string _server = "KR";
        private const string _email = "test@gmail.com";
        private const string _id = "GCFI2GfeHshL3tzK5MDg5En9yiAKbLdhIL8-NFtFAW_fdwI";
        private const string _accountId = "xXdBAVR0Ve-TN2z_fFm_jSTOhEENYt8jHXYInmrUZeVDSnwjqmA_FHmK";
        private const string _puuid = "LZK_z0cBCC0gOFgZ4HZvnibMvtlJV6nJMfKN6LbYSOoIP4e-kKzY0UKYir_QmTD58hsRdfnAkpILVw";

        [SetUp]
        public void Setup()
        {
            user = new User
            {
                Id = _inGameId,
                InGameName = _inGameName,
                Password = _password,
                Server = _server,
                Email = _email,
                AccountId = _accountId,
                Puuid = _puuid
            };
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "DELETE FROM [User] WHERE id = @inGameId";
            DbConnection.Cmd.Parameters.AddWithValue("inGameId", _inGameId);

            DbConnection.Cmd.ExecuteNonQuery();

            DbConnection.Disconnect();
        }

        //Test Adding a user with valid information
        [Test, Order(1)]
        public void TestAddUserSuccess()
        {
            Assert.DoesNotThrow(() => UserDAO.addUser(user));
        }

        [Test, Order(2)]
        [TestCase(_email, true)]
        [TestCase("doanngocminh@gmail.com", false)]
        public void TestIsDuplicateUser(string email, bool expectedResult)
        {
            bool result = UserDAO.isDuplicateUser(email);

            Assert.AreEqual(result, expectedResult);
        }

        //Test case success for checklogin
        [Test, Order(3)]
        public void TestCheckLoginSuccess()
        {
            string email = _email;
            string password = _password;

            bool result = UserDAO.CheckLogin(email, password);

            Assert.IsTrue(result);
        }

        //Test case fail for CheckLogin     
        [Test, Order(4)]
        [TestCase("wrongemail@gmail.com", _password)]
        [TestCase(_email, "wrongPassword")]
        [TestCase("wrongemail@gmail.com", "wrongPassword")]
        public void TestCheckLoginFail(string email, string password)
        {
            bool result = UserDAO.CheckLogin(email, password);

            Assert.IsFalse(result);
        }

        //Test Adding a user where one of the field is null
        [Test]
        public void TestAddUserThrowSqlException()
        {
            user.Id = null;
            Assert.Throws<System.Data.SqlClient.SqlException>(() => UserDAO.addUser(user));
        }

    }
}