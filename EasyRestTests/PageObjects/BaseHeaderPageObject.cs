using OpenQA.Selenium;
using System;

namespace PageObjects
{
    public class BaseHeaderPageObject
    {
        protected static IWebDriver driver;
        public BaseHeaderPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement LogoButton => driver.FindElement(By.XPath("//a[text()='Easy-rest']"));
        private IWebElement HomeButton => driver.FindElement(By.XPath("//span[text()='Home']"));
        private IWebElement RestaurantsListButton => driver.FindElement(By.XPath("//span[text()='Restaurants List']"));
        public void ClickLogoButton()
        {
            LogoButton.Click();
        }
        public void ClickHomeButton()
        {
            HomeButton.Click();
        }
        public void ClickRestaurantsListButton()
        {
            RestaurantsListButton.Click();
        }
    }
}
