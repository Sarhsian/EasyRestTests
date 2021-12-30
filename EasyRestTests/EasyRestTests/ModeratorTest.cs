using NUnit.Framework;
using PageObjects;
using System;
using System.Collections.Generic;
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
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            string actualRolePanelText = loginedUserPartOfBaseHeaderPageObject.GetRolePanelText();
            string expectedRolePanelText = "Moderator panel";
            Assert.AreEqual(expectedRolePanelText, actualRolePanelText, $"{expectedRolePanelText} is not equal for {actualRolePanelText}");

        }





    }
}
