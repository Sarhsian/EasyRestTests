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
    public class ModeratorRestaurantsManagmentAllRestaurantsListPageObject : ModeratorRestaurantsManagmentPageObject
    {
        public ModeratorRestaurantsManagmentAllRestaurantsListPageObject(IWebDriver driver) : base(driver)
        {

        }
        Random rand = new Random();
        
        
        private IWebElement DisapprovedMessage => driver.FindElement(By.XPath("//p[(text()='Disapproved')]"));

        public void ClickRandomRestaurantsButtonDisapprove()
        {
            List<IWebElement> allRestaurantsButtonsDisapprove = driver.FindElements(By.XPath("//span[(text()='Disapprove')]")).ToList();
            allRestaurantsButtonsDisapprove[rand.Next(allRestaurantsButtonsDisapprove.Count-1)].Click();
        }
        public string GetDisapprovedMessageText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[(text()='Disapproved')]")));
            return DisapprovedMessage.Text;
        }
        private IWebElement ApprovedMessage => driver.FindElement(By.XPath("//p[(text()='Approved')]"));
        

        public void ClickRandomRestaurantsButtonApprove()
        {
            List<IWebElement> allRestaurantsButtonsApprove = driver.FindElements(By.XPath("//span[(text()='Approve')]")).ToList();
            allRestaurantsButtonsApprove[rand.Next(allRestaurantsButtonsApprove.Count - 1)].Click();
        }
        public string GetApprovedMessageText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[(text()='Approved')]")));
            return ApprovedMessage.Text;
        }
        public void ClickRandomRestaurantsButtonDelete()
        {
            List<IWebElement> allRestaurantsButtonsDelete = driver.FindElements(By.XPath("//span[(text()='Delete')]")).ToList();

            allRestaurantsButtonsDelete[rand.Next(allRestaurantsButtonsDelete.Count - 1)].Click();
        }
        public void ClickRandomRestaurantsButtonRestore()
        {
            List<IWebElement> allRestaurantsButtonsRestore = driver.FindElements(By.XPath("//span[(text()='Restore')]")).ToList();

            allRestaurantsButtonsRestore[rand.Next(allRestaurantsButtonsRestore.Count - 1)].Click();
        }

    }
}
