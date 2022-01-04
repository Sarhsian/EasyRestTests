using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class ModeratorPanelPageObject
    {
        protected static IWebDriver driver;
        public ModeratorPanelPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement RestaurantsManagmentPageButton => driver.FindElement(By.XPath("//a[@href='/moderator/restaurants']"));
        private IWebElement UsersManagmentPageButton => driver.FindElement(By.XPath("//a[@href='/moderator/users']"));
        private IWebElement OwnersManagmentPageButton => driver.FindElement(By.XPath("//a[@href='/moderator/owners']"));
        public void ClickRestaurantsManagmentPageButton()
        {
            RestaurantsManagmentPageButton.Click();
        }
        public void ClickUsersManagmentPageButton()
        {
            UsersManagmentPageButton.Click();
        }
        public void ClickOwnersManagmentPageButton()
        {
            OwnersManagmentPageButton.Click();
        }

    }
}
