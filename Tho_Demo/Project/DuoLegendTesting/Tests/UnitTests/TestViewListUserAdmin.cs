using NUnit.Framework;
using DuoLegend.DAO;
using DuoLegend.ViewModels;
namespace DuoLegendTesting.Tests.UnitTests
{
    [TestFixture]
    public class TestViewListUserAdmin
    {
        public void Setup()
        {
        }
        [OneTimeTearDown]
        public void TearDown()
        {
        }

        [Test]
        public void TestGetAllUser(){
            var  userListResult = UserDAO.getAllUser();

            Assert.IsInstanceOf<System.Collections.Generic.List<UserListViewModel>>(userListResult);
           
        }
    }
}