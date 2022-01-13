using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace PageObjects
{
    public class NegativeAdminModeratorCreatePageObject
    {
        protected static IWebDriver driver;

        public NegativeAdminModeratorCreatePageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement NameTextField => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement EmailTextField => driver.FindElement(By.XPath("//input[@name='email']"));
        private IWebElement PasswordTextField => driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement ConfirmPasswordTextField => driver.FindElement(By.XPath("//input[@name='repeated_password']"));
        private IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement CancelButton => driver.FindElement(By.XPath("//span[text()='Cancel']"));
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

        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

        public void ClickSubmitButton()
        {
            SubmitButton.Click();
        }
        public string GetEmailIsNotValidErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Email is not valid']")));
            return EmailIsNotValidErrorMessage.Text;
        }
        public string GetPasswordErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Password must have at least 8 characters']")));
            return PasswordErrorMessage.Text;
        }
        public string GetPasswordMismatchErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Password mismatch']")));
            return PasswordMismatchErrorMessage.Text;
        }
    }

}
