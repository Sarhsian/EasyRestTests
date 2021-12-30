using OpenQA.Selenium;

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
    }
}
