using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Tests
{
    public class BaseApiTest
    {
        protected IWebDriver driver;
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
