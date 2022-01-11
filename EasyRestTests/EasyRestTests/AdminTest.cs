using NUnit.Framework;
using PageObjects;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    public class AdminTest : BaseTest
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

        [Test]
        public void BanOwnersFromAllTab()
        {
            // Arrange            
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            AdminOwnersPage adminOwnersPage = new AdminOwnersPage(driver);
            string expectedText = "Active";
            int actualOwnerNumber;

            // Act            
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            adminOwnersPage.ClickOwnersButton();            
            Assert.AreEqual("good", adminOwnersPage.CheckAvailabilityUnbannedOwners(expectedText), $"{expectedText} not find");
            adminOwnersPage.CheckAvailabilityUnbannedOwners(expectedText);
            actualOwnerNumber=adminOwnersPage.GetOwnerNumber(expectedText);
            adminOwnersPage.ClickLockButton(actualOwnerNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminOwnersPage.GetActualStatus(actualOwnerNumber);

            //Assert            
            Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} is not equal for {expectedText}");
        }

        [Test]
        public void PositiveAdminInfoAboutBlockedModeratorsTest()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            AdminModeratorsPage adminOwnersPage = new AdminModeratorsPage(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            adminOwnersPage.ClickModeratorsButton();
            adminOwnersPage.ClickBannedModeratorsButton();
            int actualResult = adminOwnersPage.GetModeratorsInfo();
            Assert.That(actualResult > 0, $"There are {actualResult} banned users");
        }
    }
}
