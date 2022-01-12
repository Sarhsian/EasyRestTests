using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PageObjects
{
    public class AdminUsersPage
    {
        protected static IWebDriver driver;
        public AdminUsersPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement UsersButton => driver.FindElement(By.XPath("//span[text()='Users']"));
        private IWebElement OwnersButton => driver.FindElement(By.XPath("//span[text()='Owners']"));
        private IWebElement ModeratorsButton => driver.FindElement(By.XPath("//span[text()='Moderators']"));
        private IWebElement RestaurantsButton => driver.FindElement(By.XPath("//span[text()='Restaurants']"));
        private IWebElement AllUsersButton => driver.FindElement(By.XPath("//span[starts-with(text(),'All')]"));
        private IWebElement ActiveUsersButton => driver.FindElement(By.XPath("//span[starts-with(text(),'Active')]"));
        private IWebElement BannedUsersButton => driver.FindElement(By.XPath("//span[starts-with(text(),'Banned')]"));
        private IWebElement LockButton(int numOfLock) => driver.FindElement(By.XPath("//table//tbody//tr[" + numOfLock + "]//td//button"));
        private IWebElement ActualStatus(int numOfStatus) => driver.FindElement(By.XPath("//table//tbody//tr[" + numOfStatus + "]//td//p"));
        private IWebElement UserName(int numOfName) => driver.FindElement(By.XPath("//table//tbody//tr[" + numOfName + "]//th"));
        public void ClickLockButton(int numOfLock)
        {
            LockButton(numOfLock).Click();
        }
        public string GetActualStatus(int numOfStatus)
        {
            return ActualStatus(numOfStatus).Text;
        }
        public string GetUserName(int numOfName)
        {
            return UserName(numOfName).Text;
        }
        public void ClickUsersButton()
        {
            UsersButton.Click();
        }
        public void ClickActiveUsersButton()
        {
            ActiveUsersButton.Click();
        }
        public void ClickBannedUsersButton()
        {
            BannedUsersButton.Click();
        }
        public bool CheckAvailabilityAnyUsers()
        {
            List<IWebElement> allUsersLockButtons = driver.FindElements(By.XPath("//table//tbody//tr//td//button")).ToList();
            if (allUsersLockButtons.Count > 0)
            {
                return true;
            }
            else return false;
        }
        public bool CheckAvailabilityUsers(string exceptedText)
        {
            List<IWebElement> allUsersLockButtons = driver.FindElements(By.XPath("//table//tbody//tr//td//button")).ToList();
            for (int i = 1; i <= allUsersLockButtons.Count; i++)
            {
                if (string.Equals(GetActualStatus(i), exceptedText))
                {
                    return true;
                }
            }
            return false;
        }
        public int GetUserNumber(string exceptedText)
        {
            List<IWebElement> allUsersLockButtons = driver.FindElements(By.XPath("//table//tbody//tr//td//button")).ToList();
            int i = 1;
            for (; i <= allUsersLockButtons.Count; i++)
            {
                if (string.Equals(GetActualStatus(i), exceptedText))
                {
                    return i;
                }
            }
            return 0;
        }
        public bool CheckOnUserName(string ownerName)
        {
            List<IWebElement> allUsersLockButtons = driver.FindElements(By.XPath("//table//tbody//tr//th")).ToList();
            for (int i = 1; i <= allUsersLockButtons.Count; i++)
            {
                if (string.Equals(GetUserName(i), ownerName))
                {
                    return true;
                }
            }
            return false;
        }
        public int GetUsersInfo()
        {
            List<IWebElement> allUsersNames = driver.FindElements(By.XPath("//table//tbody//tr//th")).ToList();
            return allUsersNames.Count;
        }
    }
}