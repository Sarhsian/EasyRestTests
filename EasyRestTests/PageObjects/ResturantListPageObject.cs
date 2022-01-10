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

        private IWebElement WatchMenuButton => driver.FindElement(By.XPath("//span[text()='Watch Menu']"));
        private IWebElement FirstProductNextButton => driver.FindElement(By.XPath("(//button[contains(@aria-label, 'Add to cart')])[1]"));
        private IWebElement SubmitOrderButton => driver.FindElement(By.XPath("//button/span[text()='Submit order']"));
        private IWebElement SubmitButton => driver.FindElement(By.XPath("//button/span[text()='Submit']"));
        private IWebElement OrderStatusMessage => driver.FindElement(By.XPath("//p[text()='Order status changed to Waiting for confirm']"));

        public void ClickWatchMenuButton()
        {
            WatchMenuButton.Click();
        }
        public void ClickNextButton()
        {
            FirstProductNextButton.Click();
        }
        public void ClickSubmitOrderButton()
        {
            SubmitOrderButton.Click();
        }
        public void ClickSubmitButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button/span[text()='Submit']")));
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
