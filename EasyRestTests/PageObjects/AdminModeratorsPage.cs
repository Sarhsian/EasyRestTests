using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    public class AdminModeratorsPage
    {
        protected static IWebDriver driver;
        public AdminModeratorsPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement UsersButton => driver.FindElement(By.XPath("//span[text()='Users']"));
        private IWebElement OwnersButton => driver.FindElement(By.XPath("//span[text()='Owners']"));
        private IWebElement ModeratorsButton => driver.FindElement(By.XPath("//span[text()='Moderators']"));
        private IWebElement RestaurantsButton => driver.FindElement(By.XPath("//span[text()='Restaurants']"));
        private IWebElement AllModeratorsButton => driver.FindElement(By.XPath("//span[starts-with(text(),'All')]"));
        private IWebElement ActiveModeratorsButton => driver.FindElement(By.XPath("//span[starts-with(text(),'Active')]"));
        private IWebElement BannedModeratorsButton => driver.FindElement(By.XPath("//span[starts-with(text(),'Banned')]"));
        private IWebElement AddModerator => driver.FindElement(By.XPath("//span[text()='Add moderator']"));
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
        public void ClickBannedModeratorsButton()
        {
            BannedModeratorsButton.Click();
        }
        public void ClickModeratorsButton()
        {
            ModeratorsButton.Click();
        }

        public int GetModeratorsNumber(string exceptedText)
        {
            List<IWebElement> allModeratorsLockButtons = driver.FindElements(By.XPath("//table//tbody//tr//td//button")).ToList();
            int i = 1;
            for (; i < allModeratorsLockButtons.Count; i++)
            {
                if (string.Equals(GetActualStatus(i), exceptedText))
                {
                    break;
                }
            }
            return i;
        }
        public int GetModeratorsInfo()
        {
            List<IWebElement> allModeratorsLockButtons = driver.FindElements(By.XPath("//table//tbody//tr//th")).ToList();
            return allModeratorsLockButtons.Count;
        }
    }
}
