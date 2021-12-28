using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class UnloginedUserPartOfBaseHeader : BaseHeaderPageObject
    {
        public UnloginedUserPartOfBaseHeader(IWebDriver driver) : base(driver)
        {

        }
        private IWebElement SignInButton => driver.FindElement(By.XPath("//a[@href='/log-in']"));
        private IWebElement SignUpButton => driver.FindElement(By.XPath("//a[@href='/sign-up']"));

        public void ClickSignInButton() => SignInButton.Click();

        public void ClickSignUpButton() => SignUpButton.Click();
    }
}
