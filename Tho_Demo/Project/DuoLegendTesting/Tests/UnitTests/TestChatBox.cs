using DuoLegend.DatabaseConnection;
using DuoLegend.Models;
using NUnit.Framework;
using System;

namespace DuoLegendTesting.Tests.UnitTests
{
    [TestFixture]
    public class TestChatBox
    {
        private const int _user1 = 20;
        private const int _user2 = 21;
        private const int _boxChatId=1;
        [SetUp]
        public void Setup()
        {
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "DELETE FROM [boxChat] WHERE user1=@user1 and user2=@user2";
            DbConnection.Cmd.Parameters.AddWithValue("@user1", _user1);
            DbConnection.Cmd.Parameters.AddWithValue("@user2", _user2);
            DbConnection.Cmd.ExecuteNonQuery();

            DbConnection.Cmd.CommandText = "DELETE FROM [boxChatDetail] WHERE boxChatId=@boxChatId";
            DbConnection.Cmd.Parameters.AddWithValue("@boxChatId", _boxChatId);
            DbConnection.Cmd.ExecuteNonQuery();

            DbConnection.Disconnect();
        }

        [Test]
        [TestCase(20,21,1)]
        [TestCase(21,20,1)]
        [TestCase(20,99,0)]
        [TestCase(99,20,0)]
        [TestCase(69,96,0)]
        public void TestGetBoxChatId(int user1, int user2, int expResult)
        {
            int result = DuoLegend.DAO.ChatDAO.getBoxChatId(user1,user2);
            Assert.AreEqual(expResult, result);
        }

        [Test]
        public void TestAddBoxChatSuccess()
        {
            Assert.DoesNotThrow(() => DuoLegend.DAO.ChatDAO.addBoxChat(_user1, _user2));
        }

        [Test]
        public void TestAddChatContentSuccess()
        {
            Assert.DoesNotThrow(() => DuoLegend.DAO.ChatDAO.addChatContent(_boxChatId,"test",_user1));
        }

        [Test]
        [TestCase(20, "nikefullset","KR")]
        [TestCase(99, null, null)]
        public void TestGetInGameNameServerById(int id, string expResultIngameName, string expResultServer)
        {
            string[] result = DuoLegend.DAO.UserDAO.getInGameNameServerById(id);
            Assert.AreEqual(expResultIngameName, result[0]);
            Assert.AreEqual(expResultServer, result[1]);
        }


    }
}
