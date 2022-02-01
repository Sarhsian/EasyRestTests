using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace PageObjects
{
    public class ClientCurrentOrdersTab
    {
        protected static IWebDriver driver;

        public ClientCurrentOrdersTab(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private IWebElement CurrentOrdersTab => driver.FindElement(By.XPath("//span[text()='Current Orders']"));
        private IWebElement AllTab => driver.FindElement(By.XPath("//*[@id='root']/main/div/div/div/div[1]/div/header/div/div[2]/div[2]/div/a[1]/span[1]/span"));
        private IWebElement DraftTab => driver.FindElement(By.XPath("/html/body/div/main/div/div/div/div[1]/div/header/div/div[2]/div[2]/div/a[2]/span[1]/span"));
        private IWebElement WaitingForConfirmTab => driver.FindElement(By.XPath("/html/body/div/main/div/div/div/div[1]/div/header/div/div[2]/div[2]/div/a[3]/span[1]/span"));
        private IWebElement AcceptedTab => driver.FindElement(By.XPath("/html/body/div/main/div/div/div/div[1]/div/header/div/div[2]/div[2]/div/a[4]/span[1]/span"));
        private IWebElement AssignedWaiterTab => driver.FindElement(By.XPath("/html/body/div/main/div/div/div/div[1]/div/header/div/div[2]/div[1]/div/a[5]/span[1]/span"));
        private IWebElement InProgressTab => driver.FindElement(By.XPath("/html/body/div/main/div/div/div/div[1]/div/header/div/div[2]/div[1]/div/a[6]/span[1]/span"));
        private IWebElement NextTabButton => driver.FindElement(By.XPath("/html/body/div[1]/main/div/div/div/div[1]/div/header/div/div[2]/button"));
        private IWebElement PrevTabButton => driver.FindElement(By.XPath("/html/body/div[1]/main/div/div/div/div[1]/div/header/div/div[2]/button"));
        private IWebElement OrderInfoArrowDownButton => driver.FindElement(By.XPath("/html/body/div/main/div/div/div/div[1]/div/div/div[1]/div[1]/div[2]"));
        private IWebElement WaitingForConfirmTabDeclineButton => driver.FindElement(By.XPath("//span[text()='Decline']"));
        private IWebElement OrderDeclinedMessage => driver.FindElement(By.XPath("//p[text()='Order declined']"));
        [AllureStep("Click on 'Current Orders' tab")]
        public void ClickCurrentOrdersTab() => CurrentOrdersTab.Click();
        [AllureStep("Click on 'All' tab")]
        public void ClickAllTab() => AllTab.Click();
        [AllureStep("Click on 'Draft' tab")]
        public void ClickDraftTab() => DraftTab.Click();
        [AllureStep("Click on 'Waiting to Confirm' tab")]
        public void ClickWaitingForConfirmTab() => WaitingForConfirmTab.Click();
        [AllureStep("Click on 'Accepted' tab")]
        public void ClickAcceptedTab() => AcceptedTab.Click();
        [AllureStep("Click on 'Assigned Waiter' tab")]
        public void ClickAssignedWaiterTab()
        {
            ClickNextButton();
            AssignedWaiterTab.Click();
        }
        [AllureStep("Click on 'In Progress' tab")]
        public void ClickInProgressTab()
        {
            ClickNextButton();
            InProgressTab.Click();
        }
        [AllureStep("Click on next button near list of tabs")]
        public void ClickNextButton() => NextTabButton.Click();
        [AllureStep("Click on prev button near list of tabs")]
        public void ClickPrevButton() => PrevTabButton.Click();
        [AllureStep("Click on order info, arrow down button")]
        public void ClickOrderInfoArrowDownButton() => OrderInfoArrowDownButton.Click();
        [AllureStep("Click on 'Decline' button in 'Waiting to Confirm' tab")]
        public void ClickWaitingForConfirmDeclineButton() => WaitingForConfirmTabDeclineButton.Click();

        public string GetOrderDeclinedMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Order declined']")));
            return OrderDeclinedMessage.Text;
        }
    }
}
