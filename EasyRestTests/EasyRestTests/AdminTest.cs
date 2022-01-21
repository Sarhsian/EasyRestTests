using NUnit.Framework;
using PageObjects;

namespace Tests
{
    public class AdminTest : BaseTest //https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=298696230
    {
        [Test, Order(1)]
        public void BanUsersFromAllTab()
        {
            // Arrange
            SignInPage signInPageObject = new SignInPage(driver);
            AdminUsersPage adminUsersPage = new AdminUsersPage(driver);
            string expectedText = "Active";
            int actualUserNumber;

            // Act   
            signInPageObject.SignInAsAdmin();
            Assert.AreEqual(true, adminUsersPage.CheckAvailabilityUsers(expectedText), $"{expectedText} users not find");
            actualUserNumber = adminUsersPage.GetUserNumber(expectedText);
            adminUsersPage.ClickLockButton(actualUserNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminUsersPage.GetActualStatus(actualUserNumber);

            //Assert
            Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} is not equal for {expectedText}");
        }

        [Test, Order(2)]
        public void BanUsersFromActiveTab()
        {
            //Arrange;
            SignInPage signInPageObject = new SignInPage(driver);
            AdminUsersPage adminUsersPage = new AdminUsersPage(driver);
            int num = 1;
            string userName;

            //Act
            signInPageObject.SignInAsAdmin();
            adminUsersPage.ClickActiveUsersButton();
            Assert.AreEqual(true, adminUsersPage.CheckAvailabilityAnyUsers(), "Users not find on this page");
            userName = adminUsersPage.GetUserName(num);
            adminUsersPage.ClickLockButton(num);
            adminUsersPage.ClickBannedUsersButton();

            //Assert
            Assert.AreEqual(true, adminUsersPage.CheckOnUserName(userName), "User name not find");
        }

        [Test, Order(3)]
        public void UnBanUsersFromAllTab()
        {
            // Arrange  
            SignInPage signInPageObject = new SignInPage(driver);
            AdminUsersPage adminUsersPage = new AdminUsersPage(driver);
            string expectedText = "Banned";
            int actualUserNumber;

            // Act  ;
            signInPageObject.SignInAsAdmin();
            Assert.AreEqual(true, adminUsersPage.CheckAvailabilityUsers(expectedText), $"{expectedText} users not find");
            actualUserNumber = adminUsersPage.GetUserNumber(expectedText);
            adminUsersPage.ClickLockButton(actualUserNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminUsersPage.GetActualStatus(actualUserNumber);

            //Assert
            Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} is not equal for {expectedText}");
        }

        [Test, Order(5)]
        public void UnBanUsersFromBannedTab()
        {
            //Arrange
            SignInPage signInPageObject = new SignInPage(driver);
            AdminUsersPage adminUsersPage = new AdminUsersPage(driver);
            int num = 1;
            string userName;

            //Act
            signInPageObject.SignInAsAdmin();
            adminUsersPage.ClickBannedUsersButton();
            Assert.AreEqual(true, adminUsersPage.CheckAvailabilityAnyUsers(), "Users not find on this page");
            userName = adminUsersPage.GetUserName(num);
            adminUsersPage.ClickLockButton(num);
            adminUsersPage.ClickActiveUsersButton();

            //Assert
            Assert.AreEqual(true, adminUsersPage.CheckOnUserName(userName), "User name not find");
        }

        [Test, Order(4)]
        public void PositiveAdminInfoAboutBlockedUsersTest()
        {
            //Arrange
            AdminUsersPage adminUsersPage = new AdminUsersPage(driver);
            SignInPage signInPageObject = new SignInPage(driver);

            //Act
            signInPageObject.SignInAsAdmin();
            adminUsersPage.ClickUsersButton();
            adminUsersPage.ClickBannedUsersButton();

            //Assert
            int actualResult = adminUsersPage.GetUsersInfo();
            Assert.That(actualResult > 0, $"There are {actualResult} banned users");
        }

        [Test, Order(7)]
        public void BanOwnersFromAllTab()
        {
            // Arrange  
            SignInPage signInPageObject = new SignInPage(driver);
            AdminOwnersPage adminOwnersPage = new AdminOwnersPage(driver);
            string expectedText = "Active";
            int actualOwnerNumber;

            // Act  
            signInPageObject.SignInAsAdmin();
            adminOwnersPage.ClickOwnersButton();
            Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityOwners(expectedText), $"{expectedText} owners not find");
            actualOwnerNumber = adminOwnersPage.GetOwnerNumber(expectedText);
            adminOwnersPage.ClickLockButton(actualOwnerNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminOwnersPage.GetActualStatus(actualOwnerNumber);

            //Assert            
            Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} is not equal for {expectedText}");
        }

        [Test, Order(6)]
        public void BanOwnersFromActiveTab()
        {
            //Arrange
            SignInPage signInPageObject = new SignInPage(driver);
            AdminOwnersPage adminOwnersPage = new AdminOwnersPage(driver);
            int num = 1;
            string ownerName;

            //Act
            signInPageObject.SignInAsAdmin();
            adminOwnersPage.ClickOwnersButton();
            adminOwnersPage.ClickActiveOwnersButton();
            Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityAnyOwners(), "Owners not find on this page");
            ownerName = adminOwnersPage.GetOwnerName(num);
            adminOwnersPage.ClickLockButton(num);
            adminOwnersPage.ClickBannedOwnersButton();

            //Assert
            Assert.AreEqual(true, adminOwnersPage.CheckOnOwnerName(ownerName), "Owner name not find");
        }
        [Test, Order(8)]
        public void PositiveAdminInfoAboutBlockedOwnersTest()
        {
            //Arrange
            AdminOwnersPage adminOwnersPage = new AdminOwnersPage(driver);
            SignInPage signInPageObject = new SignInPage(driver);

            //Act
            signInPageObject.SignInAsAdmin();
            adminOwnersPage.ClickOwnersButton();
            adminOwnersPage.ClickBannedOwnersButton();

            //Assert
            int actualResult = adminOwnersPage.GetUsersInfo();
            Assert.That(actualResult > 0, $"There are {actualResult} banned users");
        }

        [Test, Order(9)]
        public void UnbanOwnersFromAllTab()
        {
            //Arrange
            SignInPage signInPageObject = new SignInPage(driver);
            AdminOwnersPage adminOwnersPage = new AdminOwnersPage(driver);
            string expectedText = "Banned";
            int actualOwnerNumber;

            // Act  
            signInPageObject.SignInAsAdmin();
            adminOwnersPage.ClickOwnersButton();
            Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityOwners(expectedText), $"{expectedText} owners not find");
            actualOwnerNumber = adminOwnersPage.GetOwnerNumber(expectedText);
            adminOwnersPage.ClickLockButton(actualOwnerNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminOwnersPage.GetActualStatus(actualOwnerNumber);

            //Assert            
            Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} is not equal for {expectedText}");
        }

        [Test, Order(10)]
        public void UnbanOwnersFromBannedTab()
        {
            //Arrange
            SignInPage signInPageObject = new SignInPage(driver);
            AdminOwnersPage adminOwnersPage = new AdminOwnersPage(driver);
            int num = 1;
            string ownerName;

            //Act
            signInPageObject.SignInAsAdmin();
            adminOwnersPage.ClickOwnersButton();
            adminOwnersPage.ClickBannedOwnersButton();
            Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityAnyOwners(), "Owners not find on this page");
            ownerName = adminOwnersPage.GetOwnerName(num);
            adminOwnersPage.ClickLockButton(num);
            adminOwnersPage.ClickActiveOwnersButton();

            //Assert
            Assert.AreEqual(true, adminOwnersPage.CheckOnOwnerName(ownerName), "Owner name not find");
        }

        [Test, Order(11)]
        public void AdminRestaurantTab_WnehLoggedIn_ShouldShowInfoAboutAllRestaurant()
        {
            //Arrange
            SignInPage signInPageObject
                = new SignInPage(driver);
            AdminPanelPage adminPanelPageObject
                = new AdminPanelPage(driver);

            //Act
            signInPageObject.SignInAsAdmin(); //PositiveAdminSignIn
            adminPanelPageObject.ClickRestaurantsManagmentPageButton(); //PositiveRestaurantManagment
            adminPanelPageObject.ClickAllRestaurantsListButton(); //PositiveInfoAboutAllRestaurants 
            //Assert
            int actualResult = adminPanelPageObject.GetRestaurantInfo();
            Assert.That(actualResult > 0, $"There are {actualResult} All restaurants");
        }
        [Test, Order(12)]
        public void AdminRestaurantTab_WnehLoggedIn_ShouldShowInfoAboutUnapprovedRestaurant()
        {
            //Arrange
            SignInPage signInPageObject
                = new SignInPage(driver);
            AdminPanelPage adminPanelPageObject
                = new AdminPanelPage(driver);

            //Act
            signInPageObject.SignInAsAdmin(); //PositiveAdminSignIn
            adminPanelPageObject.ClickRestaurantsManagmentPageButton(); //PositiveRestaurantManagment
            adminPanelPageObject.ClickUnapprovedRestaurantsListButton(); //PositiveInfoAboutUnapprovedRestaurants 
                                                                         //Assert
            int actualResult = adminPanelPageObject.GetRestaurantInfo();
            Assert.That(actualResult > 0, $"There are {actualResult} Unapproved restaurants");
        }
        [Test, Order(13)]
        public void AdminRestaurantTab_WnehLoggedIn_ShouldShowInfoAboutApprovedRestaurant()
        {
            //Arrange
            SignInPage signInPageObject
                = new SignInPage(driver);
            AdminPanelPage adminPanelPageObject
                = new AdminPanelPage(driver);

            //Act);
            signInPageObject.SignInAsAdmin(); //PositiveAdminSignIn
            adminPanelPageObject.ClickRestaurantsManagmentPageButton(); //PositiveRestaurantManagment
            adminPanelPageObject.ClickApprovedRestaurantsListButton(); ; //PositiveInfoAboutApprovedRestaurants 
            //Assert
            int actualResult = adminPanelPageObject.GetRestaurantInfo();
            Assert.That(actualResult > 0, $"There are {actualResult} Approved restaurants");
        }
        [Test, Order(14)]
        public void AdminRestaurantTab_WnehLoggedIn_ShouldShowInfoAboutArchivedRestaurant()
        {
            //Arrange
            SignInPage signInPageObject
                = new SignInPage(driver);
            AdminPanelPage adminPanelPageObject
                = new AdminPanelPage(driver);

            //Act
            signInPageObject.SignInAsAdmin(); //PositiveAdminSignIn
            adminPanelPageObject.ClickRestaurantsManagmentPageButton(); //PositiveRestaurantManagment
            adminPanelPageObject.ClickArchivedRestaurantsListButton(); //PositiveInfoAboutArchivedRestaurants 
            //Assert
            int actualResult = adminPanelPageObject.GetRestaurantInfo();
            Assert.That(actualResult > 0, $"There are {actualResult} Archived restaurants");
        }
    }
}