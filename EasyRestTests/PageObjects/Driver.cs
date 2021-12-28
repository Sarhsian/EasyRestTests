using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class Driver
    {
        protected static IWebDriver driver;

        public Driver(IWebDriver webDriver)
        {
            driver = webDriver;
        }
    }
}
