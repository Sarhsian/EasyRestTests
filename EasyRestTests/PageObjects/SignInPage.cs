using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace PageObjects
{
    public class SignInPage
    {
        protected static IWebDriver driver;
        public SignInPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement BackButton => driver.FindElement(By.TagName("svg"));
        private IWebElement EmailTextField => driver.FindElement(By.XPath("//input[@name='email']"));
        private IWebElement PasswordTextField => driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement EmailOrPasswordIsNotValidErrorMessage => driver.FindElement(By.XPath("//p[text()='Email or password is invalid']"));

        public void SignIn(string email, string password)
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            SendTextToEmailTextField(email);
            SendTextToPasswordTextField(password);
            ClickSubmitButton();
        }
        public void SignInAsClient()
        {
            SignIn("katiedoyle@test.com", "1111");
        }
        public void SignInAsOwner()
        {
            SignIn("jasonbrown@test.com", "1111");
        }
        public void SignInAsModerator()
        {
            SignIn("petermoderator@test.com", "1");
        }
        public void SignInAsAdmin()
        {
            SignIn("steveadmin@test.com", "1");
        }
        public void SignInAsAdministrator()
        {
            SignIn("tanyasanchez@test.com", "1");
        }
        public void SignInAsWaiter1()
        {
            SignIn("karenperez@test.com", "1");
        }
        public void SignInAsWaiter2()
        {
            SignIn("heatherdalton@test.com", "1");
        }
        public void SendTextToEmailTextField(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h5[text()='Sign In']")));
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
