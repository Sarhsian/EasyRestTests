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
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ProfileCurrentOrdersPageObject profileCurrentOrdersPageObject = new ProfileCurrentOrdersPageObject(driver);
            string expectedDeclineMessage = "Order declined";

            // Act
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("katiedoyle@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
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
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ProfileOrderHistoryPageObject profileOrderHistoryPageObject = new ProfileOrderHistoryPageObject(driver);
            string expectedStatusMessage = "Order status changed to Waiting for confirm";

            // Act                        
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("katiedoyle@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            profileOrderHistoryPageObject.ClickOrderHistoryTab();
            profileOrderHistoryPageObject.ClickHiscotyTab();
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
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            BaseHeaderPageObject baseHeaderPageObject = new BaseHeaderPageObject(driver);
            ResturantListPageObject resturantListPageObject = new ResturantListPageObject(driver);
            string expectedStatusMessage = "Order status changed to Waiting for confirm";

            // Act
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("katiedoyle@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
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
