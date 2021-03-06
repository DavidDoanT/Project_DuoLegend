// Generated by Selenium IDE
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
[TestFixture]
public class TestRating
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
    [Test]
    public void untitled()
    {
        driver.Navigate().GoToUrl("https://localhost:44316/");
        driver.Manage().Window.Size = new System.Drawing.Size(1552, 840);
        driver.FindElement(By.LinkText("Login")).Click();
        driver.FindElement(By.Id("email")).Click();
        driver.FindElement(By.Id("email")).SendKeys("tieuanhtho@gmail.com");
        driver.FindElement(By.Id("id_password")).Click();
        driver.FindElement(By.Id("id_password")).SendKeys("test123456");
        driver.FindElement(By.Id("id_password")).SendKeys(Keys.Enter);
        driver.FindElement(By.CssSelector("tr:nth-child(2) > .ingame-name")).Click();
        driver.FindElement(By.LinkText("iRabit")).Click();
        driver.FindElement(By.CssSelector(".ProfileAction > button:nth-child(2)")).Click();
        {
            var element = driver.FindElement(By.CssSelector(".ProfileAction > button:nth-child(2)"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Perform();
        }
        {
            var element = driver.FindElement(By.TagName("body"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(element, 0, 0).Perform();
        }
        driver.FindElement(By.CssSelector(".SkillScore > label:nth-child(4)")).Click();
        driver.FindElement(By.CssSelector(".BehaviorScore > label:nth-child(2)")).Click();
        driver.FindElement(By.Name("Comment")).Click();
        driver.FindElement(By.Name("Comment")).SendKeys("test rating");
        driver.FindElement(By.CssSelector(".btn-grad")).Click();
        driver.FindElement(By.CssSelector("p")).Click();
        Assert.That(driver.FindElement(By.CssSelector("p")).Text, Is.EqualTo("Comment: test rating"));
    }
}
