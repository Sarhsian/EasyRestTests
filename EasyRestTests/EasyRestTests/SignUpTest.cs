using NUnit.Framework;
using PageObjects;
using System;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

namespace Tests
{
    [AllureNUnit]
    [AllureEpic("User")]
    [AllureSuite("NUnit")]
    public class SignUpTest : BaseTest
    {
        public string GetRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        [Test]
        [AllureFeature("SignUp Page")]
        [AllureStory("SignUp")]
        public void PositiveSignUpTest()
        {
            string name = GetRandomString();
            string email = GetRandomString()+ "@test.com";
            string password = GetRandomString();
            
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignUpButton();
            SignUpPage signUpPageObject = new SignUpPage(driver);
            signUpPageObject.SendTextToNameTextField(name);
            signUpPageObject.SendTextToEmailTextField(email);
            signUpPageObject.SendTextToPasswordTextField(password);
            signUpPageObject.SendTextToConfirmPasswordTextField(password);
            signUpPageObject.ClickSubmitButton();
            SignInPage signInPageObject = new SignInPage(driver);
            signInPageObject.SendTextToEmailTextField(email);
            signInPageObject.SendTextToPasswordTextField(password);
            signInPageObject.ClickSubmitButton();
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            Assert.IsTrue(loginedUserPartOfBaseHeaderPageObject.UserMenuDisplayed());

        }
    }
}
