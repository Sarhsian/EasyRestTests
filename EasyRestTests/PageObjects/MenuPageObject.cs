using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    class MenuPageObject
    {
        protected static IWebDriver driver;
        public MenuPageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        private IWebElement ShowCartButton => driver.FindElement(By.XPath("//button[contains(@aria-label, 'Show cart')]"));
        private IWebElement ShortcutButton(int numOfButton) => driver.FindElement(By.XPath("(//div//div//div//div//div//a)["+numOfButton+"]"));
        private IWebElement ShortcutBackButton(int numOfButton) => driver.FindElement(By.XPath("(//div//div//div//div//div//a)[last()]"));
        private IWebElement ShowMoreButton(int numOfButton) => driver.FindElement(By.XPath("(//button[contains(@aria-label, 'Show more')])["+numOfButton+"]"));
        private IWebElement AddToCartButton(int numOfButton) => driver.FindElement(By.XPath("(//button[contains(@aria-label, 'Add to cart')])[" + numOfButton + "]"));
        private IWebElement InputQuantityField(int numOfButton) => driver.FindElement(By.XPath("(//div//input)[" + numOfButton + "]"));
        private IWebElement SubmitOrderButton => driver.FindElement(By.XPath("//button/span[text()='Submit order']"));
        private IWebElement RemoveProductFromCartButton(int numOfButton) => driver.FindElement(By.XPath("(//span[contains(@class,'MuiFab')])["+numOfButton+"]"));
        private IWebElement InputQuantityFieldInCart(int numOfButton) => driver.FindElement(By.XPath("(//div[contains(@class,'OrderCartItem')]//div//input)[" + numOfButton + "]"));
        
        public int ShortcutsQuantity()
        {
            List<IWebElement> allShorcuts = driver.FindElements(By.XPath("//div//div//div//div//div//a")).ToList();
            return allShorcuts.Count()-1;
        }
        public int ProductQuantity()
        {
            List<IWebElement> allAddToCart = driver.FindElements(By.XPath("//button[contains(@aria-label, 'Add to cart')]")).ToList();
            return allAddToCart.Count();
        }
        public int ProductQuantityInCart()
        {
            List<IWebElement> allRemoveButtons = driver.FindElements(By.XPath("//span[contains(@class,'MuiFab')]")).ToList();
            return allRemoveButtons.Count();
        }
    }
}
