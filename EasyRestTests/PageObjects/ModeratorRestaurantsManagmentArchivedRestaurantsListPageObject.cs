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
    public class ModeratorRestaurantsManagmentArchivedRestaurantsListPageObject : ModeratorRestaurantsManagmentPageObject
    {
        public ModeratorRestaurantsManagmentArchivedRestaurantsListPageObject(IWebDriver driver) : base(driver)
        {

        }
        Random rand = new Random();



        private IWebElement ApprovedMessage => driver.FindElement(By.XPath("//p[(text()='Approved')]"));

     
        public string GetApprovedMessageText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[(text()='Approved')]")));
            return ApprovedMessage.Text;
        }
        
        public void ClickRandomRestaurantsButtonRestore()
        {
            List<IWebElement> allRestaurantsButtonsRestore = driver.FindElements(By.XPath("//span[(text()='Restore')]")).ToList();

            allRestaurantsButtonsRestore[rand.Next(allRestaurantsButtonsRestore.Count - 1)].Click();
        }

    }
}
