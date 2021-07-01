using System;
using DuoLegend.Models;
using NUnit.Framework;
using DuoLegend.DAO;
using DuoLegend.ViewModels;

namespace DuoLegendTesting
{

    [TestFixture]
    public class TestLoginAdminAndSearch
    {
        private const string _adminPassword = "admin";
        private const string _email = "admin@gmail.com";

        private MainPageViewModel ViewModeluser1;


        [SetUp]
        public void Setup()
        {

        }

        [OneTimeTearDown]
        public void TearDown()
        {

        }

        [Test]
        public void TestLoginAdminSuccess()
        {
            string email = _email;
            string password = _adminPassword;

            bool result = DuoLegend.DAO.AdminDAO.AdminLoginDAO.Login(email, password);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("test@gmail.com", _adminPassword)]
        [TestCase(_email, "test")]
        [TestCase("test@gmail.com", "test")]
        public void TestLoginAdminFailed(string email, string password)
        {
            bool result = DuoLegend.DAO.AdminDAO.AdminLoginDAO.Login(email, password);

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("KR")]
        public void Testget3InGameNameByServer(string server)
        {
            var result = UserDAO.get3InGameNameByServer(server);

            Assert.IsInstanceOf<MainPageViewModel>(result);
        }

        [Test]
        [TestCase("KR", "KR")]
        public void Testget3InGameNameByServer3(string server, string expected)
        {
            var result = UserDAO.get3InGameNameByServer(server);
            

            Assert.AreSame(expected, result.Server);
        }



        [Test]
        [TestCase("KR", 3)]
        public void Testget3InGameNameByServer2(string server, int expected)
        {
            var result = UserDAO.get3InGameNameByServer(server);

            Assert.AreEqual(expected, result.InGameName.Length);
        }



    }
}