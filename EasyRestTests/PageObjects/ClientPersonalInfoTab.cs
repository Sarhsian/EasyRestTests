using OpenQA.Selenium;

namespace PageObjects
{
    public class ClientPersonalInfoTab
    {
        protected static IWebDriver driver;

        public ClientPersonalInfoTab(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        private IWebElement PersonalInfoTab => driver.FindElement(By.XPath("//span[text()='Personal Info']"));
        private IWebElement CurrentOrdersTab => driver.FindElement(By.XPath("//span[text()='Current Orders']"));
        private IWebElement OrderHistoryTab => driver.FindElement(By.XPath("//span[text()='Order History']"));
        private IWebElement MyRestaurantTab => driver.FindElement(By.XPath("//span[text()='My Restaurants']"));
        private IWebElement HomeButton => driver.FindElement(By.XPath("//span[text()='Home']"));
        private IWebElement RestaurantListButton => driver.FindElement(By.XPath("//span[text()='Restaurants List']"));
        private IWebElement EasyRestButton => driver.FindElement(By.XPath("//a[@class='MuiTypography-root-41 MuiTypography-button-52 MuiTypography-colorInherit-70']"));

        public void ClickPersonalInfoTab() => PersonalInfoTab.Click();
        public void ClickCurrentOrdersTab() => CurrentOrdersTab.Click();
        public void ClickOrderHistoryTab() => OrderHistoryTab.Click();
        public void ClickMyRestaurantTab() => MyRestaurantTab.Click();
        public void ClickHomeButton() => HomeButton.Click();
        public void ClickRestaurantListButton() => RestaurantListButton.Click();
        public void ClickEasyRestButton() => EasyRestButton.Click();
    }
}
