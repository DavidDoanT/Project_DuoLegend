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
namespace DuoLegendTesting.Tests.SeleniumTests{
[TestFixture]
public class testChat {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void TestChat() {
    driver.Navigate().GoToUrl("https://localhost:44316/");
    driver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
    driver.FindElement(By.LinkText("Login")).Click();
    driver.FindElement(By.Id("email")).Click();
    driver.FindElement(By.Id("email")).SendKeys("test@gmail.com");
    driver.FindElement(By.Id("id_password")).Click();
    driver.FindElement(By.Id("id_password")).SendKeys("testtest");
    driver.FindElement(By.Id("id_password")).SendKeys(Keys.Enter);
    driver.FindElement(By.CssSelector(".bi-caret-down-fill")).Click();
    driver.FindElement(By.LinkText("Chat DashBoard")).Click();
    driver.FindElement(By.Id("messageInput")).Click();
    driver.FindElement(By.Id("messageInput")).SendKeys("test");
    driver.FindElement(By.Id("messageInput")).SendKeys(Keys.Enter);
    driver.FindElement(By.CssSelector(".message:nth-child(5) > .message__body")).Click();
    Assert.That(driver.FindElement(By.CssSelector(".message:nth-child(5) > .message__body")).Text, Is.EqualTo("test"));
    driver.Close();
  }
}
}