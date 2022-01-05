using NUnit.Framework;
using PageObjects;
using System;

namespace Tests
{
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

        public void PositiveSignUpTest()
        {
            string name = GetRandomString();
            string email = GetRandomString();
            string password = GetRandomString();

            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignUpButton();
            SignUpPageObject signUpPageObject = new SignUpPageObject(driver);
            signUpPageObject.SendTextToNameTextField(name);
            signUpPageObject.SendTextToEmailTextField(email+"@test.com");
            signUpPageObject.SendTextToPasswordTextField(password);
            signUpPageObject.SendTextToConfirmPasswordTextField(password);
            signUpPageObject.ClickSubmitButton();
            

        }
    }
}
