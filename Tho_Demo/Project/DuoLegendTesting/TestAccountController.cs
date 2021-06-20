using DuoLegend.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace DuoLegendTesting
{
    public class Tests
    {
        private AccountController _controller;
        [SetUp]
        public void Setup()
        {
            _controller = new AccountController();
        }

        [Test]
        public void Example()
        {
            string expectedIndex = "Login";


            var result = _controller.Login() as ViewResult;

            Assert.AreEqual(expectedIndex, result.ViewName);

        }
    }
}