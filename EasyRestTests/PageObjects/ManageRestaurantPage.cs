using OpenQA.Selenium;
using System.Linq;
using System.Collections.Generic;
using NUnit.Allure.Attributes;

namespace PageObjects
{
    public class ManageRestaurant
    {
        protected static IWebDriver driver;
        public ManageRestaurant(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement ProfileLogoButton => driver.FindElement(By.XPath("//div[text()='K']"));
        private IWebElement MyRestaurantsButton => driver.FindElement(By.XPath("//a[@href='/profile/restaurants']"));
        private IWebElement DetailsTab => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/11/edit/info']"));
        private IWebElement DetailsForOwnerTab => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/8/edit/info']"));
        private IWebElement MenuesTab => driver.FindElement(By.XPath("//div[@role='button']"));
        private IWebElement CreateMenuTab => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/11/edit/menues/create_menu']"));
        private IWebElement MenuNeagtiveRestaurantTab => driver.FindElement(By.XPath("//div[@role='button']"));
        private IWebElement CreateMenuNeagtiveRestaurantTab => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/12/edit/menues/create_menu']"));
        private IWebElement WaitersTab => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/11/edit/waiters']"));
        private IWebElement WaitersNegativeTab => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/12/edit/waiters']"));
        private IWebElement AdministratorTab => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/11/edit/administrators']"));
        private IWebElement AdministratorNegativeTab => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/12/edit/administrators']"));

        [AllureStep("Click details tab")]
        public void ClickDetailsForOwnerTab() => DetailsForOwnerTab.Click();
        [AllureStep("Click menues tab")]
        public void ClickMenuesTab() => MenuesTab.Click();
        [AllureStep("Click create menu tab ")]
        public void ClickCreateMenuTab() => CreateMenuTab.Click();
        [AllureStep("Click menu tab ")]
        public void ClickMenuNeagtiveRestaurantTab() => MenuNeagtiveRestaurantTab.Click();
        [AllureStep("Click create menu tab")]
        public void ClickCreateMenuNeagtiveRestaurantTab() => CreateMenuNeagtiveRestaurantTab.Click();
        [AllureStep("Click waiter tab")]
        public void ClickWaitersTab() => WaitersTab.Click();
        [AllureStep("Click waiter tab")]
        public void ClickWaitersNegativeTab() => WaitersNegativeTab.Click();
        [AllureStep("Click administrator tab")]
        public void ClickAdministratorTab() => AdministratorTab.Click();
        [AllureStep("Click administrator tab")]
        public void ClickAdministratorNegativeTab() => AdministratorNegativeTab.Click();
        [AllureStep("Click my profile button, which will be go back to our panel")]
        public void ClickProfileLogoButton() => ProfileLogoButton.Click();
        [AllureStep("Click my restaurant tab")]
        public void ClickMyRestaurantsButton() => MyRestaurantsButton.Click();
        public int GetMenuRestaurantInfo()
        {
            List<IWebElement> allUsersNames = driver.FindElements(By.XPath("//div//ul//div//div//a")).ToList();
            return allUsersNames.Count;
        }
    }
}