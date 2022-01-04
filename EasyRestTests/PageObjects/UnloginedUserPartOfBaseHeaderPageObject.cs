using OpenQA.Selenium;

namespace PageObjects
{
    public class UnloginedUserPartOfBaseHeaderPageObject : BaseHeaderPageObject
    {
        
        public UnloginedUserPartOfBaseHeaderPageObject(IWebDriver driver) : base(driver)
        {
           
        }
        private IWebElement SignInButton => driver.FindElement(By.XPath("//a[@href='/log-in']"));
        private IWebElement SignUpButton => driver.FindElement(By.XPath("//a[@href='/sign-up']"));
        public void ClickSignInButton()
        {
            SignInButton.Click();
        }
        public void ClickSignUpButton()
        {
            SignUpButton.Click();
        }
    }
}
