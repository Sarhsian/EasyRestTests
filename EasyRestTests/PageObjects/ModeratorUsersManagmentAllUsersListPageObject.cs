using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PageObjects
{
    public class ModeratorUsersManagmentAllUsersListPageObject : ModeratorUsersManagmentPageObject
    {
        public ModeratorUsersManagmentAllUsersListPageObject(IWebDriver driver) : base(driver)
        {

        }
        Random rand = new Random();


        private IWebElement SuccessMessage => driver.FindElement(By.XPath("//p[(text()='success')]"));

        public void ClickRandomUsersButtonBan()
        {
            List<IWebElement> allUsersButtonsBan = driver.FindElements(By.CssSelector("button.MuiIconButton-colorSecondary-2552")).ToList();
            allUsersButtonsBan[rand.Next(allUsersButtonsBan.Count - 1)].Click();
        }
        public string GetSuccessMessageText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[(text()='success')]")));
            return SuccessMessage.Text;
        }

        public void ClickRandomUsersButtonUnban()
        {
            List<IWebElement> allUsersButtonsUnban = driver.FindElements(By.CssSelector("button.MuiIconButton-colorPrimary-2551")).ToList();
            allUsersButtonsUnban[rand.Next(allUsersButtonsUnban.Count - 1)].Click();
        }

    }
}
