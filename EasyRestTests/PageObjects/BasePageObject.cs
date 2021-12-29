using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjects
{
    public class BasePageObject
    {
        protected IWebDriver driver;

        public BasePageObject(IWebDriver webDriver)
        {
            driver = webDriver;
        }


        IWebElement PrevSlideButton => driver.FindElement(By.XPath("//button[@class='MuiButtonBase-root-106 MuiFab-root-1972 MuiFab-primary-1974 AppSlider-sliderBtnPrev-1966']"));
        IWebElement NextSlideButton => driver.FindElement(By.XPath("//button[@class='MuiButtonBase-root-106 MuiFab-root-1972 MuiFab-primary-1974 AppSlider-sliderBtnNext-1965']"));
        IWebElement FirstSlideResturantLink => driver.FindElement(By.XPath("//a[text()='Johnson PLC']"));
        IWebElement SecondSlideResturantLink => driver.FindElement(By.XPath("//a[text()='Preston, Terrell and Warren']"));
        IWebElement ThirdSlideResturantLink => driver.FindElement(By.XPath("//a[text()='Ball-Logan']"));
        IWebElement ViewAllCategoryLink => driver.FindElement(By.XPath("//h6[text()='View All']"));
        IWebElement PubCategoryLink => driver.FindElement(By.XPath("//h6[text()='pub']"));
        IWebElement FastFoodCategoryLink => driver.FindElement(By.XPath("//h6[text()='fast food']"));
        IWebElement VegeterianCategoryLink => driver.FindElement(By.XPath("//h6[text()='vegetarian']"));
        IWebElement PizzaCategoryLink => driver.FindElement(By.XPath("//h6[text()='pizza']"));
        IWebElement SushiCategoryLink => driver.FindElement(By.XPath("//h6[text()='sushi']"));
        IWebElement GreelCategoryLink => driver.FindElement(By.XPath("//h6[text()='greel']"));
        IWebElement BurgersCategoryLink => driver.FindElement(By.XPath("//h6[text()='burgers']"));
        IWebElement KebabCategoryLink => driver.FindElement(By.XPath("//h6[text()='kebab']"));
        IWebElement JapaneseCuisineCategoryLink => driver.FindElement(By.XPath("//h6[text()='japanese cuisine']"));
        IWebElement BeerCategoryLink => driver.FindElement(By.XPath("//h6[text()='beer']"));
        IWebElement UkrainianCuisineCategoryLink => driver.FindElement(By.XPath("//h6[text()='ukrainian cuisine']"));

        public void ClickPrevSlideButton()
        {
            PrevSlideButton.Click();
        }

        public void ClickNextSlideButton()
        {
            NextSlideButton.Click();
        }

        public void ClickFirstSlideResturantLink()
        {
            FirstSlideResturantLink.Click();
        }

        public void ClickSecondSlideResturantLink()
        {
            SecondSlideResturantLink.Click();
        }

        public void ClickThirdSlideResturantLink()
        {
            ThirdSlideResturantLink.Click();
        }

        public void ClickViewAllCategoryLink()
        {
            ViewAllCategoryLink.Click();
        }

        public void ClickPubCategoryLink()
        {
            PubCategoryLink.Click();
        }

        public void ClickFastFoodCategoryLink()
        {
            FastFoodCategoryLink.Click();
        }

        public void ClickVegatarianCategoryLink()
        {
            VegeterianCategoryLink.Click();
        }

        public void ClickPizzaCategoryLink()
        {
            PizzaCategoryLink.Click();
        }

        public void ClickSushiCategoryLink()
        {
            SushiCategoryLink.Click();
        }

        public void ClickGreelCategoryLink()
        {
            GreelCategoryLink.Click();
        }

        public void ClickBurgersCategoryLink()
        {
            BurgersCategoryLink.Click();
        }

        public void ClickKebabCategoryLink()
        {
            KebabCategoryLink.Click();
        }

        public void ClickJapaneseCuisineCategoryLink()
        {
            JapaneseCuisineCategoryLink.Click();
        }

        public void ClickBeerCategoryLink()
        {
            BeerCategoryLink.Click();
        }

        public void ClickUkrainianCuisineCategoryLink()
        {
            UkrainianCuisineCategoryLink.Click();
        }
    }
}
