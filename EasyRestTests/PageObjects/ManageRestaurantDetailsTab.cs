using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace PageObjects
{
    public class ManageRestaurantDetailsTab
    {
        protected static IWebDriver driver;
        public ManageRestaurantDetailsTab(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement RestaurantName => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement RestaurantAddress => driver.FindElement(By.XPath("//input[@name='address']"));
        private IWebElement EditInformationButton => driver.FindElement(By.XPath("//button[@title='Edit Information']"));
        private IWebElement RestaurantNameTextField => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement RestaurantAddressTextField => driver.FindElement(By.XPath("//input[@name='address']"));
        private IWebElement RestaurantPhoneTextField => driver.FindElement(By.XPath("//input[@name='phone']"));
        private IWebElement RestaurantDescriptionTextField => driver.FindElement(By.XPath("//textarea[@name='description']"));
        private IWebElement UpdateNewDetailsAboutRestaurantButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement RestaurantNameCannotBeEmptyErrorMessage => driver.FindElement(By.XPath("//p[text()='Restaurant name cannot be empty']"));
        private IWebElement RestaurantAddressCannotBeEmptyErrorMessage => driver.FindElement(By.XPath("//p[text()='Restaurant address cannot be empty']"));
        [AllureStep("Fill restaurant name")]
        public void SendRestaurantNameTextField(string text) => RestaurantNameTextField.SendKeys(text);
        [AllureStep("Clear restaurant name")]
        public void ClearRestaurantName()
        {
            RestaurantName.Click();
            RestaurantName.SendKeys(Keys.LeftControl + "A");
            RestaurantName.SendKeys(Keys.Backspace);
        }
        [AllureStep("Fill restaurant address")]
        public void SendRestaurantAddressTextField(string text) => RestaurantAddressTextField.SendKeys(text);
        [AllureStep("Fill restaurant address")]
        public void ClearRestaurantAddress()
        {
            RestaurantAddress.Click();
            RestaurantAddress.SendKeys(Keys.LeftControl + "A");
            RestaurantAddress.SendKeys(Keys.Backspace);
        }
        [AllureStep("Edit ifno about restaurant button, which will be open additional details tab")]
        public void ClickEditInformationButton() => EditInformationButton.Click();
        [AllureStep("Click update details button")]
        public void ClickUpdateNewDetailsAboutRestaurantButton() => UpdateNewDetailsAboutRestaurantButton.Click();
        [AllureStep("Fill restaurant phone number")]
        public void SendRestaurantPhoneTextField(string text) => RestaurantPhoneTextField.SendKeys(text);
        [AllureStep("Fill restaurant description")]
        public void SendRestaurantDescriptionTextField(string text) => RestaurantDescriptionTextField.SendKeys(text);
        public string GetRestaurantNameCannotBeEmptyErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Restaurant name cannot be empty']")));
            return RestaurantNameCannotBeEmptyErrorMessage.Text;
        }
        public string GetRestaurantAddressCannotBeEmptyErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Restaurant address cannot be empty']")));
            return RestaurantAddressCannotBeEmptyErrorMessage.Text;
        }
    }
}