using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using NUnit.Allure.Attributes;

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

        [AllureStep("Click all restaurant list tab")]
        public void ClickAllRestaurantsListButton() => AllRestaurantsListButton.Click();
        [AllureStep("Click unapproved restaurant list tab")]
        public void ClickUnapprovedRestaurantsListButton() => UnapprovedRestaurantsListButton.Click();
        [AllureStep("Click approved restaurant list tab")]
        public void ClickApprovedRestaurantsListButton() => ApprovedRestaurantsListButton.Click();
        [AllureStep("Click archived restaurant list tab")]
        public void ClickArchivedRestaurantsListButton() => ArchivedRestaurantsListButton.Click();
        [AllureStep("Click user manegment page button")]
        public void ClickUsersManagmentPageButton() => UsersManagmentPageButton.Click();
        [AllureStep("Click owners manegment page button")]
        public void ClickOwnersManagmentPageButton() => OwnersManagmentPageButton.Click();
        [AllureStep("Click moderator manegment page button")]
        public void ClickModeratorsManagmentPageButton() => UsersManagmentPageButton.Click();
        [AllureStep("Click restaurant manegment page button")]
        public void ClickRestaurantsManagmentPageButton() => RestaurantsManagmentPageButton.Click();
        [AllureStep("Get info about restaurant")]
        public int GetRestaurantInfo()
        {
            List<IWebElement> allUsersNames = driver.FindElements(By.XPath("//table//tbody//tr//th")).ToList();
            return allUsersNames.Count;
        }
        [AllureStep("Get info about moderator")]
        public int GetModeratorInfo()
        {
            List<IWebElement> allUsersNames = driver.FindElements(By.XPath("//table//tbody//tr//th")).ToList();
            return allUsersNames.Count;
        }
    }
}