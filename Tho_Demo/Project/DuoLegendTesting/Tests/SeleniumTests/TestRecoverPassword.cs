﻿// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
namespace DuoLegendTesting.Tests.SeleniumTests
{
    [TestFixture]
    public class RecoverPasswordTest
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        public string waitForWindow(int timeout)
        {
            try
            {
                Thread.Sleep(timeout);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            var whNow = ((IReadOnlyCollection<object>)driver.WindowHandles).ToList();
            var whThen = ((IReadOnlyCollection<object>)vars["WindowHandles"]).ToList();
            if (whNow.Count > whThen.Count)
            {
                return whNow.Except(whThen).First().ToString();
            }
            else
            {
                return whNow.First().ToString();
            }
        }
        [Test]
        public void recoverPassword()
        {
            driver.Navigate().GoToUrl("https://localhost:44316/");
            driver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.LinkText("Forgot Password?")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("toantkce150269@fpt.edu.vn");
            driver.FindElement(By.CssSelector(".button")).Click();
            driver.Navigate().GoToUrl("https://mail.google.com/mail/u/1/?ogbl#inbox");
            driver.FindElement(By.CssSelector(".nu > .asa")).Click();
            driver.FindElement(By.CssSelector("#\\3Amd .zF")).Click();
            vars["WindowHandles"] = driver.WindowHandles;
            driver.FindElement(By.LinkText("RESET PASSWORD")).Click();
            vars["win5638"] = waitForWindow(40000);
            driver.SwitchTo().Window(vars["win5638"].ToString());
            driver.FindElement(By.Id("id_password")).Click();
            driver.FindElement(By.Id("id_password")).SendKeys("1234567890");
            driver.FindElement(By.Name("ConfirmPassword")).Click();
            driver.FindElement(By.Name("ConfirmPassword")).SendKeys("1234567890");
            driver.FindElement(By.CssSelector(".button")).Click();
            driver.FindElement(By.LinkText("here")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("toantkce150269@fpt.edu.vn");
            driver.FindElement(By.Id("id_password")).Click();
            driver.FindElement(By.Id("id_password")).SendKeys("1234567890");
            driver.FindElement(By.CssSelector(".button")).Click();
            driver.FindElement(By.CssSelector("#laneOption h3")).Click();
            Assert.That(driver.FindElement(By.CssSelector("#laneOption h3")).Text, Is.EqualTo("Choose duo\\\'s lane"));
        }
    }
}