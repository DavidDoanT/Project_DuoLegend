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
namespace DuoLegendTesting.Tests.SeleniumTests
{
    [TestFixture]
    public class TestLikeUser
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
        public void testLikeUser()
        {
            driver.Navigate().GoToUrl("https://localhost:44316/");
            driver.Manage().Window.Size = new System.Drawing.Size(1054, 808);
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("test@gmail.com");
            driver.FindElement(By.Id("id_password")).Click();
            driver.FindElement(By.Id("id_password")).SendKeys("testtest");
            driver.FindElement(By.CssSelector(".button")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("ZHONGZHE")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("likeButton")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector(".bi-caret-down-fill")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.LinkText("Liked List")).Click();
            Thread.Sleep(1000);
            Assert.That(driver.FindElement(By.CssSelector("td:nth-child(1)")).Text, Is.EqualTo("ZHONGZHE"));
        }
    }
}