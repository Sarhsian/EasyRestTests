using OpenQA.Selenium;
using System;

namespace PageObjects
{
    public class BasePage
    {
        protected static IWebDriver driver;

        public BasePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private IWebElement btnLogo => driver.FindElement(By.XPath("//a[text()='Easy-rest']"));
        private IWebElement btnHome => driver.FindElement(By.XPath("//span[text()='Home']"));
        private IWebElement btnRestaurantsList => driver.FindElement(By.XPath("//span[text()='Restaurants List']"));
        private IWebElement btnSignIn => driver.FindElement(By.XPath("//a[@href='/log-in']"));
        private IWebElement btnSignUp => driver.FindElement(By.XPath("//a[@href='/sign-up']"));

        public void ClickLogo() => btnLogo.Click();
        public void ClickHome() => btnHome.Click();
        public void ClickRestaurantsList() => btnRestaurantsList.Click();
        public void ClickSignIn() => btnSignIn.Click();
        public void ClickSignUp() => btnSignUp.Click();
       











    }
}
