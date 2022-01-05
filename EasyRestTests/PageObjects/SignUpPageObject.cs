using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class SignUpPageObject
    {
        protected static IWebDriver driver;

        public SignUpPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement BackButton => driver.FindElement(By.TagName("svg"));
        private IWebElement SignInButton => driver.FindElement(By.XPath("//span[text()='Sign In']"));
        private IWebElement SignInInsteadButton => driver.FindElement(By.XPath("//span[text()='Sign in instead']"));
        private IWebElement NameTextField => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement EmailTextField => driver.FindElement(By.XPath("//input[@name='email']"));
        private IWebElement PasswordTextField => driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement ConfirmPasswordTextField => driver.FindElement(By.XPath("//input[@name='repeated_password']"));
        private IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement EmailIsNotValidErrorMessage => driver.FindElement(By.XPath("//p[text()='Email is not valid']"));
        private IWebElement PasswordErrorMessage => driver.FindElement(By.XPath("//p[text()='Password must have at least 8 characters']"));
        private IWebElement PasswordMismatchErrorMessage => driver.FindElement(By.XPath("//p[text()='Password mismatch']"));




        public void SendTextToNameTextField(string text)
        {
            NameTextField.SendKeys(text);
        }

        public void SendTextToEmailTextField(string text)
        {
            EmailTextField.SendKeys(text);
        }

        public void SendTextToPasswordTextField(string text)
        {
            PasswordTextField.SendKeys(text);
        }

        public void SendTextToConfirmPasswordTextField(string text)
        {
            ConfirmPasswordTextField.SendKeys(text);
        }

        public void ClickBackButton()
        {
            BackButton.Click();
        }

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }
    }

}
