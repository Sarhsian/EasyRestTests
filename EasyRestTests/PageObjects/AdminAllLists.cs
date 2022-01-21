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
        
        public void ClickLockButton(int numOfLock) => LockButton(numOfLock).Click();
        public void ClickUsersListButton() => UsersListButton.Click();
        public void ClickOwnersListButton() => OwnersListButton.Click();
        public void ClickActiveTabButton() => ActiveTabButton.Click();
        public void ClickBannedTabButton() => BannedTabButton.Click();
        public string GetActualStatusByNumber(int numOfStatus)
        {
            return ActualStatusString(numOfStatus).Text;
        }
        public string GetNameByNumber(int numOfName)
        {
            return NameInListString(numOfName).Text;
        }        
        public bool CheckAvailabilityAnyUsers()
        {
            List<IWebElement> ListOfLockButtons = driver.FindElements(By.XPath("//table//tbody//tr//td//button")).ToList();
            if (ListOfLockButtons.Count > 0)
            {
                return true;
            }
            else return false;
        }
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
        public int GetUserNumberByName(string exceptedText)
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