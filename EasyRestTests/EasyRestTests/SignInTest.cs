using NUnit.Framework;
using PageObjects;

namespace Tests
{
    public class SignInTest : BaseTest
    {
        /*[Test]

        public void NegativeEmailAndPassword()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("negative_email@test.com");
            signInPageObject.SendTextToPasswordTextField("00000000");
            signInPageObject.ClickSubmitButton();
            string actualErrorMessageText = signInPageObject.GetEmailOrPasswordIsNotValidErrorMessage();
            string expectedErrorMessageText = "Email or password is invalid";
            Assert.AreEqual(expectedErrorMessageText, actualErrorMessageText, $"{expectedErrorMessageText} is not equal for {actualErrorMessageText}");
        }*/
        [Test]
        [TestCase("katiedoyle@test.com", "1111")]
        [TestCase("jasonbrown@test.com", "1111")]
        [TestCase("petermoderator@test.com", "1")]
        [TestCase("steveadmin@test.com", "1")]
        [TestCase("tanyasanchez@test.com", "1")]
        [TestCase("karenperez@test.com", "1")]

        public void PositiveSignInTest(string email, string password)
        {
            // Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            
            // Act
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField(email);
            signInPageObject.SendTextToPasswordTextField(password);
            signInPageObject.ClickSubmitButton();
            
            // Assert
            Assert.IsTrue(loginedUserPartOfBaseHeaderPageObject.UserMenuDisplayed());
        }
    }
}
