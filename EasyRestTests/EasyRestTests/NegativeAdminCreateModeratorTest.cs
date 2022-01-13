using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tests
{
    public class NegativeAdminCreateModeratorTest : BaseTest
    {

        public string NegativeGetRandomString()
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
        //NegativeStringForCreatingModerator

        [Test]

        public void negativeAdminCreateModeratorTest()
        {
            string invalidName = NegativeGetRandomString();
            string invalidEmail = NegativeGetRandomString() + "@testcom";
            string invalidPassword = NegativeGetRandomString();
            //OurInformationFornegativeCreatingNewModerator
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPageObject signInPageObject
                = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            //PositiveAdminSignIn
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            AdminModeratorsPage adminModeratorsPage
                = new AdminModeratorsPage(driver);
            adminModeratorsPage.ClickModeratorsButton();
            //PositiveModeratorManagment
            adminModeratorsPage.ClickAllModeratorsButton();
            adminModeratorsPage.ClickAddModerator();
            //PositiveAddModedratorPage
            NegativeAdminModeratorCreatePageObject negativeAdminModeratorCreatePageObject
                = new NegativeAdminModeratorCreatePageObject(driver);
            negativeAdminModeratorCreatePageObject.SendTextToNameTextField(invalidName);
            negativeAdminModeratorCreatePageObject.SendTextToEmailTextField(invalidEmail);
            negativeAdminModeratorCreatePageObject.SendTextToPasswordTextField(invalidPassword);
            negativeAdminModeratorCreatePageObject.SendTextToConfirmPasswordTextField("11111111");
            Thread.Sleep(1000);
            negativeAdminModeratorCreatePageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            //NegativeModeratorCreating
            string actualEmailErrorMessageText = negativeAdminModeratorCreatePageObject.GetEmailIsNotValidErrorMessage();
            string expectedEmailErrorMessageText = "Email is not valid";
            Assert.AreEqual(expectedEmailErrorMessageText, actualEmailErrorMessageText, $"{expectedEmailErrorMessageText} is not equal for {actualEmailErrorMessageText}");
            string actualPasswordErrorMessageText = negativeAdminModeratorCreatePageObject.GetPasswordErrorMessage();
            string expectedPasswordErrorMessageText = "Password must have at least 8 characters";
            Assert.AreEqual(expectedPasswordErrorMessageText, actualPasswordErrorMessageText, $"{expectedPasswordErrorMessageText} is not equal for {actualPasswordErrorMessageText}");
            string actualConfirmPasswordErrorMessageText = negativeAdminModeratorCreatePageObject.GetPasswordMismatchErrorMessage();
            string expectedConfirmPasswordErrorMessageText = "Password mismatch";
            Assert.AreEqual(expectedConfirmPasswordErrorMessageText, actualConfirmPasswordErrorMessageText, $"{expectedConfirmPasswordErrorMessageText} is not equal for {actualConfirmPasswordErrorMessageText}");
        }
    }
}

