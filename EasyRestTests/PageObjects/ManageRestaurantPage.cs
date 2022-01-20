using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PageObjects
{
    public class ManageRestaurant
    {
        protected static IWebDriver driver;
        public ManageRestaurant(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        //All our elements where we use on manage panel
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
        //Methods for interaction with our elements
        public void ClickDetailsTab() => DetailsTab.Click();
        public void ClickDetailsForOwnerTab() => DetailsForOwnerTab.Click();
        public void ClickMenuesTab() => MenuesTab.Click();
        public void ClickCreateMenuTab() => CreateMenuTab.Click();
        public void ClickMenuNeagtiveRestaurantTab() => MenuNeagtiveRestaurantTab.Click();
        public void ClickCreateMenuNeagtiveRestaurantTab() => CreateMenuNeagtiveRestaurantTab.Click();
        public void ClickWaitersTab() => WaitersTab.Click();
        public void ClickWaitersNegativeTab() => WaitersNegativeTab.Click();
        public void ClickAdministratorTab() => AdministratorTab.Click();
        public void ClickAdministratorNegativeTab() => AdministratorNegativeTab.Click();
        public void ClickProfileLogoButton() => ProfileLogoButton.Click();
        public void ClickMyRestaurantsButton() => MyRestaurantsButton.Click();
        public int GetMenuRestaurantInfo()
        {
            List<IWebElement> allUsersNames = driver.FindElements(By.XPath("//div//ul//div//div//a")).ToList();
            return allUsersNames.Count;
        }
    }
}