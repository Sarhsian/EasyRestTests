using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:3000/");

        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
