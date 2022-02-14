using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;

namespace Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("http://localhost:3000/");            
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        public void ResetDB()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "cmd";
            psi.Arguments = @"/c cd /d D:\Work\Academy\FirstProj\master & initialize_easyrest_db --reset --fill development.ini";
            Process.Start(psi);
        }
    }
}
