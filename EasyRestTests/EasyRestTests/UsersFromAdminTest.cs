using NUnit.Framework;
using PageObjects;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    public class UsersFromAdminTest : BaseTest
    {
        [Test]
        public void BanUsersFromAllTab()
        {
            // Arrange            
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            AdminUsersPage adminUsersPage = new AdminUsersPage(driver);
            string expectedText = "Active";
            int countOfUsers = 10;
            int actualUser = 1;

            // Act            
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            for (; actualUser <= countOfUsers; actualUser++)
            {
                string actualText = adminUsersPage.GetActualStatus(actualUser);
                if (string.Equals(expectedText, actualText))
                {
                    adminUsersPage.ClickLockButton(actualUser);
                    break;
                }
            }
            driver.Navigate().Refresh();
            string actualText2 = adminUsersPage.GetActualStatus(actualUser);

            //Assert
            Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} is not equal for {expectedText}");
        }
    }
}
