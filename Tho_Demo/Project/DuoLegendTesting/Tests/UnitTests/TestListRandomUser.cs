using DuoLegend.DatabaseConnection;
using DuoLegend.Models;
using NUnit.Framework;
using System;

namespace DuoLegendTesting.Tests.UnitTests
{
    [TestFixture]
    public class TestListRandomUser
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
        [TestCase("NnY","TOP")]
        [TestCase("nikefullset","TOP")]
        public void TestGetLaneSuccess(string inGameName, string expResult)
        {
            string result = DuoLegend.DAO.UserDAO.getLane(inGameName, "KR");
            Assert.AreEqual(expResult, result);
        }

        [Test]
        [TestCase("wrongIngameName", null)]
        public void TestGetLaneFail(string inGameName, string expResult)
        {
            string result = DuoLegend.DAO.UserDAO.getLane(inGameName, "KR");
            Assert.AreEqual(expResult, result);
        }

        [Test]
        [TestCase("NnY", "")]
        [TestCase("nikefullset", "")]
        public void TestGetNoteSuccess(string inGameName, string expResult)
        {
            string result = DuoLegend.DAO.UserDAO.getNote(inGameName, "KR");
            Assert.AreEqual(expResult, result);
        }

        [Test]
        [TestCase("wrongIngameName", null)]
        public void TestGetNoteFail(string inGameName, string expResult)
        {
            string result = DuoLegend.DAO.UserDAO.getNote(inGameName, "KR");
            Assert.AreEqual(expResult, result);
        }

        [Test]
        [TestCase("NnY", true)]
        [TestCase("nikefullset", false)]
        [TestCase("wrongIngameName", false)]
        public void TestIsHaveMic(string inGameName, bool expResult)
        {
            bool result = DuoLegend.DAO.UserDAO.isHaveMic(inGameName, "KR");

            Assert.AreEqual(result, expResult);
        }

        [Test]
        [TestCase("NnY", "K8XPBQIIGIS0NocmwH7_PKmgdTgBLwAg369IpBu2tw-iUw")]
        [TestCase("nikefullset", "ZdVJIVYRozdCWyx8nQvSEj7YoXcNaInbPKfFyKUqR8dhiNeYk6c8yfk4og")]
        [TestCase("wrongIngameName", null)]
        public void TestGetEncryptedSummonerId(string inGameName, string expResult)
        {
            string result = DuoLegend.DAO.UserDAO.getEncryptedSummonerId(inGameName, "KR");
            Assert.AreEqual(expResult, result);
        }

        [Test]
        [TestCase("NnY", "LdxKYf7Wc8aju7zkRRcHBJkpBk8HSWbfMMleVEAVNjFj4eoylZjubN9Wlml48K20o3O96pxQd83rfQ")]
        [TestCase("nikefullset", "WenDnr8N_l9dqctKGzEIDjeJCIn4avhXDH3su9fJF3ZuwQzAzZlySz_r-yAfsINIf1vh6S9QlxZcYA")]
        [TestCase("wrongIngameName", null)]
        public void TestGetPuuId(string inGameName, string expResult)
        {
            string result = DuoLegend.DAO.UserDAO.getPuuId(inGameName, "KR");
            Assert.AreEqual(expResult, result);
        }
    }
}
