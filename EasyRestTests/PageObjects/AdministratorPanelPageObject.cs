﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
        private IWebElement ArrowDownButton(int num) => driver.FindElement(By.XPath("(//div[contains(@class,'MuiButtonBase')]//span[contains(@class,'MuiIconButton')])[" + num + "]"));
        private IWebElement CheckWorking => driver.FindElement(By.XPath("//div[contains(@class,'MuiExpansionPanel-expanded')]//h6"));
        private IWebElement AcceptedMessage => driver.FindElement(By.XPath("//p[contains(text(),'Accepted')]"));
        private IWebElement AssignedMessage => driver.FindElement(By.XPath("//p[contains(text(),'Assigned')]"));
        private IWebElement AcceptButton => driver.FindElement(By.XPath("(//span[text()='Accept'])[1]"));
        private IWebElement AssignButton => driver.FindElement(By.XPath("(//span[text()='Assign'])[1]"));
        private IWebElement FirstWaiterButton => driver.FindElement(By.XPath("//input[@value='42'][1]"));
        private IWebElement ArrowDownSubButton(int num) => driver.FindElement(By.XPath("(//div[contains(@class,'MuiGrid')]//div//div//span[contains(@class,'MuiIcon')])["+num+"]"));

        public void ClickWaitingForConfirmTabButton()
        {
            WaitingForConfirmTabButton.Click();
        }
        public void ClickFirstWaiterButton()
        {
            FirstWaiterButton.Click();
        }
        public void ClickAcceptedTabButton()
        {
            AcceptedTabButton.Click();
        }
        public void ClickAcceptButton()
        {
            AcceptButton.Click();
        }
        public void ClickAssignButton()
        {
            AssignButton.Click();
        }
        public void ClickAssignedWaiterButton()
        {
            AssignedWaiterButton.Click();
        }
        public void ClickWaitersTabButton()
        {
            WaitersTabButton.Click();
        }
        public void ClickArrowDownButton(int num)
        {
            ArrowDownButton(num).Click();
        }
        public void ClickArrowDownSubButton(int num)
        {
            ArrowDownSubButton(num).Click();
        }
        public string GetOrderInfo()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'MuiExpansionPanel-expanded')]//h6")));
            return CheckWorking.Text;
        }
        public string GetApprovedMessageText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[contains(text(),'Accepted')]")));
            return AcceptedMessage.Text;
        }
        public string GetAssignedMessageText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[contains(text(),'Assigned')]")));
            return AssignedMessage.Text;
        }
    }
}
