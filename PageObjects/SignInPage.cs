using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class SignInPage : BasePage
    {
        public SignInPage(IWebDriver driver) : base(driver)
        {

        }
        private IWebElement btnBack => driver.FindElement(By.TagName("svg"));
        private IWebElement btnSignUp => driver.FindElement(By.XPath("//span[text()='Sign Up']"));
        private IWebElement txtEmail => driver.FindElement(By.XPath("//input[@name='email']"));
        private IWebElement txtPassword => driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement btnGoogle => driver.FindElement(By.XPath("//span[text()='Google']"));
        private IWebElement btnCreateAccount => driver.FindElement(By.XPath("//span[text()='Create account']"));
        private IWebElement btnSubmit => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement emEmailRequired => driver.FindElement(By.XPath("//p[text()='Email is required']"));
        private IWebElement emPasswordRequired => driver.FindElement(By.XPath("//p[text()='Password is required']"));
        private IWebElement emEmailIsNotValid => driver.FindElement(By.XPath("//p[text()='Email is not valid']"));
        private IWebElement emEmailOrPasswordIsNotValid => driver.FindElement(By.XPath("//p[text()='Email or password is invalid']"));





        public void SendTextToEmail(string text) => txtEmail.SendKeys(text);
        public void SendTextToPassword(string text) => txtPassword.SendKeys(text);

        public void ClickBack() => btnBack.Click();
        public void ClickSubmit() => btnSubmit.Click();
        public string GetErrorMessageEmailOrPasswordIsNotValid() => emEmailOrPasswordIsNotValid.Text;

    }
}
