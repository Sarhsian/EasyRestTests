using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    public class ClientProfileMyRestaurantTab
    {
        protected static IWebDriver driver;

        public ClientProfileMyRestaurantTab(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private IWebElement MyRestaurantTab => driver.FindElement(By.XPath("//span[text()='My Restaurants']"));
        private IWebElement AddRestaurantButton => driver.FindElement(By.XPath("//button[@title='Add restaurant']"));
        private IWebElement NameTextField => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement AddressTextField => driver.FindElement(By.XPath("//input[@name='address']"));
        private IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement CancelButton => driver.FindElement(By.XPath("//span[text()='Cancel']"));
        private IWebElement DetailsAboutRestaurantButton => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/11']"));
        private IWebElement MoreInfoAboutRestaurantButton => driver.FindElement(By.XPath("//button[@aria-label='More']//span[1]"));
        private IWebElement MoreInfoAboutNegativeRestaurantButton => driver.FindElement(By.XPath("(//button[@aria-label='More'])[2]"));
        private IWebElement ArchiveButton => driver.FindElement(By.XPath("//li[@role='menuitem']"));
        private IWebElement ManageButton => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/11/edit/info']"));
        private IWebElement ManageNegativeRestaurantButton => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/12/edit/info']"));
        private IWebElement ManageButtonForOwner => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/8/edit/info']"));
        private IWebElement CreateRestaurantNameIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Name is required']"));
        private IWebElement CreateRestaurantAddressIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Address is required']"));

        public void SendTextToNameTextField(string text) => NameTextField.SendKeys(text);
        public void SendTextToAddressTextField(string text) => AddressTextField.SendKeys(text);
        public void ClickMyRestaurantTab() => MyRestaurantTab.Click();
        public void ClickAddRestaurantButton() => AddRestaurantButton.Click();
        public void ClickCancelButton() => CancelButton.Click();
        public void ClickDetailsAboutRestaurantButton() => DetailsAboutRestaurantButton.Click();
        public void ClickManageButton() => ManageButton.Click();
        public void ClickManageButtonForOwner() => ManageButtonForOwner.Click();
        public void ClickManageNegativeRestaurantButton() => ManageNegativeRestaurantButton.Click();
        public void ClickArchiveButton() => ArchiveButton.Click();
        public void ClickSubmitButton() => SubmitButton.Click();
        public void ClickMoreInfoAboutRestaurantButton() => MoreInfoAboutRestaurantButton.Click();
        public void ClickMoreInfoAboutNegativeRestaurantButton() => MoreInfoAboutNegativeRestaurantButton.Click();
        public string GetCreateRestaurantNameIsRequiredErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Name is required']")));
            return CreateRestaurantNameIsRequiredErrorMessage.Text;
        }
        public string GetCreateRestaurantAddressIsRequiredErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Address is required']")));
            return CreateRestaurantAddressIsRequiredErrorMessage.Text;
        }
        public int GetMyRestaurantInfo()
        {
            List<IWebElement> allRestaurantNames = driver.FindElements(By.XPath("//main//div//div/h2")).ToList();
            return allRestaurantNames.Count;
        }
    }
}