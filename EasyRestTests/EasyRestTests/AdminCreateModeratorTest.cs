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
    public class AdminCreateModeratorTest : BaseTest
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
            //RandomStringForCreatingModerator
        }

        [Test]

        public void PositiveAdminCreateModeratorTest()
        {
            string name = GetRandomString();
            string email = GetRandomString() + "@test.com";
            string password = GetRandomString();
            //OurInformationForCreatingNewModerator
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPage signInPageObject
                = new SignInPage(driver);
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
            AdminModeratorCreatePageObject adminModeratorCreatePageObject
                = new AdminModeratorCreatePageObject(driver);
            adminModeratorCreatePageObject.SendTextToNameTextField(name);
            adminModeratorCreatePageObject.SendTextToEmailTextField(email);
            adminModeratorCreatePageObject.SendTextToPasswordTextField(password);
            adminModeratorCreatePageObject.SendTextToConfirmPasswordTextField(password);
            adminModeratorCreatePageObject.ClickSubmitButton();
            //PositiveModeratorCreating
        }
    }
}


