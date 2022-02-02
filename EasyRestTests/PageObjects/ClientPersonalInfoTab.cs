using NUnit.Allure.Attributes;
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
        [AllureStep("Click on 'Personal Info' tab")]
        public void ClickPersonalInfoTab() => PersonalInfoTab.Click();
        [AllureStep("Click on 'Current Orders' tab")]
        public void ClickCurrentOrdersTab() => CurrentOrdersTab.Click();
        [AllureStep("Click on 'Order History' tab")]
        public void ClickOrderHistoryTab() => OrderHistoryTab.Click();
        [AllureStep("Click on 'My Restaurant' tab")]
        public void ClickMyRestaurantTab() => MyRestaurantTab.Click();
        [AllureStep("Click on 'Home' button")]
        public void ClickHomeButton() => HomeButton.Click();
        [AllureStep("Click on 'Restaurant List' button")]
        public void ClickRestaurantListButton() => RestaurantListButton.Click();
        [AllureStep("Clcik on 'EasyRest' button")]
        public void ClickEasyRestButton() => EasyRestButton.Click();
    }
}
