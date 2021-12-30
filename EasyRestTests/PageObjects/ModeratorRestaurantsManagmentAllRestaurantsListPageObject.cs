using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageObjects
{
    public class ModeratorRestaurantsManagmentAllRestaurantsListPageObject : ModeratorRestaurantsManagmentPageObject
    {
        public ModeratorRestaurantsManagmentAllRestaurantsListPageObject(IWebDriver driver) : base(driver)
        {

        }
        List<IWebElement> allRestaurants = driver.FindElement(By.CssSelector(".MuiGrid-container-4193.MuiGrid-spacing-xs-16-4216")).FindElements(By.TagName("div")).ToList();
        

    }
}
