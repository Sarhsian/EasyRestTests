using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class ResturantListPageObject
    {
        protected static IWebDriver driver;

        public ResturantListPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private IWebElement WatchMenuButton => driver.FindElement(By.XPath(""));
        private IWebElement NextButton => driver.FindElement(By.XPath(""));
        private IWebElement SubmitOrderButton => driver.FindElement(By.XPath(""));
        private IWebElement SubmitButton => driver.FindElement(By.XPath(""));
        private IWebElement OrderStatusMessage => driver.FindElement(By.XPath("//p[text()='Order status changed to Waiting for confirm']"));

        public void ClickWatchMenuButton()
        {
            WatchMenuButton.Click();
        }
        public void ClickNextButton()
        {
            NextButton.Click();
        }
        public void ClickSubmitOrderButton()
        {
            SubmitOrderButton.Click();
        }
        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }
        public string GetOrderStatusMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Order status changed to Waiting for confirm']")));
            return OrderStatusMessage.Text;
        }
    }
}
