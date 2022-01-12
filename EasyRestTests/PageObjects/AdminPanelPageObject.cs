using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class AdminPanelPageObject
    {
        protected static IWebDriver driver;
        public AdminPanelPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement UsersManagmentPageButton => driver.FindElement(By.XPath("//span[text()='Users']"));
        private IWebElement OwnersManagmentPageButton => driver.FindElement(By.XPath("//span[text()='Owners']"));
        private IWebElement ModeratorsManagmentPageButton => driver.FindElement(By.XPath("//span[text()='Moderators']"));
        private IWebElement RestaurantsManagmentPageButton => driver.FindElement(By.XPath("//span[text()='Restaurants']"));
        private IWebElement AllRestaurantsListButton => driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'All')]"));
        private IWebElement UnapprovedRestaurantsListButton => driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'Unapproved')]"));
        private IWebElement ApprovedRestaurantsListButton => driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'Approved')]"));
        private IWebElement ArchivedRestaurantsListButton => driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'Archived')]"));

        

        public void ClickAllRestaurantsListButton()
        {
            AllRestaurantsListButton.Click();
        }
        public void ClickUnapprovedRestaurantsListButton()
        {
            UnapprovedRestaurantsListButton.Click();
        }
        public void ClickApprovedRestaurantsListButton()
        {
            ApprovedRestaurantsListButton.Click();
        }
        public void ClickArchivedRestaurantsListButton()
        {
            ArchivedRestaurantsListButton.Click();
        }
        public void ClickUsersManagmentPageButton()
        {
            UsersManagmentPageButton.Click();
        }

        public void ClickOwnersManagmentPageButton()
        {
            OwnersManagmentPageButton.Click();
        }

        public void ClickModeratorsManagmentPageButton()
        {
            UsersManagmentPageButton.Click();
        }

        public void ClickRestaurantsManagmentPageButton()
        {
            RestaurantsManagmentPageButton.Click();
        }

    }
}
