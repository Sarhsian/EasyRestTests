using NUnit.Framework;
using PageObjects;
using System.Threading;

namespace Tests
{
    public class NegativeSignInTest : BaseTest
    {
        [Test]
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
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
        }
        [Test]
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
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
        }
        [Test]
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
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
        }
        [Test]
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
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
        }
        [Test]
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
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
        }
        [Test]
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
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
        }
    }
}