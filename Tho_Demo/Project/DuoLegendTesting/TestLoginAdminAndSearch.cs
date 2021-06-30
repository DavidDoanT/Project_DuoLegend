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
        [TestCase("BR1")]
        [TestCase("EUN1")]
        [TestCase("EUW1")]
        [TestCase("JP1")]
        [TestCase("LA1")]
        [TestCase("LA2")]
        [TestCase("NA1")]
        [TestCase("OC1")]
        [TestCase("RU")]
        [TestCase("TR1")]
        public void Testget3InGameNameByServer(string server)
        {
            var result = UserDAO.get3InGameNameByServer(server);

            Assert.IsInstanceOf<MainPageViewModel>(result);
        }

        [Test]
        [TestCase("KR",3)]
        [TestCase("BR1",3)]
        [TestCase("EUN1",3)]
        [TestCase("EUW1",3)]
        [TestCase("JP1",3)]
        [TestCase("LA1",3)]
        [TestCase("LA2",3)]
        [TestCase("NA1",3)]
        [TestCase("OC1",3)]
        [TestCase("RU",3)]
        [TestCase("TR1",3)]
        public void Testget3InGameNameByServer2(string server, int expected)
        {
            var result = UserDAO.get3InGameNameByServer(server);

            Assert.AreEqual(expected, result.InGameName.Length);
        }



    }
}