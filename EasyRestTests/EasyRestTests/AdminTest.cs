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
            int actualUserNumber;

            // Act            
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            Assert.AreEqual(true, adminUsersPage.CheckAvailabilityUsers(expectedText), $"{expectedText} users not find");
            actualUserNumber = adminUsersPage.GetUserNumber(expectedText);
            adminUsersPage.ClickLockButton(actualUserNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminUsersPage.GetActualStatus(actualUserNumber);

            //Assert
            Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} is not equal for {expectedText}");
        }

        [Test]
        public void BanUsersFromActiveTab()
        {
            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            AdminUsersPage adminUsersPage = new AdminUsersPage(driver);
            int num = 1;
            string userName;

            //Act
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            adminUsersPage.ClickActiveUsersButton();
            Assert.AreEqual(true, adminUsersPage.CheckAvailabilityAnyUsers(), "Users not find on this page");
            userName = adminUsersPage.GetUserName(num);
            adminUsersPage.ClickLockButton(num);
            adminUsersPage.ClickBannedUsersButton();

            //Assert
            Assert.AreEqual(true, adminUsersPage.CheckOnUserName(userName), "User name not find");
        }

        [Test]
        public void UnBanUsersFromAllTab()
        {
            // Arrange            
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            AdminUsersPage adminUsersPage = new AdminUsersPage(driver);
            string expectedText = "Banned";
            int actualUserNumber;

            // Act            
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            Assert.AreEqual(true, adminUsersPage.CheckAvailabilityUsers(expectedText), $"{expectedText} users not find");
            actualUserNumber = adminUsersPage.GetUserNumber(expectedText);
            adminUsersPage.ClickLockButton(actualUserNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminUsersPage.GetActualStatus(actualUserNumber);

            //Assert
            Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} is not equal for {expectedText}");
        }

        [Test]
        public void UnBanUsersFromBannedTab()
        {
            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            AdminUsersPage adminUsersPage = new AdminUsersPage(driver);
            int num = 1;
            string userName;

            //Act
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            adminUsersPage.ClickBannedUsersButton();
            Assert.AreEqual(true, adminUsersPage.CheckAvailabilityAnyUsers(), "Users not find on this page");
            userName = adminUsersPage.GetUserName(num);
            adminUsersPage.ClickLockButton(num);
            adminUsersPage.ClickActiveUsersButton();

            //Assert
            Assert.AreEqual(true, adminUsersPage.CheckOnUserName(userName), "User name not find");
        }

        [Test]
        public void PositiveAdminInfoAboutBlockedUsersTest()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            AdminUsersPage adminUsersPage = new AdminUsersPage(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            adminUsersPage.ClickUsersButton();
            adminUsersPage.ClickBannedUsersButton();
            int actualResult = adminUsersPage.GetUsersInfo();
            Assert.That(actualResult > 0, $"There are {actualResult} banned users");
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
            Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityOwners(expectedText), $"{expectedText} owners not find");
            actualOwnerNumber = adminOwnersPage.GetOwnerNumber(expectedText);
            adminOwnersPage.ClickLockButton(actualOwnerNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminOwnersPage.GetActualStatus(actualOwnerNumber);

            //Assert            
            Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} is not equal for {expectedText}");
        }

        [Test]
        public void BanOwnersFromActiveTab()
        {
            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            AdminOwnersPage adminOwnersPage = new AdminOwnersPage(driver);
            int num = 1;
            string ownerName;

            //Act
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            adminOwnersPage.ClickOwnersButton();
            adminOwnersPage.ClickActiveOwnersButton();
            Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityAnyOwners(), "Owners not find on this page");
            ownerName = adminOwnersPage.GetOwnerName(num);
            adminOwnersPage.ClickLockButton(num);
            adminOwnersPage.ClickBannedOwnersButton();

            //Assert
            Assert.AreEqual(true, adminOwnersPage.CheckOnOwnerName(ownerName), "Owner name not find");
        }
        [Test]
        public void PositiveAdminInfoAboutBlockedOwnersTest()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            AdminOwnersPage adminOwnersPage = new AdminOwnersPage(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            adminOwnersPage.ClickOwnersButton();
            adminOwnersPage.ClickBannedOwnersButton();
            int actualResult = adminOwnersPage.GetUsersInfo();
            Assert.That(actualResult > 0, $"There are {actualResult} banned users");
        }

        [Test]
        public void UnbanOwnersFromAllTab()
        {
            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            AdminOwnersPage adminOwnersPage = new AdminOwnersPage(driver);
            string expectedText = "Banned";
            int actualOwnerNumber;

            // Act            
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            adminOwnersPage.ClickOwnersButton();
            Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityOwners(expectedText), $"{expectedText} owners not find");
            actualOwnerNumber = adminOwnersPage.GetOwnerNumber(expectedText);
            adminOwnersPage.ClickLockButton(actualOwnerNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminOwnersPage.GetActualStatus(actualOwnerNumber);

            //Assert            
            Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} is not equal for {expectedText}");
        }

        [Test]
        public void UnbanOwnersFromBannedTab()
        {
            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            AdminOwnersPage adminOwnersPage = new AdminOwnersPage(driver);
            int num = 1;
            string ownerName;

            //Act
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            adminOwnersPage.ClickOwnersButton();
            adminOwnersPage.ClickBannedOwnersButton();
            Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityAnyOwners(), "Owners not find on this page");
            ownerName = adminOwnersPage.GetOwnerName(num);
            adminOwnersPage.ClickLockButton(num);
            adminOwnersPage.ClickActiveOwnersButton();

            //Assert
            Assert.AreEqual(true, adminOwnersPage.CheckOnOwnerName(ownerName), "Owner name not find");
        }
    }
}
