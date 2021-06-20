using System;
using DuoLegend.DAO;
using DuoLegend.DatabaseConnection;
using DuoLegend.Models;
using NUnit.Framework;

namespace DuoLegendTesting
{
    public class TestUserDAO
    {

        private User user;
        private string _inGameId = "GCFI2GfeHshL3tzK5MDg5En9yiAKbLdhIL8-NFtFAW_fdwI";
        private string _inGameName = "9614";
        private string _password = "A123456789a";
        private string _server = "KR";
        private string _email = "test@gmail.com";
        private string _id = "GCFI2GfeHshL3tzK5MDg5En9yiAKbLdhIL8-NFtFAW_fdwI";
        private string _accountId = "xXdBAVR0Ve-TN2z_fFm_jSTOhEENYt8jHXYInmrUZeVDSnwjqmA_FHmK";
        private string _puuid = "LZK_z0cBCC0gOFgZ4HZvnibMvtlJV6nJMfKN6LbYSOoIP4e-kKzY0UKYir_QmTD58hsRdfnAkpILVw";
        private bool _isDeleted = false;

        private bool _isUserAdded = false;

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

        [TearDown]
        public void TearDown()
        {
            if(_isUserAdded)
            {
                DbConnection.Connect();
                DbConnection.Cmd.CommandText = "DELETE FROM [User] WHERE inGameId = @inGameId";
                DbConnection.Cmd.Parameters.AddWithValue("inGameId", _inGameId);

                DbConnection.Cmd.ExecuteNonQuery();

                DbConnection.Disconnect();
            }

            
        }

        //Test case success for checklogin
        [Test]
        public void TestCheckLoginSuccess()
        {
            string email = "some@gmail.com";
            string password = "123456";

            bool result = UserDAO.CheckLogin(email, password);

            Assert.IsTrue(result);
        }

        //Test case fail for CheckLogin
        [Test]
        public void TestCheckLoginFail()
        {
            string email = "notanemail";
            string password = "123456";

            bool result = UserDAO.CheckLogin(email, password);

            Assert.IsFalse(result);
        }

        //Test Adding a user with valid information
        [Test]
        public void TestAddUserSuccess()
        {
            Assert.DoesNotThrow(() => UserDAO.addUser(user));
            _isUserAdded = true;
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