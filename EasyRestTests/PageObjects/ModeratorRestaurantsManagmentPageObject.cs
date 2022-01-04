using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class ModeratorRestaurantsManagmentPageObject : ModeratorPanelPageObject
    {
        public ModeratorRestaurantsManagmentPageObject(IWebDriver driver) : base(driver)
        {

        }
        private IWebElement AllRestaurantsListButton =>
            driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'All')]"));
        private IWebElement UnapprovedRestaurantsListButton =>
           driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'Unapproved')]"));
        private IWebElement ApprovedRestaurantsListButton =>
           driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'Approved')]"));
        private IWebElement ArchivedRestaurantsListButton =>
           driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'Archived')]"));
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

    }
}
