﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class ManageRestaurantPageObject
    {
        protected static IWebDriver driver;

        public ManageRestaurantPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private IWebElement ProfileLogoButton => driver.FindElement(By.XPath("//div[text()='K']"));
        private IWebElement MyRestaurantsButton => driver.FindElement(By.XPath("//a[@href='/profile/restaurants']"));
        private IWebElement DetailsTab => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/11/edit/info']"));
        private IWebElement MenuesTab => driver.FindElement(By.XPath("//div[@role='button']"));
        private IWebElement CreateMenuTab => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/11/edit/menues/create_menu']"));
        private IWebElement MenuNameTextField => driver.FindElement(By.XPath("//input[@name='menuName']"));
        private IWebElement NextCreateMenuNameButton => driver.FindElement(By.XPath("(//span[text()='Next'])[1]"));
        private IWebElement GroupProductNameTextfield => driver.FindElement(By.XPath("//textarea[@name='name']"));
        private IWebElement GroupProductDescriptionTextfield => driver.FindElement(By.XPath("//textarea[@name='description']"));
        private IWebElement GroupProductIngredientsTextfield => driver.FindElement(By.XPath("//textarea[@name='ingredients']"));
        private IWebElement GroupProductPriceTextfield => driver.FindElement(By.XPath("//input[@name='price']"));
        private IWebElement GroupProductAmountTextfield => driver.FindElement(By.XPath("//input[@name='amount']"));
        private IWebElement GroupProductCategoryButton => driver.FindElement(By.XPath("//select[@name='category']"));
        private IWebElement SelectMeatProductCategory => driver.FindElement(By.XPath("//option[text()='Meat']"));
        private IWebElement NextCreateMuneButtonStepTwo => driver.FindElement(By.XPath("(//span[text()='Next'])[2]"));
        private IWebElement FinishCreateMuneButton => driver.FindElement(By.XPath("(//span[text()='Finish'])[3]"));
        private IWebElement WaitersTab => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/11/edit/waiters']"));
        private IWebElement AddWaiterButton => driver.FindElement(By.XPath("//button[@title='Add Waiter']"));
        private IWebElement WaiterNameTextField => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement WaiterEmailTextField => driver.FindElement(By.XPath("//input[@name='email']"));
        private IWebElement WaiterPasswordTextField => driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement WaiterPhoneNumberTextField => driver.FindElement(By.XPath("//input[@name='phone_number']"));
        private IWebElement SubmitCreateNewWaiterButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement AdministratorTab => driver.FindElement(By.XPath("//a[@href='/profile/restaurants/11/edit/administrators']"));
        private IWebElement AddAdministratorButton => driver.FindElement(By.XPath("//button[@title='Add Administrator']"));
        private IWebElement AdministratorNameTextField => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement AdministratorEmailTextField => driver.FindElement(By.XPath("//input[@name='email']"));
        private IWebElement AdministratorPasswordTextField => driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement AdministratorPhoneNumberTextField => driver.FindElement(By.XPath("//input[@name='phone_number']"));
        private IWebElement SubmitCreateNewAdministratorButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement CreateMenuNameIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Name is required']"));
        private IWebElement CreateMenuAddressIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Address is required']"));
        private IWebElement CreateNewWaiterNameIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Name is required']"));
        private IWebElement CreateNewWaiterMailIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Mail is required']"));
        private IWebElement CreateNewWaiterPasswordIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Password is required']"));
        private IWebElement CreateNewWaiterPhoneNumberIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Phone number is required']"));
        private IWebElement CreateNewWaiterSomethingWentWrongErrorMessage => driver.FindElement(By.XPath("//p[text()='Something went wrong']"));
        private IWebElement CreateNewAdministratorNameIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Name is required']"));
        private IWebElement CreateNewAdministratorMailIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Mail is required']"));
        private IWebElement CreateNewAdministratorPasswordIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Password is required']"));
        private IWebElement CreateNewAdministratorPhoneNumberIsRequiredErrorMessage => driver.FindElement(By.XPath("//p[text()='Phone number is required']"));
        private IWebElement CreateNewAdministratorSomethingWentWrongErrorMessage => driver.FindElement(By.XPath("//p[text()='Something went wrong']"));
        //xpath

        public void SendMenuNameTextField(string text)
        {
            MenuNameTextField.SendKeys(text);
        }

        public void SendGroupProductNameTextfield(string text)
        {
            GroupProductNameTextfield.SendKeys(text);
        }
        public void SendGroupProductDescriptionTextfield(string text)
        {
            GroupProductDescriptionTextfield.SendKeys(text);
        }
        public void SendGroupProductIngredientsTextfield(string text)
        {
            GroupProductIngredientsTextfield.SendKeys(text);
        }
        public void SendGroupProductPriceTextfield(string text)
        {
            GroupProductPriceTextfield.SendKeys(text);
        }
        public void SendGroupProductAmountTextfield(string text)
        {
            GroupProductAmountTextfield.SendKeys(text);
        }

        public void SendWaiterNameTextField(string text)
        {
            WaiterNameTextField.SendKeys(text);
        }
        public void SendWaiterEmailTextField(string text)
        {
            WaiterEmailTextField.SendKeys(text);
        }
        public void SendWaiterPasswordTextField(string text)
        {
            WaiterPasswordTextField.SendKeys(text);
        }
        public void SendWaiterPhoneNumberTextField(string text)
        {
            WaiterPhoneNumberTextField.SendKeys(text);
        }
        public void SendAdministratorNameTextField(string text)
        {
            AdministratorNameTextField.SendKeys(text);
        }
        public void SendAdministratorEmailTextField(string text)
        {
            AdministratorEmailTextField.SendKeys(text);
        }
        public void SendAdministratorPasswordTextField(string text)
        {
            AdministratorPasswordTextField.SendKeys(text);
        }
        public void SendAdministratorPhoneNumberTextField(string text)
        {
            AdministratorPhoneNumberTextField.SendKeys(text);
        }//SendTextField

        public void ClickDetailsTab()
        {
            DetailsTab.Click();
        }
        public void ClickMenuesTab()
        {
            MenuesTab.Click();
        }
        public void ClickCreateMenuTab()
        {
            CreateMenuTab.Click();
        }

        public void ClickNextCreateMenuNameButton()
        {
            NextCreateMenuNameButton.Click();
        }

        public void ClickGroupProductCategoryButton()
        {
            GroupProductCategoryButton.Click();
        }

        public void ClickSelectMeatProductCategory()
        {
            SelectMeatProductCategory.Click();
        }

        public void ClickNextCreateMuneButtonStepTwo()
        {
            NextCreateMuneButtonStepTwo.Click();
        }

        public void ClickWaitersTab()
        {
            WaitersTab.Click();
        }

        public void ClickAddWaiterButton()
        {
            AddWaiterButton.Click();
        }

        public void ClickAdministratorTab()
        {
            AdministratorTab.Click();
        }

        public void ClickAddAdministratorButton()
        {
            AddAdministratorButton.Click();
        }

        public void ClickProfileLogoButton()
        {
            ProfileLogoButton.Click();
        }
        public void ClickMyRestaurantsButton()
        {
            MyRestaurantsButton.Click();
        }

        public void ClickFinishCreateMuneButton()
        {
            FinishCreateMuneButton.Click();
        }

        public void ClickSubmitCreateNewWaiterButton()
        {
            SubmitCreateNewWaiterButton.Click();
        }

        public void ClickSubmitCreateNewAdministratorButton()
        {
            SubmitCreateNewAdministratorButton.Click();
        }//ButtonsClick
        public string GetCreateMenuNameIsRequiredErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Name is required']")));
            return CreateMenuNameIsRequiredErrorMessage.Text;
        }
        public string GetCreateMenuAddressIsRequiredErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[text()='Address is required']")));
            return CreateMenuAddressIsRequiredErrorMessage.Text;
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
        } //GetErrorMassages
    }
}