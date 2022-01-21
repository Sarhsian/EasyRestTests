﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PageObjects
{
    public class ManageRestaurantAdministratorsTab
    {
        protected static IWebDriver driver;
        public ManageRestaurantAdministratorsTab(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        //All our elements where we use on Administrator tab
        private IWebElement AddAdministratorButton => driver.FindElement(By.XPath("//button[@title='Add Administrator']"));
        private IWebElement AdministratorNameTextField => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement AdministratorEmailTextField => driver.FindElement(By.XPath("//input[@name='email']"));
        private IWebElement AdministratorPasswordTextField => driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement AdministratorPhoneNumberTextField => driver.FindElement(By.XPath("//input[@name='phone_number']"));
        private IWebElement SubmitCreateNewAdministratorButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement CreateNewAdministratorNameIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Name is required']"));
        private IWebElement CreateNewAdministratorMailIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Mail is required']"));
        private IWebElement CreateNewAdministratorPasswordIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Password is required']"));
        private IWebElement CreateNewAdministratorPhoneNumberIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Phone number is required']"));
        private IWebElement CreateNewAdministratorSomethingWentWrongErrorMessage => driver.FindElement(By.XPath("//p[text()='Something went wrong']"));
        //Methods for interaction with our elements

        public void ClickAddAdministratorButton() => AddAdministratorButton.Click();
        public void ClickSubmitCreateNewAdministratorButton() => SubmitCreateNewAdministratorButton.Click();
        public void SendAdministratorNameTextField(string text) => AdministratorNameTextField.SendKeys(text);
        public void SendAdministratorEmailTextField(string text) => AdministratorEmailTextField.SendKeys(text);
        public void SendAdministratorPasswordTextField(string text) => AdministratorPasswordTextField.SendKeys(text);
        public void SendAdministratorPhoneNumberTextField(string text) => AdministratorPhoneNumberTextField.SendKeys(text);
        public int GetRestaurantAdministratorInfo()
        {
            List<IWebElement> allAdministratorNames = driver.FindElements(By.XPath("//main//div//ul//li")).ToList();
            return allAdministratorNames.Count;
        }
        public string GetCreateNewAdministratorNameIsRequiredErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Name is required']")));
            return CreateNewAdministratorNameIsRequiredErrorMessage.Text;
        }
        public string GetCreateNewAdministratorMailIsRequiredErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Mail is required']")));
            return CreateNewAdministratorMailIsRequiredErrorMessage.Text;
        }
        public string GetCreateNewAdministratorPasswordIsRequiredErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Password is required']")));
            return CreateNewAdministratorPasswordIsRequiredErrorMessage.Text;
        }
        public string GetCreateNewAdministratorPhoneNumberIsRequiredErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Phone number is required']")));
            return CreateNewAdministratorPhoneNumberIsRequiredErrorMessage.Text;
        }
        public string GetCreateNewAdministratorSomethingWentWrongErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Something went wrong']")));
            return CreateNewAdministratorSomethingWentWrongErrorMessage.Text;
        }
    }
}