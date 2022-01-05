using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class ModeratorOwnersManagmentPageObject : ModeratorPanelPageObject
    {
        public ModeratorOwnersManagmentPageObject(IWebDriver driver) : base(driver)
        {

        }
        ////button[@class='MuiButtonBase-root-106 MuiIconButton-root-2549 MuiIconButton-colorSecondary-2552']
        private IWebElement AllOwnersListButton =>
            driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'All')]"));
        private IWebElement ActiveOwnersListButton =>
           driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'Active')]"));
        private IWebElement BannedOwnersListButton =>
           driver.FindElement(By.XPath("//button/span/span/span[contains(text(),'Banned')]"));

        public void ClickAllOwnersListButton()
        {
            AllOwnersListButton.Click();
        }
        public void ClickActiveOwnersListButton()
        {
            ActiveOwnersListButton.Click();
        }
        public void ClickBanndeOwnersListButton()
        {
            BannedOwnersListButton.Click();
        }
    }
}
