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
        [TestCase("NnY","Top")]
        [TestCase("wrongIngameName", null)]
        public void TestGetLane(string inGameName, string expResult)
        {
            string result = DuoLegend.DAO.UserDAO.getLane(inGameName, "KR");
            Assert.AreEqual(expResult, result);
        }

        [Test]
        [TestCase("NnY", "")]
        [TestCase("nikefullset", "")]
        [TestCase("wrongIngameName", null)]
        public void TestGetNote(string inGameName, string expResult)
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
        [TestCase("wrongIngameName", null)]
        [TestCase(null, null)]
        public void TestGetEncryptedSummonerId(string inGameName, string expResult)
        {
            string result = DuoLegend.DAO.UserDAO.getEncryptedSummonerId(inGameName, "KR");
            Assert.AreEqual(expResult, result);
        }

        [Test]
        [TestCase("NnY", "LdxKYf7Wc8aju7zkRRcHBJkpBk8HSWbfMMleVEAVNjFj4eoylZjubN9Wlml48K20o3O96pxQd83rfQ")]
        [TestCase("wrongIngameName", null)]
        public void TestGetPuuId(string inGameName, string expResult)
        {
            string result = DuoLegend.DAO.UserDAO.getPuuId(inGameName, "KR");
            Assert.AreEqual(expResult, result);
        }
    }
}
