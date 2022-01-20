using OpenQA.Selenium;

namespace PageObjects
{
    public class ManageRestaurantMenuTab
    {
        protected static IWebDriver driver;
        public ManageRestaurantMenuTab(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        //Our elements where we use on menu tab
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
        //Buttons on this page
        public void ClickNextCreateMenuNameButton() => NextCreateMenuNameButton.Click();
        public void ClickGroupProductCategoryButton() => GroupProductCategoryButton.Click();
        public void ClickSelectMeatProductCategory() => SelectMeatProductCategory.Click();
        public void ClickNextCreateMuneButtonStepTwo() => NextCreateMuneButtonStepTwo.Click();
        public void ClickFinishCreateMenuButton() => FinishCreateMenuButton.Click();
        //TextFields on this page
        public void SendMenuNameTextField(string text) => MenuNameTextField.SendKeys(text);
        public void SendGroupProductNameTextfield(string text) => GroupProductNameTextfield.SendKeys(text);
        public void SendGroupProductDescriptionTextfield(string text) => GroupProductDescriptionTextfield.SendKeys(text);
        public void SendGroupProductIngredientsTextfield(string text) => GroupProductIngredientsTextfield.SendKeys(text);
        public void SendGroupProductPriceTextfield(string text) => GroupProductPriceTextfield.SendKeys(text);
        public void SendGroupProductAmountTextfield(string text) => GroupProductAmountTextfield.SendKeys(text);
    }
}