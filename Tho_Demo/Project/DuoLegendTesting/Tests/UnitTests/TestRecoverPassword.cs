using DuoLegend.DAO;
using DuoLegend.DatabaseConnection;
using DuoLegend.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoLegendTesting
{
    [TestFixture]
    class TestRecoverPassword
    {
        private User user;
        private const string _inGameId = "bpGpTJNWSyt2mFxgLmj3dse2pamnv9JMD7ZZMHAzcj2k8TU";
        private const string _inGameName = "9614";
        private const string _password = "12345678";
        private const string _server = "KR";
        private const string _email = "trankhanhtoan14052001@gmail.com";
        private const string _accountId = "3gkNii6lkX_A1tCLm7DUyJN5OsGIlyxmvFWr8I64wUnlVhxbjqreLmC9";
        private const string _puuid = "DIntvXhZHRk90K2-OqfKTi7IBdvdgm2f89O3Cmy-_f3wjPyNjhYLAqAEhXdavsUAEj1IHANPVW8OgQ";
        private const string resetPasswordCode = "resetCodeDung";
        [OneTimeSetUp]
        public void Setup()
        {
            user = new User
            {
                Id = _inGameId,
                InGameName = _inGameName,
                Password = _password,
                Server = _server,
                Email = _email,
                AccountId = _accountId,
                Puuid = _puuid
            };
            UserDAO.addUser(user);
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "DELETE FROM [User] WHERE id = @inGameId";
            DbConnection.Cmd.Parameters.AddWithValue("@inGameId", _inGameId);

            DbConnection.Cmd.ExecuteNonQuery();

            DbConnection.Disconnect();
        }
        public static string getResetPasswordCode(string email)
        {
            DbConnection.Connect();
            DbConnection.Cmd.CommandText = "SELECT resetPasswordCode FROM [User] WHERE email =@email";
            DbConnection.Cmd.Parameters.AddWithValue("@email", email);

            if (DbConnection.Dr.Read())
            {
                string code = (string)DbConnection.Dr["resetPasswordCode"];
                DbConnection.Disconnect();
                return code;
            }
            else
            {
                DbConnection.Disconnect();
                return null;
            }
        }
        [Test, Order(1)]
        [TestCase(_email, true)]
        [TestCase("doanngocminh@gmail.com", false)] //test case email ko giong
        public void TestIsDuplicateUser(string email, bool expectedResult)
        {
            bool result = UserDAO.isDuplicateUser(email);

            Assert.AreEqual(result, expectedResult);
        }

        [Test, Order(2)]
        [TestCase(resetPasswordCode, _email)]  //test case email dung
        [TestCase("4trgfera5tae4ter", "emailsai")] //test case email ko co trong database
        public void TestAddResetPasswordCode(string code, string email)
        {
            //UserDAO.addResetPasswordCode(code, email);
            //string expect = getResetPasswordCode(email);
            //Assert.AreEqual(expect, code);
            Assert.DoesNotThrow(() => UserDAO.addResetPasswordCode(code, email));
        }

        [Test, Order(3)]
        [TestCase(resetPasswordCode, true)]
        [TestCase("codesai", false)] //test case code ko giong
        public void TestIsResetPasswordCodeExist(string code, bool expectedResult)
        {
            bool result = UserDAO.isResetPasswordCodeExist(code);
            Assert.AreEqual(result, expectedResult);
        }

        //[Test, Order(4)]
        //[TestCase(resetPasswordCode, "newpassword")]
        //[TestCase("code sai", "newpassword")]
        //public void TestResetPassword(string code, string newPassword)
        //{
        //    Assert.DoesNotThrow(() => UserDAO.resetPassword(code, newPassword));
        //}
    }
}
