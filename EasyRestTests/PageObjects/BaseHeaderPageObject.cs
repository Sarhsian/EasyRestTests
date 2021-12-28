using OpenQA.Selenium;
using System;

namespace PageObjects
{
    public class BaseHeaderPageObject : Driver
    {
        

        public BaseHeaderPageObject(IWebDriver driver) : base(driver)
        {
            
        }

        private IWebElement LogoButton => driver.FindElement(By.XPath("//a[text()='Easy-rest']"));
        private IWebElement HomeButton => driver.FindElement(By.XPath("//span[text()='Home']"));
        private IWebElement RestaurantsListButton => driver.FindElement(By.XPath("//span[text()='Restaurants List']"));
        

        public void ClickLogoButton() => LogoButton.Click();

        public void ClickHomeButton() => HomeButton.Click();

        public void ClickRestaurantsListButton() => RestaurantsListButton.Click();

        
    }
}
