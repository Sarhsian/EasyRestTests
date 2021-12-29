using OpenQA.Selenium;

namespace PageObjects
{
    public class LoginedUserPartOfBaseHeaderPageObject
    {
        protected static IWebDriver driver;
        public LoginedUserPartOfBaseHeaderPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
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
