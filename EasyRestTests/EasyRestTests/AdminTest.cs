using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PageObjects;

namespace Tests
{
    [AllureNUnit]
    [AllureLink("https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=298696230")]
    public class AdminTest : BaseTest 
    {
        [Test, Order(1)]
        [AllureDescription("Test for admin role, to check posibility to block user in tab 'Users'=>'All'")]
        [AllureOwner("Vitalii")]
        [AllureTag("Admin", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("Users")]
        [AllureStory("Ban")]
        public void BanUsersFromAllTab_WhenLoggedIn_ShoudBanUser()
        {
            // Arrange
            var signInPage = new SignInPage(driver);
            var adminUsersPage = new AdminAllLists(driver);
            string expectedText = "Active";
            int actualUserNumber;

            // Act   
            signInPage.SignInAsAdmin();
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(true, adminUsersPage.CheckAvailabilityUsersByStatus(expectedText), $"{expectedText} users not find"); },
                 "Check availability users with status 'Active'");            
            actualUserNumber = adminUsersPage.GetUserNumberByStatus(expectedText);
            adminUsersPage.ClickLockButton(actualUserNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminUsersPage.GetActualStatusByNumber(actualUserNumber);

            //Assert
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} - status now, must be Banned"); },
                "Check new user status, must be 'Banned'");            
        }

        [Test, Order(2)]
        [AllureDescription("Test for admin role, to check posibility to block user in tab 'Users'=>'Active'")]
        [AllureOwner("Vitalii")]
        [AllureTag("Admin", "TestCase ID#00002")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("Users")]
        [AllureStory("Ban")]
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
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(true, adminUsersPage.CheckAvailabilityAnyUsers(), "Users not find on this page"); },
                 "Check availability users on Active tab page");            
            userName = adminUsersPage.GetNameByNumber(num);
            adminUsersPage.ClickLockButton(num);
            adminUsersPage.ClickBannedTabButton();

            //Assert
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.AreEqual(true, adminUsersPage.CheckOnUserName(userName), $"{userName} not find"); },
                "Check the name in the Banned tab");            
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
        [AllureDescription("Test for admin role, to check the possibility to unblock Users in tab 'Users'=>'All'")]
        [AllureOwner("Vitalii")]
        [AllureTag("Admin", "TestCase ID#00015")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("Users")]
        [AllureStory("Unban")]
        public void UnbanUsersFromAllTab_WhenLoggedIn_ShoudUnbanUser()
        {
            // Arrange  
            var signInPage = new SignInPage(driver);
            var adminUsersPage = new AdminAllLists(driver);
            string expectedText = "Banned";
            int actualUserNumber;

            // Act  
            signInPage.SignInAsAdmin();
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.AreEqual(true, adminUsersPage.CheckAvailabilityUsersByStatus(expectedText), $"{expectedText} users not find"); },
                "Check availability users with status 'Banned'");            
            actualUserNumber = adminUsersPage.GetUserNumberByStatus(expectedText);
            adminUsersPage.ClickLockButton(actualUserNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminUsersPage.GetActualStatusByNumber(actualUserNumber);

            //Assert
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} - status now, must be Active"); },
                "Check new user status, must be 'Active'");            
        }

        [Test, Order(5)]
        [AllureDescription("Test for admin role, to check the possibility to unblock Users in tab 'Users'=>'Banned'")]
        [AllureOwner("Vitalii")]
        [AllureTag("Admin", "TestCase ID#00016")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("Users")]
        [AllureStory("Unban")]
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
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(true, adminUsersPage.CheckAvailabilityAnyUsers(), "Users not find on this page"); },
                 "Check availability users on Banned tab");            
            userName = adminUsersPage.GetNameByNumber(num);
            adminUsersPage.ClickLockButton(num);
            adminUsersPage.ClickActiveTabButton();

            //Assert
            AllureLifecycle.Instance.WrapInStep(
               () => { Assert.AreEqual(true, adminUsersPage.CheckOnUserName(userName), $"{userName} not find"); },
               "Check the name in the Active tab");            
        }        

        [Test, Order(6)]
        [AllureDescription("Test for admin role, to check the possibility to block owners in tab 'Owners'=>'All'")]
        [AllureOwner("Vitalii")]
        [AllureTag("Admin", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("Owners")]
        [AllureStory("Ban")]
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
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityUsersByStatus(expectedText), $"{expectedText} owners not find"); },
                 "Check availability owners with status 'Active'");           
            actualOwnerNumber = adminOwnersPage.GetUserNumberByStatus(expectedText);
            adminOwnersPage.ClickLockButton(actualOwnerNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminOwnersPage.GetActualStatusByNumber(actualOwnerNumber);

            //Assert            
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} - status now, must be Banned"); },
                "Check new owner status, must be 'Banned'");            
        }

        [Test, Order(7)]
        [AllureDescription("Test for admin role, to check the possibility to block owners in tab 'Owners'=>'Active'")]
        [AllureOwner("Vitalii")]
        [AllureTag("Admin", "TestCase ID#00004")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("Owners")]
        [AllureStory("Ban")]
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
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityAnyUsers(), "Owners not find on this page"); },
                "Check availability owners on Active tab page");            
            ownerName = adminOwnersPage.GetNameByNumber(num);
            adminOwnersPage.ClickLockButton(num);
            adminOwnersPage.ClickBannedTabButton();

            //Assert
            AllureLifecycle.Instance.WrapInStep(
               () => { Assert.AreEqual(true, adminOwnersPage.CheckOnUserName(ownerName), "Owner name not find"); },
               "Check the name in the Banned tab");            
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
        [AllureDescription("Test for admin role, to check the possibility to unblock owners in tab 'Owners'=>'All'")]
        [AllureOwner("Vitalii")]
        [AllureTag("Admin", "TestCase ID#00013")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("Owners")]
        [AllureStory("Unban")]
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
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityUsersByStatus(expectedText), $"{expectedText} owners not find"); },
                "Check availability owners with status 'Banned'");            
            actualOwnerNumber = adminOwnersPage.GetUserNumberByStatus(expectedText);
            adminOwnersPage.ClickLockButton(actualOwnerNumber);
            driver.Navigate().Refresh();
            string actualText2 = adminOwnersPage.GetActualStatusByNumber(actualOwnerNumber);

            //Assert            
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.AreNotEqual(actualText2, expectedText, $"{actualText2} - status now, must be Active"); },
                "Check new owner status, must be 'Active'");            
        }

        [Test, Order(10)]
        [AllureDescription("Test for admin role, to check the possibility to unblock owners in tab 'Owners'=>'Banned'")]
        [AllureOwner("Vitalii")]
        [AllureTag("Admin", "TestCase ID#00014")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("Owners")]
        [AllureStory("Unban")]
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
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(true, adminOwnersPage.CheckAvailabilityAnyUsers(), "Owners not find on this page"); },
                 "Check availability users on Banned tab");              
            ownerName = adminOwnersPage.GetNameByNumber(num);
            adminOwnersPage.ClickLockButton(num);
            adminOwnersPage.ClickActiveTabButton();

            //Assert
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.AreEqual(true, adminOwnersPage.CheckOnUserName(ownerName), "Owner name not find"); },
              "Check the name in the Active tab");            
        }

        [Test, Order(11)]
        [AllureDescription("Test for admin role, to check info about all restaurant list'")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Admin", "TestCase ID#00009")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("All Restaurant tab")]
        [AllureStory("Check info")]
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
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.That(actualResult > 0, $"There are {actualResult} All restaurants"); },
              "");
        }
        [Test, Order(12)]
        [AllureDescription("Test for admin role, to check info about unapproved restaurant list'")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Admin", "TestCase ID#00010")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("Unapproved Restaurant Tab")]
        [AllureStory("Check info")]
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

            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.That(actualResult > 0, $"There are {actualResult} Unapproved restaurants"); },
              "");
        }
        [Test, Order(13)]
        [AllureDescription("Test for admin role, to check info about approved restaurant list'")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Admin", "TestCase ID#00011")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("Approved Restaurant Tab")]
        [AllureStory("Check info")]
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
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.That(actualResult > 0, $"There are {actualResult} Approved restaurants"); },
              "");
        }
        [Test, Order(14)]
        [AllureDescription("Test for admin role, to check info about archived restaurant list'")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Admin", "TestCase ID#00012")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Admin")]
        [AllureFeature("Archived Restaurant Tab")]
        [AllureStory("Check info")]
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
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.That(actualResult > 0, $"There are {actualResult} Archived restaurants"); },
              "");
        }
    }
}