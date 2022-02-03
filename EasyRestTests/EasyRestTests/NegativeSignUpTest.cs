using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PageObjects;
using System;
using System.Threading;

namespace Tests
{
    [AllureNUnit]
    [AllureLink("https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=1686602044")]
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
        [AllureDescription("Test for Unlogined user, to check negative posibility to create user")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Admin", "TestCase ID#000021")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("Moderators")]
        [AllureStory("Create")]
        public void WhenUnLoggedUp_ShoulNotSignUp()
        { 
            //OurInformationForNegativeSignUp
            string name = GetRandomString();
            string email = GetRandomString() + "@testcom";
            string password = GetRandomString();
            string confirmPassword = GetRandomString();
            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignUpPage signUpPageObject
                = new SignUpPage(driver);
            unloginedUserPartOfBaseHeader.ClickSignUpButton();
            signUpPageObject.SendTextToNameTextField(name);
            signUpPageObject.SendTextToEmailTextField(email);
            signUpPageObject.SendTextToPasswordTextField(password);
            signUpPageObject.SendTextToConfirmPasswordTextField(confirmPassword);
            Thread.Sleep(1000);
            signUpPageObject.ClickSubmitButton();
            //Assert
            string actualEmailErrorMessageText = signUpPageObject.GetEmailIsNotValidErrorMessage();
            string expectedEmailErrorMessageText = "Email is not valid";
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(expectedEmailErrorMessageText, actualEmailErrorMessageText, $"{expectedEmailErrorMessageText} is not equal for {actualEmailErrorMessageText}"); },
                 "Check error message 'Email is not valid' ");
            string actualPasswordErrorMessageText = signUpPageObject.GetPasswordErrorMessage();
            string expectedPasswordErrorMessageText = "Password must have at least 8 characters";
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(expectedPasswordErrorMessageText, actualPasswordErrorMessageText, $"{expectedPasswordErrorMessageText} is not equal for {actualPasswordErrorMessageText}"); },
                 "Check error message 'Password must have at least 8 characters' ");
            string actualConfirmPasswordErrorMessageText = signUpPageObject.GetPasswordMismatchErrorMessage();
            string expectedConfirmPasswordErrorMessageText = "Password mismatch";
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(expectedConfirmPasswordErrorMessageText, actualConfirmPasswordErrorMessageText, $"{expectedConfirmPasswordErrorMessageText} is not equal for {actualConfirmPasswordErrorMessageText}"); },
                 "Check error message 'Password mismatch' ");
        }
    }
}