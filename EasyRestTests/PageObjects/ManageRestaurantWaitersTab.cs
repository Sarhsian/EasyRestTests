﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Allure.Attributes;

namespace PageObjects
{
    public class ManageRestaurantWaitersTab
    {
        protected static IWebDriver driver;
        public ManageRestaurantWaitersTab(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement AddWaiterButton => driver.FindElement(By.XPath("//button[@title='Add Waiter']"));
        private IWebElement WaiterNameTextField => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement WaiterEmailTextField => driver.FindElement(By.XPath("//input[@name='email']"));
        private IWebElement WaiterPasswordTextField => driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement WaiterPhoneNumberTextField => driver.FindElement(By.XPath("//input[@name='phone_number']"));
        private IWebElement SubmitCreateNewWaiterButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement CreateNewWaiterNameIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Name is required']"));
        private IWebElement CreateNewWaiterMailIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Mail is required']"));
        private IWebElement CreateNewWaiterPasswordIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Password is required']"));
        private IWebElement CreateNewWaiterPhoneNumberIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Phone number is required']"));
        private IWebElement CreateNewWaiterSomethingWentWrongErrorMessage => driver.FindElement(By.XPath("//p[text()='Something went wrong']"));
        [AllureStep("Click add waiter button")]
        public void ClickAddWaiterButton() => AddWaiterButton.Click();
        [AllureStep("click submit button, which will be create new waiter to our restaurant")]
        public void ClickSubmitCreateNewWaiterButton() => SubmitCreateNewWaiterButton.Click();
        [AllureStep("Fill name")]
        public void SendWaiterNameTextField(string text) => WaiterNameTextField.SendKeys(text);
        [AllureStep("Fill email")]
        public void SendWaiterEmailTextField(string text) => WaiterEmailTextField.SendKeys(text);
        [AllureStep("Fill password")]
        public void SendWaiterPasswordTextField(string text) => WaiterPasswordTextField.SendKeys(text);
        [AllureStep("phone number")]
        public void SendWaiterPhoneNumberTextField(string text) => WaiterPhoneNumberTextField.SendKeys(text);
        public int GetRestaurantWaiterInfo()
        {
            List<IWebElement> allWaiterNames = driver.FindElements(By.XPath("//main//div//ul//li")).ToList();
            return allWaiterNames.Count;
        }
        public string GetCreateNewWaiterNameIsRequiredErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Name is required']")));
            return CreateNewWaiterNameIsRequiredErrorMessage.Text;
        }
        public string GetCreateNewWaiterMailIsRequiredErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Mail is required']")));
            return CreateNewWaiterMailIsRequiredErrorMessage.Text;
        }
        public string GetCreateNewWaiterPasswordIsRequiredErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Password is required']")));
            return CreateNewWaiterPasswordIsRequiredErrorMessage.Text;
        }
        public string GetCreateNewWaiterPhoneNumberIsRequiredErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Phone number is required']")));
            return CreateNewWaiterPhoneNumberIsRequiredErrorMessage.Text;
        }
        public string GetCreateNewWaiterSomethingWentWrongErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Something went wrong']")));
            return CreateNewWaiterSomethingWentWrongErrorMessage.Text;
        }
    }
}