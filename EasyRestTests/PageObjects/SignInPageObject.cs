using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace PageObjects
{
    public class SignInPageObject
    {
        protected static IWebDriver driver;
        public SignInPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement BackButton => driver.FindElement(By.TagName("svg"));
        private IWebElement SignUpButton => driver.FindElement(By.XPath("//span[text()='Sign Up']"));
        private IWebElement EmailTextField => driver.FindElement(By.XPath("//input[@name='email']"));
        private IWebElement PasswordTextField => driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement GoogleButton => driver.FindElement(By.XPath("//span[text()='Google']"));
        private IWebElement CreateAccountButton => driver.FindElement(By.XPath("//span[text()='Create account']"));
        private IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement EmailRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Email is required']"));
        private IWebElement PasswordRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Password is required']"));
        private IWebElement EmailIsNotValidErrorMessage => driver.FindElement(By.XPath("//p[text()='Email is not valid']"));
        private IWebElement EmailOrPasswordIsNotValidErrorMessage => driver.FindElement(By.XPath("//p[text()='Email or password is invalid']"));
        public void SendTextToEmailTextField(string text)
        {
            EmailTextField.SendKeys(text);
        }
        public void SendTextToPasswordTextField(string text)
        {
            PasswordTextField.SendKeys(text);
        }
        public void ClickBackButton()
        {
            BackButton.Click();
        }
        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }
        public string GetEmailOrPasswordIsNotValidErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Email or password is invalid']")));
            return EmailOrPasswordIsNotValidErrorMessage.Text;
        }
    }
}
