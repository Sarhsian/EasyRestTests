using NUnit.Framework;
using PageObjects;
using System;
using System.Threading;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Tests
{
    [AllureNUnit]
    [AllureLink("https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=298696230")]
    [AllureSuite("NUnit")]
    public class AdminCreateModeratorTest : BaseTest
    { 
        public string GetRandomString() //RandomPositiveStringForCreatingModerator
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
        public string NegativeGetRandomString() //RandomNegativeStringForCreatingModerator
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
        [Test, Order(1)]
        [AllureDescription("Test for admin role, to check posibility to create new moderator")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Admin", "TestCase ID#00008")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("Moderators")]
        [AllureStory("Create")]
        public void AdminAddModerator_WhenLoggedIn_ShouldCreateNewModerator()
        {
            //OurInformationForPositiveCreatingNewModerator
            string name = GetRandomString();
            string email = GetRandomString() + "@test.com";
            string password = GetRandomString();

            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPage signInPageObject
                = new SignInPage(driver);
            AdminModeratorsPage adminModeratorsPage
                = new AdminModeratorsPage(driver);
            AdminModeratorCreatePage adminModeratorCreatePageObject
                = new AdminModeratorCreatePage(driver);
            AdminPanelPage adminPanelPageObject
                = new AdminPanelPage(driver);

            //Act
            signInPageObject.SignInAsAdmin(); //PositiveAdminSignIn
            adminModeratorsPage.ClickModeratorsButton(); //PositiveModeratorManagment
            adminModeratorsPage.ClickAllModeratorsButton();
            adminModeratorsPage.ClickAddModerator(); //PositiveAddModedratorPage
            adminModeratorCreatePageObject.SendTextToNameTextField(name);
            adminModeratorCreatePageObject.SendTextToEmailTextField(email);
            adminModeratorCreatePageObject.SendTextToPasswordTextField(password);
            adminModeratorCreatePageObject.SendTextToConfirmPasswordTextField(password);
            adminModeratorCreatePageObject.ClickSubmitButton(); //PositiveModeratorCreating
            int actualResult = adminPanelPageObject.GetModeratorInfo();
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.That(actualResult > 1, $"There are {actualResult} All moderator"); },
                "Check new moderator");
        }

        [Test, Order(2)]
        [AllureDescription("Test for admin role, to check negative posibility to create new moderator")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Admin", "TestCase ID#000021")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("Moderators")]
        [AllureStory("Create")]
        public void AdminAddModerator_WhenLoggedIn_ShouldNotCreateNewModerator()
        {
            //OurInformationForNegativeCreatingNewModerator
            string invalidName = NegativeGetRandomString();
            string invalidEmail = NegativeGetRandomString() + "@testcom";
            string invalidPassword = NegativeGetRandomString();

            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPage signInPageObject
                 = new SignInPage(driver);
            AdminModeratorsPage adminModeratorsPage
                = new AdminModeratorsPage(driver);
            AdminModeratorCreatePage adminModeratorCreatePageObject
                = new AdminModeratorCreatePage(driver);

            //Act
            signInPageObject.SignInAsAdmin(); //PositiveAdminSignIn
            adminModeratorsPage.ClickModeratorsButton(); //PositiveModeratorManagment
            adminModeratorsPage.ClickAllModeratorsButton();
            adminModeratorsPage.ClickAddModerator(); //PositiveAddModedratorPage
            adminModeratorCreatePageObject.SendTextToNameTextField(invalidName);
            adminModeratorCreatePageObject.SendTextToEmailTextField(invalidEmail);
            adminModeratorCreatePageObject.SendTextToPasswordTextField(invalidPassword);
            adminModeratorCreatePageObject.SendTextToConfirmPasswordTextField("11111111");
            Thread.Sleep(1000);
            adminModeratorCreatePageObject.ClickSubmitButton(); //NegativeModeratorCreating

            //Asserts
            string actualEmailErrorMessageText = adminModeratorCreatePageObject.GetEmailIsNotValidErrorMessage();
            string expectedEmailErrorMessageText = "Email is not valid";
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(expectedEmailErrorMessageText, actualEmailErrorMessageText, $"{expectedEmailErrorMessageText} is not equal for {actualEmailErrorMessageText}"); },
                 "Check error message about email");
            string actualPasswordErrorMessageText = adminModeratorCreatePageObject.GetPasswordErrorMessage();
            string expectedPasswordErrorMessageText = "Password must have at least 8 characters";
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(expectedPasswordErrorMessageText, actualPasswordErrorMessageText, $"{expectedPasswordErrorMessageText} is not equal for {actualPasswordErrorMessageText}"); },
                 "Check error message about password");
            string actualConfirmPasswordErrorMessageText = adminModeratorCreatePageObject.GetPasswordMismatchErrorMessage();
            string expectedConfirmPasswordErrorMessageText = "Password mismatch";
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.AreEqual(expectedConfirmPasswordErrorMessageText, actualConfirmPasswordErrorMessageText, $"{expectedConfirmPasswordErrorMessageText} is not equal for {actualConfirmPasswordErrorMessageText}"); },
                "Check error message about confirm password");
        }
    }
}