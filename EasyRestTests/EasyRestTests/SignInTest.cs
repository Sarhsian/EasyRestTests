using NUnit.Framework;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Tests
{
    public class SignInTest : BaseTest
    {
        [Test]
        public void NegativeEmailAndPassword()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            Thread.Sleep(3000);
            SignInPageObject signInPageObject = new SignInPageObject(driver);

            signInPageObject.SendTextToEmailTextField("negative_email@test.com");
            signInPageObject.SendTextToPasswordTextField("00000000");
            Thread.Sleep(2000);
            signInPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            string actualErrorMessageText = signInPageObject.GetEmailOrPasswordIsNotValidErrorMessage();
            string expectedErrorMessageText = "Email or password is invalid";
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
            
           

        }
        [Test]
        
        public void PositiveSignInTest()
        {
           
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            Thread.Sleep(3000);
            SignInPageObject signInPageObject = new SignInPageObject(driver);

            signInPageObject.SendTextToEmailTextField("katiedoyle@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            Thread.Sleep(2000);
            signInPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            Assert.IsTrue(loginedUserPartOfBaseHeaderPageObject.UserMenuDisplayed());




        }
    }
}
