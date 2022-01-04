using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace PageObjects
{
    public class LoginedUserPartOfBaseHeaderPageObject : BaseHeaderPageObject
    {
        
        public LoginedUserPartOfBaseHeaderPageObject(IWebDriver driver) : base(driver)
        {
            
        }
        private IWebElement UserMenuButton => driver.FindElement(By.XPath("//header/div/div/div/button"));
        private IWebElement RolePanelButton => driver.FindElement(By.XPath("//*[@id='menu-appbar']/div[2]/ul/a"));
        private IWebElement LogOutButton => driver.FindElement(By.XPath("//li[text()='Log Out']"));

        public void ClickUserMenuButton()
        {
            UserMenuButton.Click();
        }
        public void ClickRolePanelButton()
        {
            RolePanelButton.Click();
        }
        public void ClickLogOutButton()
        {
            LogOutButton.Click();
        }
        public bool UserMenuDisplayed()
        {
            return UserMenuButton.Displayed;
        }
        public string GetRolePanelText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='menu-appbar']/div[2]/ul/a")));
            return RolePanelButton.Text;
        }
    }
}
