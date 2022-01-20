using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    public class AdminPanelPage
    {
        protected static IWebDriver driver;
        public AdminPanelPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement UsersManagmentPageButton => driver.FindElement(By.XPath("//span[text()='Users']"));
        private IWebElement OwnersManagmentPageButton => driver.FindElement(By.XPath("//span[text()='Owners']"));
        private IWebElement RestaurantsManagmentPageButton => driver.FindElement(By.XPath("//span[text()='Restaurants']"));
        private IWebElement AllRestaurantsListButton => driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'All')]"));
        private IWebElement UnapprovedRestaurantsListButton => driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'Unapproved')]"));
        private IWebElement ApprovedRestaurantsListButton => driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'Approved')]"));
        private IWebElement ArchivedRestaurantsListButton => driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'Archived')]"));
        //Our elements on AdminPanelPage
        public void ClickAllRestaurantsListButton() => AllRestaurantsListButton.Click();
        public void ClickUnapprovedRestaurantsListButton() => UnapprovedRestaurantsListButton.Click();
        public void ClickApprovedRestaurantsListButton() => ApprovedRestaurantsListButton.Click();
        public void ClickArchivedRestaurantsListButton() => ArchivedRestaurantsListButton.Click();
        public void ClickUsersManagmentPageButton() => UsersManagmentPageButton.Click();
        public void ClickOwnersManagmentPageButton() => OwnersManagmentPageButton.Click();
        public void ClickModeratorsManagmentPageButton() => UsersManagmentPageButton.Click();
        public void ClickRestaurantsManagmentPageButton() => RestaurantsManagmentPageButton.Click();
        public int GetRestaurantInfo()
        {
            List<IWebElement> allUsersNames = driver.FindElements(By.XPath("//table//tbody//tr//th")).ToList();
            return allUsersNames.Count;
        }
        public int GetModeratorInfo()
        {
            List<IWebElement> allUsersNames = driver.FindElements(By.XPath("//table//tbody//tr//th")).ToList();
            return allUsersNames.Count;
        }
    }
}