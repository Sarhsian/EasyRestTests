using OpenQA.Selenium;
using NUnit.Allure.Attributes;

namespace PageObjects
{
    public class ManageRestaurantMenuTab
    {
        protected static IWebDriver driver;
        public ManageRestaurantMenuTab(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement MenuNameTextField => driver.FindElement(By.XPath("//input[@name='menuName']"));
        private IWebElement NextCreateMenuNameButton => driver.FindElement(By.XPath("(//span[text()='Next'])[1]"));
        private IWebElement GroupProductNameTextfield => driver.FindElement(By.XPath("//textarea[@name='name']"));
        private IWebElement GroupProductDescriptionTextfield => driver.FindElement(By.XPath("//textarea[@name='description']"));
        private IWebElement GroupProductIngredientsTextfield => driver.FindElement(By.XPath("//textarea[@name='ingredients']"));
        private IWebElement GroupProductPriceTextfield => driver.FindElement(By.XPath("//input[@name='price']"));
        private IWebElement GroupProductAmountTextfield => driver.FindElement(By.XPath("//input[@name='amount']"));
        private IWebElement GroupProductCategoryButton => driver.FindElement(By.XPath("//select[@name='category']"));
        private IWebElement SelectMeatProductCategory => driver.FindElement(By.XPath("//option[text()='Meat']"));
        private IWebElement NextCreateMuneButtonStepTwo => driver.FindElement(By.XPath("(//span[text()='Next'])[2]"));
        private IWebElement FinishCreateMenuButton => driver.FindElement(By.XPath("(//span[text()='Finish'])[3]"));

        [AllureStep("Click next button")]
        public void ClickNextCreateMenuNameButton() => NextCreateMenuNameButton.Click();
        [AllureStep("click product category button")]
        public void ClickGroupProductCategoryButton() => GroupProductCategoryButton.Click();
        [AllureStep("click product category button")]
        public void ClickSelectMeatProductCategory() => SelectMeatProductCategory.Click();
        [AllureStep("Click next step create menu button")]
        public void ClickNextCreateMuneButtonStepTwo() => NextCreateMuneButtonStepTwo.Click();
        [AllureStep("Click finish creating, which will be create menu for our restaurant")]
        public void ClickFinishCreateMenuButton() => FinishCreateMenuButton.Click();
        [AllureStep("Fill menu name")]
        public void SendMenuNameTextField(string text) => MenuNameTextField.SendKeys(text);
        [AllureStep("Fill product name")]
        public void SendGroupProductNameTextfield(string text) => GroupProductNameTextfield.SendKeys(text);
        [AllureStep("Fill product description")]
        public void SendGroupProductDescriptionTextfield(string text) => GroupProductDescriptionTextfield.SendKeys(text);
        [AllureStep("Fill prodduct ingriients")]
        public void SendGroupProductIngredientsTextfield(string text) => GroupProductIngredientsTextfield.SendKeys(text);
        [AllureStep("Fill product price")]
        public void SendGroupProductPriceTextfield(string text) => GroupProductPriceTextfield.SendKeys(text);
        [AllureStep("Fill prouct amount")]
        public void SendGroupProductAmountTextfield(string text) => GroupProductAmountTextfield.SendKeys(text);
    }
}