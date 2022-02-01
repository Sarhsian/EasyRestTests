using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace PageObjects
{
    public class ClientOrderHistoryTab
    {
        protected static IWebDriver driver;

        public ClientOrderHistoryTab(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private IWebElement OrderHistoryTab => driver.FindElement(By.XPath("//span[text()='Order History']"));
        private IWebElement AllTab => driver.FindElement(By.XPath("//span[contains(text(), 'All')]"));
        private IWebElement HistoryTab => driver.FindElement(By.XPath("//span[contains(text(), 'History ')]"));
        private IWebElement DeclinedTab => driver.FindElement(By.XPath("//span[contains(text(), 'Declined')]"));
        private IWebElement RemovedTab => driver.FindElement(By.XPath("//span[contains(text(), 'Removed')]"));
        private IWebElement FailedTab => driver.FindElement(By.XPath("//span[contains(text(), 'Failed')]"));
        private IWebElement FirstOrderInfoArrowDownButton => driver.FindElement(By.XPath("/html/body/div/main/div/div/div/div[1]/div/div/div[1]/div[1]/div[2]"));
        private IWebElement ReorderButton => driver.FindElement(By.XPath("//button/span[text()='Reorder']"));
        private IWebElement SubmitButton => driver.FindElement(By.XPath("//button/span[text()='Submit']"));
        private IWebElement CancelButton => driver.FindElement(By.XPath("//span[text()='Cancel']"));
        private IWebElement OrderStatusMessage => driver.FindElement(By.XPath("//p[text()='Order status changed to Waiting for confirm']"));
        [AllureStep("Click on 'Order History' tab")]
        public void ClickOrderHistoryTab() => OrderHistoryTab.Click();
        [AllureStep("Click on 'All' tab")]
        public void ClickAllTab() => AllTab.Click();
        [AllureStep("Click on 'History' tab")]
        public void ClickHistotyTab() => HistoryTab.Click();
        [AllureStep("Click on 'Declined' tab")]
        public void ClickDeclinedTab() => DeclinedTab.Click();
        [AllureStep("Click on 'Removed' tab")]
        public void ClickRemovedTab() => RemovedTab.Click();
        [AllureStep("Click on 'Failed' tab")]
        public void ClickFailedTab() => FailedTab.Click();
        [AllureStep("Click on First order info, Arrow down button")]
        public void FirstOrderInfoArrowDownButtonClick() => FirstOrderInfoArrowDownButton.Click();
        [AllureStep("Click on 'Reorder' button")]
        public void ReorderButtonClick() => ReorderButton.Click();
        [AllureStep("Click on 'Submit' button ")]
        public void SubmitButtonClick()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button/span[text()='Submit']")));
            SubmitButton.Click();
        }
        [AllureStep("Click on 'Cancel' button")]
        public void CancelButtonClick() => CancelButton.Click();
        public string GetOrderStatusMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Order status changed to Waiting for confirm']")));
            return OrderStatusMessage.Text;
        }
    }
}
