using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class LoginedUserPartOfBaseHeaderPageObject
    {
        protected static IWebDriver driver;

        public LoginedUserPartOfBaseHeaderPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement UserMenuButton => driver.FindElement(By.XPath("//*[@id='root']/header/div/div/div/button"));

        public void ClickUserMenuButton() => UserMenuButton.Click();
        public bool UserMenuDisplayed() => UserMenuButton.Displayed;


    }
}
