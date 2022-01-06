using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class ProfileOrderHistoryPageObject
    {
        protected static IWebDriver driver;

        public ProfileOrderHistoryPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private IWebElement OrderHistoryTab => driver.FindElement(By.XPath(""));
        private IWebElement AllTab => driver.FindElement(By.XPath(""));
        private IWebElement HistoryTab => driver.FindElement(By.XPath(""));
        private IWebElement DeclinedTab => driver.FindElement(By.XPath(""));
        private IWebElement RemovedTab => driver.FindElement(By.XPath(""));
        private IWebElement FailedTab => driver.FindElement(By.XPath(""));
        private IWebElement FirstOrderInfoArrowDownButton => driver.FindElement(By.XPath("/html/body/div/main/div/div/div/div[1]/div/div/div[1]/div[1]/div[2]"));
        private IWebElement ReorderButton => driver.FindElement(By.XPath(""));
        private IWebElement SubmitButton => driver.FindElement(By.XPath("//span[text()='Submit']"));
        private IWebElement CancelButton => driver.FindElement(By.XPath("//span[text()='Cancel']"));
        private IWebElement OrderStatusMessage => driver.FindElement(By.XPath("//p[text()='Order status changed to Waiting for confirm']"));
        
        public void ClickOrderHistoryTab()
        {
            OrderHistoryTab.Click();
        }
        public void ClickAllTab()
        {
            AllTab.Click();
        }
        public void ClickHiscotyTab()
        {
            HistoryTab.Click();
        }
        public void ClickDeclinedTab()
        {
            DeclinedTab.Click();
        }
        public void ClickRemovedTab()
        {
            RemovedTab.Click();
        }
        public void ClickFailedTab()
        {
            FailedTab.Click();
        }
        public void FirstOrderInfoArrowDownButtonClick()
        {
            FirstOrderInfoArrowDownButton.Click();
        }
        public void ReorderButtonClick()
        {
            ReorderButton.Click();
        }
        public void SubmitButtonClick()
        {
            SubmitButton.Click();
        }
        public void CancelButtonClick()
        {
            CancelButton.Click();
        }

        public string GetOrderDeclinedMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Order status changed to Waiting for confirm']")));
            return OrderStatusMessage.Text;
        }

    }
}
