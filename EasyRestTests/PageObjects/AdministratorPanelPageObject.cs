using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class AdministratorPanelPageObject
    {
        protected static IWebDriver driver;
        public AdministratorPanelPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement WaitingForConfirmTabButton => driver.FindElement(By.XPath("//span[text()='Waiting for confirm'][1]"));
        private IWebElement AcceptedTabButton => driver.FindElement(By.XPath("//span[text()='Accepted'][1]"));
        private IWebElement AssignedWaiterButton => driver.FindElement(By.XPath("//span[text()='Assigned waiter'][1]"));
        private IWebElement WaitersTabButton => driver.FindElement(By.XPath("//span[text()='Waiters'][1]"));




        public void ClickWaitingForConfirmTabButton()
        {
            WaitingForConfirmTabButton.Click();
        }

        public void ClickAcceptedTabButton()
        {
            AcceptedTabButton.Click();
        }

        public void ClickAssignedWaiterButton()
        {
            AssignedWaiterButton.Click();
        }

        public void ClickWaitersTabButton()
        {
            WaitersTabButton.Click();
        }

    }
}
