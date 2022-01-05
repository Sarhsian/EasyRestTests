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
    public class ModeratorOwnersManagmentBannedOwnersListPageObject : ModeratorOwnersManagmentPageObject
    {
        public ModeratorOwnersManagmentBannedOwnersListPageObject(IWebDriver driver) : base(driver)
        {

        }
        Random rand = new Random();


        private IWebElement SuccessMessage => driver.FindElement(By.XPath("//p[(text()='success')]"));

       
        public string GetSuccessMessageText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[(text()='success')]")));
            return SuccessMessage.Text;
        }

        public void ClickRandomOwnersButtonUnban()
        {
            List<IWebElement> allOwnersButtonsUnban = driver.FindElements
                (By.XPath("//button[contains(@class,'MuiIconButton-colorSecondary')]")).ToList();
            allOwnersButtonsUnban[rand.Next(allOwnersButtonsUnban.Count - 1)].Click();
        }

    }
}
