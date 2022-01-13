using NUnit.Framework;
using PageObjects;
using System;
using System.Threading;

namespace Tests
{
    public class NegativeSignUpTest : BaseTest
    {
        public string GetRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[7];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        [Test]

        public void negativeSignUpTest()
        {
            string name = GetRandomString();
            string email = GetRandomString() + "@testcom";
            string password = GetRandomString();
            string confirmPassword = GetRandomString();
            //OurInformationForNegativeSignUp
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignUpButton();
            SignUpPageObject signUpPageObject = new SignUpPageObject(driver);
            signUpPageObject.SendTextToNameTextField(name);
            signUpPageObject.SendTextToEmailTextField(email);
            signUpPageObject.SendTextToPasswordTextField(password);
            signUpPageObject.SendTextToConfirmPasswordTextField(confirmPassword);
            Thread.Sleep(1000);
            signUpPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            string actualEmailErrorMessageText = signUpPageObject.GetEmailIsNotValidErrorMessage();
            string expectedEmailErrorMessageText = "Email is not valid";
            Assert.AreEqual(expectedEmailErrorMessageText, actualEmailErrorMessageText, $"{expectedEmailErrorMessageText} is not equal for {actualEmailErrorMessageText}");
            string actualPasswordErrorMessageText = signUpPageObject.GetPasswordErrorMessage();
            string expectedPasswordErrorMessageText = "Password must have at least 8 characters";
            Assert.AreEqual(expectedPasswordErrorMessageText, actualPasswordErrorMessageText, $"{expectedPasswordErrorMessageText} is not equal for {actualPasswordErrorMessageText}");
            string actualConfirmPasswordErrorMessageText = signUpPageObject.GetPasswordMismatchErrorMessage();
            string expectedConfirmPasswordErrorMessageText = "Password mismatch";
            Assert.AreEqual(expectedConfirmPasswordErrorMessageText, actualConfirmPasswordErrorMessageText, $"{expectedConfirmPasswordErrorMessageText} is not equal for {actualConfirmPasswordErrorMessageText}");
        }
    }
}
