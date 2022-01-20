using NUnit.Framework;
using PageObjects;

namespace Tests
{
    public class ClientTest : BaseTest
    {
        [Test]
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
            Assert.AreEqual(expectedDeclineMessage, actualDeclineMessage, $"{expectedDeclineMessage} is not equal {actualDeclineMessage}");
        }

        [Test]
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
            Assert.AreEqual(expectedStatusMessage, actualStatusMessage, $"{expectedStatusMessage} is not equal {actualStatusMessage}");
        }

        [Test]
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
            Assert.AreEqual(expectedStatusMessage, actualStatusMessage, $"{expectedStatusMessage} is not equal {actualStatusMessage}");
        }
    }
}
