using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuoLegend.DAO;
using DuoLegend.DatabaseConnection;
using DuoLegend.Models;
using NUnit.Framework;

namespace DuoLegendTesting.Tests.UnitTests
{
    [TestFixture]
    class TestRateUser
    {
        private const int _id1 = 1;
        private const int _id2 = 2;

        [OneTimeTearDown]
        public void TearDown()
        {
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "DELETE FROM [Rating] WHERE raterId = @id1 and userId=@id2 ";
            DbConnection.Cmd.Parameters.AddWithValue("@id1", _id1);
            DbConnection.Cmd.Parameters.AddWithValue("@id2", _id2);
            DbConnection.Cmd.ExecuteNonQuery();
            DbConnection.Disconnect();
        }

        [TestCase(1,1,"test")]
        [TestCase(5,5,"test")]
        public void TestAddRate(int skillScore, int behaviourScore, string commnent)
        {
            Rating rate = new Rating();
            rate.SkillScore = skillScore;
            rate.BehaviorScore = behaviourScore;
            rate.Comment = commnent;
            rate.RaterId = _id1;
            rate.UserId = _id2;
            Assert.IsTrue(ProfileDAO.addRating(rate));
        }

        [TestCase(1, 1, "test")]
        public void TestAddRateDuplicate(int skillScore, int behaviourScore, string commnent)
        {
            Rating rate = new Rating();
            rate.SkillScore = skillScore;
            rate.BehaviorScore = behaviourScore;
            rate.Comment = commnent;
            rate.RaterId = _id1;
            rate.UserId = _id2;
            ProfileDAO.addRating(rate);
            Assert.IsFalse(ProfileDAO.addRating(rate));
        }
        [TestCase]
        public void testAddRateDuplicateId()
        {
            Rating rate = new Rating();
            rate.SkillScore = 1;
            rate.BehaviorScore = 1;
            rate.Comment = "test";
            rate.RaterId = _id1;
            rate.UserId = _id1;
            ProfileDAO.addRating(rate);
            Assert.IsFalse(ProfileDAO.addRating(rate));
        }

    }
}
