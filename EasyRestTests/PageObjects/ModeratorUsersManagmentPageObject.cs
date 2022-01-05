using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class ModeratorUsersManagmentPageObject : ModeratorPanelPageObject
    {
        public ModeratorUsersManagmentPageObject(IWebDriver driver) : base(driver)
        {

        }
        ////button[@class='MuiButtonBase-root-106 MuiIconButton-root-2549 MuiIconButton-colorSecondary-2552']
        private IWebElement AllUsersListButton =>
            driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'All')]"));
        private IWebElement ActiveUsersListButton =>
           driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'Active')]"));
        private IWebElement BannedUsersListButton =>
           driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'Approved')]"));

    }
}
