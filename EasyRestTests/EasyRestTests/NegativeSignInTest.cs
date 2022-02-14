using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PageObjects;
using System.Threading;

namespace Tests
{
    [AllureNUnit]
    [AllureLink("https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=1686602044")]
    [AllureSuite("NUnit")]
    public class NegativeSignInTest : BaseTest
    {
        [Test]
        [AllureDescription("Test for unlogined user, to check negative  possibility to login with role 1")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Unlogined user", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("User")]
        [AllureFeature("SignIn Page")]
        [AllureStory("Login")]
        public void WhenUnLoggedIn_ShoulNotSignInHowClient()
        {
            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPage signInPageObject
                = new SignInPage(driver);
            //Act
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("katedoyle@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            //Assert
            string actualErrorMessageText = signInPageObject.GetEmailOrPasswordIsNotValidErrorMessage();
            string expectedErrorMessageText = "Email or password is invalid";
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}"); },
                 "Check error message about email or password is invalid");
        }
        [Test]
        [AllureDescription("Test for unlogined user, to check possibility to login with role 2")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Unlogined user", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Owner")]
        [AllureFeature("SignIn Page")]
        [AllureStory("Login")]
        public void WhenUnLoggedIn_ShoulNotSignInHowOwner()
        {
            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPage signInPageObject 
                = new SignInPage(driver);
            //Act
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("jasoonbrown@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            //Assert
            string actualErrorMessageText = signInPageObject.GetEmailOrPasswordIsNotValidErrorMessage();
            string expectedErrorMessageText = "Email or password is invalid";
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}"); },
                 "Check error message about email or password is invalid");
        }
        [Test]
        [AllureDescription("Test for unlogined user, to check possibility to login with role 3")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Unlogined user", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Moderator")]
        [AllureFeature("SignIn Page")]
        [AllureStory("Login")]
        public void WhenUnLoggedIn_ShoulNotSignInHowModerator()
        {
            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPage signInPageObject
                = new SignInPage(driver);
            //Acr
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("petermoder@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            //Assert
            string actualErrorMessageText = signInPageObject.GetEmailOrPasswordIsNotValidErrorMessage();
            string expectedErrorMessageText = "Email or password is invalid";
            AllureLifecycle.Instance.WrapInStep(
                  () => { Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}"); },
                  "Check error message about email or password is invalid");
        }
        [Test]
        [AllureDescription("Test for unlogined user, to check possibility to login with role 4")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Unlogined user", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("SignIn Page")]
        [AllureStory("Login")]
        public void WhenUnLoggedIn_ShoulNotSignInHowAdmin()
        {
            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPage signInPageObject
                = new SignInPage(driver);
            //Act
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("stevadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            //Assert
            string actualErrorMessageText = signInPageObject.GetEmailOrPasswordIsNotValidErrorMessage();
            string expectedErrorMessageText = "Email or password is invalid";
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}"); },
                 "Check error message about email or password is invalid");
        }
        [Test]
        [AllureDescription("Test for unlogined user, to check possibility to login with role 5")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Unlogined user", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Administrator")]
        [AllureFeature("SignIn Page")]
        [AllureStory("Login")]
        public void WhenUnLoggedIn_ShoulNotSignInHowAdministrator()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPage signInPageObject
                = new SignInPage(driver);
            //Act
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("tanyasanch@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            //Assert
            string actualErrorMessageText = signInPageObject.GetEmailOrPasswordIsNotValidErrorMessage();
            string expectedErrorMessageText = "Email or password is invalid";
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}"); },
                 "Check error message about email or password is invalid");
        }
        [Test]
        [AllureDescription("Test for unlogined user, to check possibility to login with role 6")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Unlogined user", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Waiter")]
        [AllureFeature("SignIn Page")]
        [AllureStory("Login")]
        public void WhenUnLoggedIn_ShoulNotSignInHowWaiter()
        {
            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPage signInPageObject
                = new SignInPage(driver);
            //Act
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("kareperez@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            //Assert
            string actualErrorMessageText = signInPageObject.GetEmailOrPasswordIsNotValidErrorMessage();
            string expectedErrorMessageText = "Email or password is invalid";
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}"); },
                 "Check error message about email or password is invalid");
        }
    }
}