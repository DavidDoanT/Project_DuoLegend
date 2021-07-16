using DuoLegend.DAO;
using DuoLegend.DatabaseConnection;
using DuoLegend.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoLegendTesting.Tests.UnitTests
{
    [TestFixture]
    class TestUpdateUser
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
        [Test]
        [TestCase("rose","BR1","Top", "test note")]
        public void TestUpdateSuccess(string inGameName, string server, string Lane, string note)
        {
            UserDAO.addUser(user);
            user.InGameName = inGameName;
            user.Server = server;
            user.Lane = Lane;
            user.Note = note;
            Assert.IsTrue(UserDAO.Update(user, user.Email));
        }
    }
}
