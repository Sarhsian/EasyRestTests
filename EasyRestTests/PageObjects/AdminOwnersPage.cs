using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    public class AdminOwnersPage
    {
        protected static IWebDriver driver;
        public AdminOwnersPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement UsersButton => driver.FindElement(By.XPath("//span[text()='Users']"));
        private IWebElement OwnersButton => driver.FindElement(By.XPath("//span[text()='Owners']"));
        private IWebElement ModeratorsButton => driver.FindElement(By.XPath("//span[text()='Moderators']"));
        private IWebElement RestaurantsButton => driver.FindElement(By.XPath("//span[text()='Restaurants']"));
        private IWebElement AllOwnersButton => driver.FindElement(By.XPath("//span[starts-with(text(),'All')]"));
        private IWebElement ActiveOwnersButton => driver.FindElement(By.XPath("//span[starts-with(text(),'Active')]"));
        private IWebElement BannedOwnersButton => driver.FindElement(By.XPath("//span[starts-with(text(),'Banned')]"));
        private IWebElement LockButton(int numOfLock) => driver.FindElement(By.XPath("//table//tbody//tr[" + numOfLock + "]//td//button"));
        private IWebElement ActualStatus(int numOfStatus) => driver.FindElement(By.XPath("//table//tbody//tr[" + numOfStatus + "]//td//p"));
        public void ClickLockButton(int numOfLock)
        {
            LockButton(numOfLock).Click();
        }
        public string GetActualStatus(int numOfStatus)
        {
            return ActualStatus(numOfStatus).Text;
        }        
        public void ClickOwnersButton()
        {
            OwnersButton.Click();
        }        
        public string CheckAvailabilityUnbannedOwners(string exceptedText)
        {
            List<IWebElement> allOwnersLockButtons = driver.FindElements(By.XPath("//table//tbody//tr//td//button")).ToList();
            for (int i = 1; i <= allOwnersLockButtons.Count; i++)
            {
                if (string.Equals(GetActualStatus(i),exceptedText))
                {
                    return "good";
                }
            }
            return "bad";
        }
        public int GetOwnerNumber(string exceptedText)
        {
            List<IWebElement> allOwnersLockButtons = driver.FindElements(By.XPath("//table//tbody//tr//td//button")).ToList();            
            int i = 1;
            for (; i <= allOwnersLockButtons.Count; i++)
            {
                if (string.Equals(GetActualStatus(i),exceptedText))
                {
                    return i;
                }
            }
            return 0;
        }       
    }
}