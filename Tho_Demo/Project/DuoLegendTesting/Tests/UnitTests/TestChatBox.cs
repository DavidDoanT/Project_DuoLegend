using DuoLegend.DatabaseConnection;
using DuoLegend.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DuoLegendTesting.Tests.UnitTests
{
    [TestFixture]
    public class TestChatBox
    {
        private const int _user1 = 20;
        private const int _user2 = 27;
        private const int _boxChatId=7;
        [SetUp]
        public void Setup()
        {
        }

        [OneTimeTearDown]
        public void TearDown()
        {
        }

        [Test, Order(1)]
        [TestCase(_boxChatId, "abc", _user1, "2021-07-18 14:09:51.337", false)]
        public void TestGetListBoxChatDetailById(int boxChatId, string expContent, int expSendFrom, DateTime expTimeSend, bool expIsSeen)
        {
            List<BoxChatDetail> result = DuoLegend.DAO.ChatDAO.GetListBoxChatDetailById(boxChatId);
            Assert.AreEqual(expContent, result[0].Content);
            Assert.AreEqual(expSendFrom, result[0].SendFrom);
            Assert.AreEqual(expTimeSend, result[0].TimeSend);
            Assert.AreEqual(expIsSeen, result[0].IsSeen);
        }

        [Test, Order(2)]
        [TestCase(_boxChatId, 1, "abc", _user1, "2021-07-18 14:09:51.337", false)]
        public void TestGetOldMessageById(int boxChatId, int numberOfMessage, string expContent, int expSendFrom, DateTime expTimeSend, bool expIsSeen)
        {
            List<BoxChatDetail> result = DuoLegend.DAO.ChatDAO.GetOldMessageById(boxChatId, numberOfMessage);
            Assert.AreEqual(expContent, result[0].Content);
            Assert.AreEqual(expSendFrom, result[0].SendFrom);
            Assert.AreEqual(expTimeSend, result[0].TimeSend);
            Assert.AreEqual(expIsSeen, result[0].IsSeen);
        }

        [Test, Order(3)]
        [TestCase(_user1,_user2,_boxChatId)]
        [TestCase(_user2, _user1, _boxChatId)]
        [TestCase(20,99,0)]
        [TestCase(99,20,0)]
        [TestCase(69,96,0)]
        public void TestGetBoxChatId(int user1, int user2, int expResult)
        {
            int result = DuoLegend.DAO.ChatDAO.getBoxChatId(user1,user2);
            Assert.AreEqual(expResult, result);
        }

        [Test, Order(4)]
        public void TestAddBoxChatSuccess()
        {
            Assert.DoesNotThrow(() => DuoLegend.DAO.ChatDAO.addBoxChat(_user1, _user2));
        }

        [Test, Order(5)]
        public void TestAddChatContentSuccess()
        {
            Assert.DoesNotThrow(() => DuoLegend.DAO.ChatDAO.addChatContent(_boxChatId,"test",_user1));
        }

        [Test, Order(6)]
        [TestCase(_user1, "nikefullset","KR")]
        [TestCase(_user2, "Your vaccine", "KR")]
        public void TestGetInGameNameServerById(int id, string expResultIngameName, string expResultServer)
        {
            string[] result = DuoLegend.DAO.UserDAO.getInGameNameServerById(id);
            Assert.AreEqual(expResultIngameName, result[0]);
            Assert.AreEqual(expResultServer, result[1]);
        }

        [Test, Order(7)]
        public void TestChangeSeenStateSuccess()
        {
            Assert.DoesNotThrow(() => DuoLegend.DAO.ChatDAO.changeSeenState(_user2,_boxChatId));
        }


    }
}
