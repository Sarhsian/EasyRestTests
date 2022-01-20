using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Tests
{
    public class ClientTest : BaseTest
    {
        [Test]
        public void PositiveCurrentOrdersTabDeclineOrderTest()
        {
            // Arrange
            SignInPage signInPageObject = new SignInPage(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ClientCurrentOrdersTab profileCurrentOrdersPageObject = new ClientCurrentOrdersTab(driver);
            string expectedDeclineMessage = "Order declined";

            // Act
            signInPageObject.SignIn("katiedoyle@test.com", "1111");                                   
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
        public void PositiveOrderHistoryTabReorderTest()
        {
            // Arrange
            SignInPage signInPageObject = new SignInPage(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ClientOrderHistoryTab profileOrderHistoryPageObject = new ClientOrderHistoryTab(driver);
            string expectedStatusMessage = "Order status changed to Waiting for confirm";

            // Act                        
            signInPageObject.SignIn("katiedoyle@test.com", "1111");
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
        public void ClientMakingOrderOneItemTest()
        {
            // Arrange
            SignInPage signInPageObject = new SignInPage(driver);
            BaseHeaderPageObject baseHeaderPageObject = new BaseHeaderPageObject(driver);
            ResturantListPage resturantListPageObject = new ResturantListPage(driver);
            string expectedStatusMessage = "Order status changed to Waiting for confirm";

            // Act
            signInPageObject.SignIn("katiedoyle@test.com", "1111");
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
