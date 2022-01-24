using NUnit.Framework;
using PageObjects;

namespace Tests
{
    public class AdminTest : BaseTest //https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=298696230
    {
        [Test, Order(1)]
        public void BanUsersFromAllTab_WhenLoggedIn_ShoudBanUser()
        {
            // Arrange
            var signInPage = new SignInPage(driver);
            var adminUsersPage = new AdminAllLists(driver);
            string expectedText = "Active";
            int actualUserNumber;

            // Act   
            signInPage.SignInAsAdmin();
            Assert.AreEqual(true, adminUsersPage.CheckAvailabilityUsersByStatus(expectedText), $"{expectedText} users not find");
            actualUserNumber = adminUsersPage.GetUserNumberByName(expectedText);
            adminUsersPage.ClickLockButton(actualUserNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminUsersPage.GetActualStatusByNumber(actualUserNumber);

            //Assert
            Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} - status now, must be Banned");
        }

        [Test, Order(2)]
        public void BanUsersFromActiveTab_WhenLoggedIn_ShoudBanUserAndMoveToBannedTab()
        {
            //Arrange;
            var signInPage = new SignInPage(driver);
            var adminUsersPage = new AdminAllLists(driver);
            int num = 1;
            string userName;

            //Act
            signInPage.SignInAsAdmin();
            adminUsersPage.ClickActiveTabButton();
            Assert.AreEqual(true, adminUsersPage.CheckAvailabilityAnyUsers(), "Users not find on this page");
            userName = adminUsersPage.GetNameByNumber(num);
            adminUsersPage.ClickLockButton(num);
            adminUsersPage.ClickBannedTabButton();

            //Assert
            Assert.AreEqual(true, adminUsersPage.CheckOnUserName(userName), $"{userName} not find");
        }

        [Test, Order(3)]
        public void PositiveAdminInfoAboutBlockedUsersTest()
        {
            //Arrange
            var adminUsersPage = new AdminAllLists(driver);
            var signInPage = new SignInPage(driver);

            //Act
            signInPage.SignInAsAdmin();
            adminUsersPage.ClickUsersListButton();
            adminUsersPage.ClickBannedTabButton();

            //Assert
            int actualResult = adminUsersPage.GetUsersInfo();
            Assert.That(actualResult > 0, $"There are {actualResult} banned users");
        }

        [Test, Order(4)]
        public void UnbanUsersFromAllTab_WhenLoggedIn_ShoudUnbanUser()
        {
            // Arrange  
            var signInPage = new SignInPage(driver);
            var adminUsersPage = new AdminAllLists(driver);
            string expectedText = "Banned";
            int actualUserNumber;

            // Act  
            signInPage.SignInAsAdmin();
            Assert.AreEqual(true, adminUsersPage.CheckAvailabilityUsersByStatus(expectedText), $"{expectedText} users not find");
            actualUserNumber = adminUsersPage.GetUserNumberByName(expectedText);
            adminUsersPage.ClickLockButton(actualUserNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminUsersPage.GetActualStatusByNumber(actualUserNumber);

            //Assert
            Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} - status now, must be Active");
        }

        [Test, Order(5)]
        public void UnbanUsersFromBannedTab_WhenLoggedIn_ShoudUnbanUserAndMoveToActiveTab()
        {
            //Arrange
            var signInPage = new SignInPage(driver);
            var adminUsersPage = new AdminAllLists(driver);
            int num = 1;
            string userName;

            //Act
            signInPage.SignInAsAdmin();
            adminUsersPage.ClickBannedTabButton();
            Assert.AreEqual(true, adminUsersPage.CheckAvailabilityAnyUsers(), "Users not find on this page");
            userName = adminUsersPage.GetNameByNumber(num);
            adminUsersPage.ClickLockButton(num);
            adminUsersPage.ClickActiveTabButton();

            //Assert
            Assert.AreEqual(true, adminUsersPage.CheckOnUserName(userName), $"{userName} not find");
        }        

        [Test, Order(6)]
        public void BanOwnersFromAllTab_WhenLoggedIn_ShoudBanOwner()
        {
            // Arrange  
            var signInPage = new SignInPage(driver);
            var adminOwnersPage = new AdminAllLists(driver);
            string expectedText = "Active";
            int actualOwnerNumber;

            // Act  
            signInPage.SignInAsAdmin();
            adminOwnersPage.ClickOwnersListButton();
            Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityUsersByStatus(expectedText), $"{expectedText} owners not find");
            actualOwnerNumber = adminOwnersPage.GetUserNumberByName(expectedText);
            adminOwnersPage.ClickLockButton(actualOwnerNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminOwnersPage.GetActualStatusByNumber(actualOwnerNumber);

            //Assert            
            Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} - status now, must be Banned");
        }

        [Test, Order(7)]
        public void BanOwnersFromActiveTab_WhenLoggedIn_ShoudBanOwnerAndMoveToBannedTab()
        {
            //Arrange
            var SigninPage = new SignInPage(driver);
            var adminOwnersPage = new AdminAllLists(driver);
            int num = 1;
            string ownerName;

            //Act
            SigninPage.SignInAsAdmin();
            adminOwnersPage.ClickOwnersListButton();
            adminOwnersPage.ClickActiveTabButton();
            Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityAnyUsers(), "Owners not find on this page");
            ownerName = adminOwnersPage.GetNameByNumber(num);
            adminOwnersPage.ClickLockButton(num);
            adminOwnersPage.ClickBannedTabButton();

            //Assert
            Assert.AreEqual(true, adminOwnersPage.CheckOnUserName(ownerName), "Owner name not find");
        }
        [Test, Order(8)]
        public void PositiveAdminInfoAboutBlockedOwnersTest()
        {
            //Arrange
            var adminOwnersPage = new AdminAllLists(driver);
            var signInPage = new SignInPage(driver);

            //Act
            signInPage.SignInAsAdmin();
            adminOwnersPage.ClickOwnersListButton();
            adminOwnersPage.ClickBannedTabButton();

            //Assert
            int actualResult = adminOwnersPage.GetUsersInfo();
            Assert.That(actualResult > 0, $"There are {actualResult} banned users");
        }

        [Test, Order(9)]
        public void UnbanOwnersFromAllTab_WhenLoggedIn_ShoudUnbanOwner()
        {
            // Arrange  
            var signInPage = new SignInPage(driver);
            var adminOwnersPage = new AdminAllLists(driver);
            string expectedText = "Banned";
            int actualOwnerNumber;

            // Act  
            signInPage.SignInAsAdmin();
            adminOwnersPage.ClickOwnersListButton();
            Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityUsersByStatus(expectedText), $"{expectedText} owners not find");
            actualOwnerNumber = adminOwnersPage.GetUserNumberByName(expectedText);
            adminOwnersPage.ClickLockButton(actualOwnerNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminOwnersPage.GetActualStatusByNumber(actualOwnerNumber);

            //Assert            
            Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} - status now, must be Active");
        }

        [Test, Order(10)]
        public void UnbanOwnersFromBannedTab_WhenLoggedIn_ShoudUnbanOwnerAndMoveToActiveTab()
        {
            //Arrange
            var SigninPage = new SignInPage(driver);
            var adminOwnersPage = new AdminAllLists(driver);
            int num = 1;
            string ownerName;

            //Act
            SigninPage.SignInAsAdmin();
            adminOwnersPage.ClickOwnersListButton();
            adminOwnersPage.ClickBannedTabButton();
            Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityAnyUsers(), "Owners not find on this page");
            ownerName = adminOwnersPage.GetNameByNumber(num);
            adminOwnersPage.ClickLockButton(num);
            adminOwnersPage.ClickActiveTabButton();

            //Assert
            Assert.AreEqual(true, adminOwnersPage.CheckOnUserName(ownerName), "Owner name not find");
        }

        [Test, Order(11)]
        public void AdminRestaurantTab_WhenLoggedIn_ShouldShowInfoAboutAllRestaurant()
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
        public void AdminRestaurantTab_WhenLoggedIn_ShouldShowInfoAboutUnapprovedRestaurant()
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
        public void AdminRestaurantTab_WhenLoggedIn_ShouldShowInfoAboutApprovedRestaurant()
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
        public void AdminRestaurantTab_WhenLoggedIn_ShouldShowInfoAboutArchivedRestaurant()
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