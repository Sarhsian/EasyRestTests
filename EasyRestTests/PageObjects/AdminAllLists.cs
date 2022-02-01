using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    public class AdminAllLists
    {
        protected static IWebDriver driver;
        public AdminAllLists(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement UsersListButton => driver.FindElement(By.XPath("//span[text()='Users']"));
        private IWebElement OwnersListButton => driver.FindElement(By.XPath("//span[text()='Owners']"));
        private IWebElement ActiveTabButton => driver.FindElement(By.XPath("//span[starts-with(text(),'Active')]"));
        private IWebElement BannedTabButton => driver.FindElement(By.XPath("//span[starts-with(text(),'Banned')]"));
        private IWebElement LockButton(int numOfLock) => driver.FindElement(By.XPath("//table//tbody//tr[" + numOfLock + "]//td//button"));
        private IWebElement ActualStatusString(int numOfStatus) => driver.FindElement(By.XPath("//table//tbody//tr[" + numOfStatus + "]//td//p"));
        private IWebElement NameInListString(int numOfName) => driver.FindElement(By.XPath("//table//tbody//tr[" + numOfName + "]//th"));

        [AllureStep("Click on lock button to block user")]
        public void ClickLockButton(int numOfLock) => LockButton(numOfLock).Click();
        [AllureStep("Click on Users list button")]
        public void ClickUsersListButton() => UsersListButton.Click();
        [AllureStep("Click on Owners list button")]
        public void ClickOwnersListButton() => OwnersListButton.Click();
        [AllureStep("Click on Active tab button")]
        public void ClickActiveTabButton() => ActiveTabButton.Click();
        [AllureStep("Click on Banned tab button")]
        public void ClickBannedTabButton() => BannedTabButton.Click();
        [AllureStep("Get actual status by number")]
        public string GetActualStatusByNumber(int numOfStatus)
        {
            return ActualStatusString(numOfStatus).Text;
        }
        [AllureStep("Get name of user by number")]
        public string GetNameByNumber(int numOfName)
        {
            return NameInListString(numOfName).Text;
        }
        [AllureStep("Check for users in the list")]
        public bool CheckAvailabilityAnyUsers()
        {
            List<IWebElement> ListOfLockButtons = driver.FindElements(By.XPath("//table//tbody//tr//td//button")).ToList();
            if (ListOfLockButtons.Count > 0)
            {
                return true;
            }
            else return false;
        }
        [AllureStep("Check availability users with needed status")]
        public bool CheckAvailabilityUsersByStatus(string exceptedText)
        {
            List<IWebElement> ListOfLockButtons = driver.FindElements(By.XPath("//table//tbody//tr//td//button")).ToList();
            for (int i = 1; i <= ListOfLockButtons.Count; i++)
            {
                if (string.Equals(GetActualStatusByNumber(i), exceptedText))
                {
                    return true;
                }
            }
            return false;
        }
        [AllureStep("Get user number with needed status")]
        public int GetUserNumberByStatus(string exceptedText)
        {
            List<IWebElement> ListOfLockButtons = driver.FindElements(By.XPath("//table//tbody//tr//td//button")).ToList();
            int i = 1;
            for (; i <= ListOfLockButtons.Count; i++)
            {
                if (string.Equals(GetActualStatusByNumber(i), exceptedText))
                {
                    return i;
                }
            }
            return 0;
        }
        [AllureStep("Check the name in the list")]
        public bool CheckOnUserName(string ownerName)
        {
            List<IWebElement> ListOfNames = driver.FindElements(By.XPath("//table//tbody//tr//th")).ToList();
            for (int i = 1; i <= ListOfNames.Count; i++)
            {
                if (string.Equals(GetNameByNumber(i), ownerName))
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