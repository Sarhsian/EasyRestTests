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
            BasePage basePage = new BasePage(driver);
            basePage.ClickSignIn();
            Thread.Sleep(3000);
            SignInPage signIn = new SignInPage(driver);

            signIn.SendTextToEmail("negative_email@test.com");
            signIn.SendTextToPassword("00000000");
            Thread.Sleep(2000);
            signIn.ClickSubmit();
            Thread.Sleep(2000);
            string actualErrorMessageText = signIn.GetErrorMessageEmailOrPasswordIsNotValid();
            string expectedErrorMessageText = "Email or password is invalid";
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
            signIn.ClickBack();
           

        }
    }
}
