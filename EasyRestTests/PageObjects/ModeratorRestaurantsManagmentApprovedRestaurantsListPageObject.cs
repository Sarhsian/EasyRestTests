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
    public class ModeratorRestaurantsManagmentApprovedRestaurantsListPageObject : ModeratorRestaurantsManagmentPageObject
    {
        public ModeratorRestaurantsManagmentApprovedRestaurantsListPageObject(IWebDriver driver) : base(driver)
        {

        }
        Random rand = new Random();


        private IWebElement DisapprovedMessage => driver.FindElement(By.XPath("//p[(text()='Disapproved')]"));

        public string GetDisapprovedMessageText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[(text()='Disapproved')]")));
            return DisapprovedMessage.Text;
        } 
        public void ClickRandomRestaurantsButtonDelete()
        {
            List<IWebElement> allRestaurantsButtonsDelete = driver.FindElements(By.XPath("//span[(text()='Delete')]")).ToList();

            allRestaurantsButtonsDelete[rand.Next(allRestaurantsButtonsDelete.Count - 1)].Click();
        }
        

    }
}
