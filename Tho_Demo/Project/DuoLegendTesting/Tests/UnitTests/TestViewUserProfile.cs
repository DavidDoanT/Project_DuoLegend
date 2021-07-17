using DuoLegend.DatabaseConnection;
using DuoLegend.Models;
using NUnit.Framework;
using System;

namespace DuoLegendTesting.Tests.UnitTests
{
    [TestFixture]
    public class TestViewUserProfile
    {
        [SetUp]
        public void Setup()
        {
        }

        [OneTimeTearDown]
        public void TearDown()
        {
        }

        [Test]
        [TestCase("nikefullset", "KR", "ZdVJIVYRozdCWyx8nQvSEj7YoXcNaInbPKfFyKUqR8dhiNeYk6c8yfk4og")]
        [TestCase("nikefullset", "JP1",null)]
        [TestCase("wrongIngameName","KR",null)]
        [TestCase(null,"KR",null)]
        public void TestGetEncryptedSummonerId(string inGameName, string server, string expResult)
        {
            string result = DuoLegend.DAO.UserDAO.getEncryptedSummonerId(inGameName, server);
            Assert.AreEqual(expResult, result);
        }

        [Test]
        [TestCase("nikefullset", "KR", "https://www.facebook.com/duykhang.dk/")]
        [TestCase("nikefullset", "JP1", null)]
        [TestCase("wrongIngameName", "KR", null)]
        public void TestGetFacebookLink(string inGameName, string server, string expResult)
        {
            string result = DuoLegend.DAO.UserDAO.getFacebookLink(inGameName, server);
            Assert.AreEqual(expResult, result);
        }

        [Test]
        [TestCase("nikefullset", "KR", "Top")]
        [TestCase("nikefullset", "JP1", null)]
        [TestCase("wrongIngameName", "KR", null)]
        public void TestGetLane(string inGameName, string server, string expResult)
        {
            string result = DuoLegend.DAO.UserDAO.getLane(inGameName, server);
            Assert.AreEqual(expResult, result);
        }

        [Test]
        [TestCase("nikefullset", "KR", 20)]
        [TestCase("nikefullset", "JP1", 0)]
        [TestCase("wrongIngameName", "KR", 0)]
        public void TestGetIdByInGameNameServer(string inGameName, string server, int expResult)
        {
            int result = DuoLegend.DAO.UserDAO.getIdByInGameNameServer(inGameName, server);
            Assert.AreEqual(expResult, result);
        }

        [Test]
        [TestCase("nikefullset", "KR", "WenDnr8N_l9dqctKGzEIDjeJCIn4avhXDH3su9fJF3ZuwQzAzZlySz_r-yAfsINIf1vh6S9QlxZcYA")]
        [TestCase("nikefullset", "JP1", null)]
        [TestCase("wrongIngameName", "KR", null)]
        public void TestGetPuuId(string inGameName, string server, string expResult)
        {
            string result = DuoLegend.DAO.UserDAO.getPuuId(inGameName, server);
            Assert.AreEqual(expResult, result);
        }

        [Test]
        [TestCase(20, 21, true)]
        [TestCase(20, 22, false)]
        [TestCase(21, 20, false)]
        [TestCase(null, 21, false)]
        [TestCase(20, null, false)]
        [TestCase(null, null, false)]
        public void TestCheckLiked(int likerId, int userId, bool expResult)
        {
            bool result = DuoLegend.DAO.ProfileDAO.checkLiked(likerId, userId);
            Assert.AreEqual(expResult, result);
        }
    }
}
