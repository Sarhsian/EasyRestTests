using NUnit.Framework;
using PageObjects;
using System.Threading;

namespace Tests
{
    public class NegativeSignInTest : BaseTest
    {
        [Test]

        public void NegativeEmailAndPasswordForClient()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("katedoyle@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            string actualErrorMessageText = signInPageObject.GetEmailOrPasswordIsNotValidErrorMessage();
            string expectedErrorMessageText = "Email or password is invalid";
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
        }

        [Test]

        public void NegativeEmailAndPasswordForOwner()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("jasoonbrown@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            string actualErrorMessageText = signInPageObject.GetEmailOrPasswordIsNotValidErrorMessage();
            string expectedErrorMessageText = "Email or password is invalid";
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
        }

        [Test]

        public void NegativeEmailAndPasswordForModerator()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("petermoder@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            string actualErrorMessageText = signInPageObject.GetEmailOrPasswordIsNotValidErrorMessage();
            string expectedErrorMessageText = "Email or password is invalid";
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
        }

        [Test]

        public void NegativeEmailAndPasswordForAdmin()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("stevadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            string actualErrorMessageText = signInPageObject.GetEmailOrPasswordIsNotValidErrorMessage();
            string expectedErrorMessageText = "Email or password is invalid";
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
        }

        [Test]

        public void NegativeEmailAndPasswordForAdministrator()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("tanyasanch@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            string actualErrorMessageText = signInPageObject.GetEmailOrPasswordIsNotValidErrorMessage();
            string expectedErrorMessageText = "Email or password is invalid";
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
        }

        [Test]

        public void NegativeEmailAndPasswordForWaiter()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("kareperez@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            string actualErrorMessageText = signInPageObject.GetEmailOrPasswordIsNotValidErrorMessage();
            string expectedErrorMessageText = "Email or password is invalid";
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
        }
    }
}