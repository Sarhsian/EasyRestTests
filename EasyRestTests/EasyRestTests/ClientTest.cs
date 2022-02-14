using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PageObjects;

namespace Tests
{
    [AllureNUnit]
    [AllureLink("https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=1401539253")]
    [AllureSuite("NUnit")]
    public class ClientTest : BaseTest
    {
        [Test, Order(1)]
        [AllureDescription("Test for client role, to check posibility to decline order in 'Current Orders'=>'Waiting to confirm'")]
        [AllureOwner("Sarhsian")]
        [AllureTag("Client", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureEpic("Client")]
        [AllureFeature("Waiting for confirm")]
        [AllureStory("Decline")]
        public void ClientDeclinesOrder_WhenLoggedIn_ShouldShowMessage()
        {
            // Arrange
            var signInPageObject = new SignInPage(driver);
            var loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            var profileCurrentOrdersPageObject = new ClientCurrentOrdersTab(driver);
            string expectedDeclineMessage = "Order declined";

            // Act
            signInPageObject.SignInAsClient();
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            profileCurrentOrdersPageObject.ClickCurrentOrdersTab();
            profileCurrentOrdersPageObject.ClickWaitingForConfirmTab();
            profileCurrentOrdersPageObject.ClickOrderInfoArrowDownButton();
            profileCurrentOrdersPageObject.ClickWaitingForConfirmDeclineButton();
            string actualDeclineMessage = profileCurrentOrdersPageObject.GetOrderDeclinedMessage();

            // Assert
            AllureLifecycle.Instance.WrapInStep(
            () => { Assert.AreEqual(expectedDeclineMessage, actualDeclineMessage, $"{expectedDeclineMessage} is not equal {actualDeclineMessage}"); }, 
            "Check the selected order must be delleted from 'Waiting to Confirm tab'");
        }

        [Test, Order(2)]
        [AllureDescription("Test for client role, to check posibility to reorder order in 'Order History'=>'History'")]
        [AllureOwner("Sarhsian")]
        [AllureTag("Client", "TestCase ID#00002")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Client")]
        [AllureFeature("History")]
        [AllureStory("Reorder")]
        public void ClientReordersOrder_WhenLoggedIn_ShouldShowMessage()
        {
            // Arrange
            var signInPageObject = new SignInPage(driver);
            var loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            var profileOrderHistoryPageObject = new ClientOrderHistoryTab(driver);
            string expectedStatusMessage = "Order status changed to Waiting for confirm";

            // Act                        
            signInPageObject.SignInAsClient();
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            profileOrderHistoryPageObject.ClickOrderHistoryTab();
            profileOrderHistoryPageObject.ClickHistotyTab();
            profileOrderHistoryPageObject.FirstOrderInfoArrowDownButtonClick();
            profileOrderHistoryPageObject.ReorderButtonClick();
            profileOrderHistoryPageObject.SubmitButtonClick();
            string actualStatusMessage = profileOrderHistoryPageObject.GetOrderStatusMessage();

            // Assert
            AllureLifecycle.Instance.WrapInStep(
            () => { Assert.AreEqual(expectedStatusMessage, actualStatusMessage, $"{expectedStatusMessage} is not equal {actualStatusMessage}"); },
                "Check the selected order must be added to Waiting to Confirm");
        }

        [Test, Order(3)]
        [AllureDescription("Test for client role, to check posibility to make order one item in 'Resturant List'")]
        [AllureOwner("Sarhsian")]
        [AllureTag("Client", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureEpic("Client")]
        [AllureFeature("ResturantList")]
        [AllureStory("Submit Order")]
        public void ClientMakesOrderOfOneItem_WhenLoggedIn_ShouldShowMessage()
        {
            // Arrange
            var signInPageObject = new SignInPage(driver);
            var baseHeaderPageObject = new BaseHeaderPageObject(driver);
            var resturantListPageObject = new ResturantListPage(driver);
            string expectedStatusMessage = "Order status changed to Waiting for confirm";

            // Act
            signInPageObject.SignInAsClient();
            baseHeaderPageObject.ClickRestaurantsListButton();
            resturantListPageObject.ClickWatchMenuButton();
            resturantListPageObject.ClickNextButton();
            resturantListPageObject.ClickSubmitOrderButton();
            resturantListPageObject.ClickSubmitButton();
            string actualStatusMessage = resturantListPageObject.GetOrderStatusMessage();

            // Assert
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.AreEqual(expectedStatusMessage, actualStatusMessage, $"{expectedStatusMessage} is not equal {actualStatusMessage}"); },
                "Check the order must be added to 'Waiting to Confirm" );
        }
    }
}
