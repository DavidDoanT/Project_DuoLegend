using DuoLegend.DAO;
using NUnit.Framework;

namespace DuoLegendTesting
{
    public class TestUserDAO
    {

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestCheckLoginSuccess()
        {
            string email = "some@gmail.com";
            string password = "123456";

            bool result = UserDAO.CheckLogin(email, password);

            Assert.IsTrue(result);
        }


    }
}