using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PageObjects
{
    public class ModeratorUsersManagmentAllUsersListPageObject : ModeratorUsersManagmentPageObject
    {
        public ModeratorUsersManagmentAllUsersListPageObject(IWebDriver driver) : base(driver)
        {

        }
        Random rand = new Random();

        //button[@aria-label='Close']
        private IWebElement SuccessMessage => driver.FindElement(By.XPath("//p[(text()='success')]"));
        private IWebElement CloseMessageButton => driver.FindElement(By.XPath("//button[@aria-label='Close']"));

        public void ClickCloseMessageButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElement(SuccessMessage,"success"));
            CloseMessageButton.Click();                      
        }
        public void ClickRandomUsersButtonBan()
        {
            List<IWebElement> allUsersButtonsBan = driver.FindElements
                (By.XPath("//button[contains(@class,'MuiIconButton-colorPrimary')]")).ToList();
            allUsersButtonsBan[rand.Next(allUsersButtonsBan.Count - 1)].Click();
        }
        public string GetSuccessMessageText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[(text()='success')]")));
            return SuccessMessage.Text;
        }

        public void ClickRandomUsersButtonUnban()
        {
            
            List<IWebElement> allUsersButtonsUnban = driver.FindElements
                (By.XPath("//button[contains(@class,'MuiIconButton-colorSecondary')]")).ToList();
            allUsersButtonsUnban[rand.Next(allUsersButtonsUnban.Count - 1)].Click();
        }

    }
}
