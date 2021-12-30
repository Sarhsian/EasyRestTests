using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests
{
    public class ModeratorTest : BaseTest
    {
        [Test]
        public void PositiveModeratorTest()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("petermoderator@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            Assert.IsTrue(loginedUserPartOfBaseHeaderPageObject.UserMenuDisplayed());
            //PositiveSignInTest
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            string actualRolePanelText = loginedUserPartOfBaseHeaderPageObject.GetRolePanelText();
            string expectedRolePanelText = "Moderator panel";
            Assert.AreEqual(expectedRolePanelText, actualRolePanelText, $"{expectedRolePanelText} is not equal for {actualRolePanelText}");
            //PositiveModeratorSignInTest

        }
        [Test]
        public void PositiveModeratorRestaurantsManagmentTest()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("petermoderator@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            Assert.IsTrue(loginedUserPartOfBaseHeaderPageObject.UserMenuDisplayed());
            //PositiveSignInTest
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            string actualRolePanelText = loginedUserPartOfBaseHeaderPageObject.GetRolePanelText();
            string expectedRolePanelText = "Moderator panel";
            Assert.AreEqual(expectedRolePanelText, actualRolePanelText, $"{expectedRolePanelText} is not equal for {actualRolePanelText}");
            //PositiveModeratorSignInTest
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            ModeratorRestaurantsManagmentPageObject moderatorRestaurantsManagmentPageObject = new ModeratorRestaurantsManagmentPageObject(driver);
            moderatorRestaurantsManagmentPageObject.ClickRestaurantsManagmentPageButton();
            //PositiveModeratorRestaurantsManagmentTest
        }
        [Test]
        public void PositiveModeratorRestaurantsManagmentAllRestaurantsListTest()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("petermoderator@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            Assert.IsTrue(loginedUserPartOfBaseHeaderPageObject.UserMenuDisplayed());
            //PositiveSignInTest
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            string actualRolePanelText = loginedUserPartOfBaseHeaderPageObject.GetRolePanelText();
            string expectedRolePanelText = "Moderator panel";
            Assert.AreEqual(expectedRolePanelText, actualRolePanelText, $"{expectedRolePanelText} is not equal for {actualRolePanelText}");
            //PositiveModeratorSignInTest
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            ModeratorRestaurantsManagmentPageObject moderatorRestaurantsManagmentPageObject = new ModeratorRestaurantsManagmentPageObject(driver);
            moderatorRestaurantsManagmentPageObject.ClickRestaurantsManagmentPageButton();
            //PositiveModeratorRestaurantsManagmentTest
            
            //List<IWebElement> allRestaurants = driver.FindElements(By.CssSelector(".MuiGrid-item-4194.MuiGrid-grid-xs-12-4233")).ToList();
            List<IWebElement> allRestaurants = driver.FindElements(By.XPath("//*[@id='root']/div/main/div[2]/div")).ToList();

            bool foo;
            int i = 11;
            int count = allRestaurants.Count;
            if (count == i)
            {
                foo = true;
            }
            else
                foo = false;
            Assert.IsTrue(foo,$"{count} is not equal for {i}");



        }




}
}
