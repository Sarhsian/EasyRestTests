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

        public void ClickCurrentOrdersTab() => CurrentOrdersTab.Click();
        public void ClickAllTab() => AllTab.Click();
        public void ClickDraftTab() => DraftTab.Click();
        public void ClickWaitingForConfirmTab() => WaitingForConfirmTab.Click();
        public void ClickAcceptedTab() => AcceptedTab.Click();
        public void ClickAssignedWaiterTab()
        {
            ClickNextButton();
            AssignedWaiterTab.Click();
        }
        public void ClickInProgressTab()
        {
            ClickNextButton();
            InProgressTab.Click();
        }
        public void ClickNextButton() => NextTabButton.Click();
        public void ClickPrevButton() => PrevTabButton.Click();
        public void ClickOrderInfoArrowDownButton() => OrderInfoArrowDownButton.Click();
        public void ClickWaitingForConfirmDeclineButton() => WaitingForConfirmTabDeclineButton.Click();

        public string GetOrderDeclinedMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Order declined']")));
            return OrderDeclinedMessage.Text;
        }
    }
}
