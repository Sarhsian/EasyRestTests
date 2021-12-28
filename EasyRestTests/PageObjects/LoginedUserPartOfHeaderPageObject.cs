﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class LoginedUserPartOfHeaderPageObject : BaseHeaderPageObject
    {
        public LoginedUserPartOfHeaderPageObject(IWebDriver driver) : base(driver)
        {

        }
        private IWebElement UserMenuButton => driver.FindElement(By.XPath("//*[@id='root']/header/div/div/div/button"));

        public void ClickUserMenuButton() => UserMenuButton.Click();
        public bool UserMenuDisplayed() => UserMenuButton.Displayed;


    }
}
