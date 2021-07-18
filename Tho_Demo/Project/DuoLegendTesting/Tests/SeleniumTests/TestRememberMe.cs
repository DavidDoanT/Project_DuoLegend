
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
// using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace DuoLegendTesting
{
    [TestFixture]
    public class TestRememberMeTest
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        private ChromeOptions options;

        [SetUp]
        public void SetUp()
        {
            options = new ChromeOptions();
            options.AddArguments("user-data-dir=D:/tmp/");  //Please mannually delete this folder after testing
            options.AddArguments("no-sandbox");

            driver = new ChromeDriver(options);
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void testRememberMe()
        {
            
            Thread.Sleep(200);

            driver.Navigate().GoToUrl("https://localhost:44316/");
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("minhdn@gmail.com");
            driver.FindElement(By.Id("id_password")).SendKeys("123456789");
            driver.FindElement(By.Id("RememberMe")).Click();
            driver.FindElement(By.CssSelector(".button")).Click();
            Thread.Sleep(2000);
            driver.Close();
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://localhost:5001/");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".bi-caret-down-fill")).Click();
            Assert.That(driver.FindElement(By.LinkText("Logout")).Text, Is.EqualTo("Logout"));
        }
    }
}