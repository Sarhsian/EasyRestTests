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
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("katiedoyle@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();         
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            ProfileCurrentOrdersPageObject profileCurrentOrdersPageObject = new ProfileCurrentOrdersPageObject(driver);
            profileCurrentOrdersPageObject.ClickCurrentOrdersTab();
            profileCurrentOrdersPageObject.ClickWaitingForConfirmTab();                                  
            profileCurrentOrdersPageObject.ClickOrderInfoArrowDownButton();          
            profileCurrentOrdersPageObject.ClickWaitingForConfirmDeclineButton();
            string actualDeclineMessage = profileCurrentOrdersPageObject.GetOrderDeclinedMessage();
            string expectedDeclineMessage = "Order declined";
            Assert.AreEqual(expectedDeclineMessage, actualDeclineMessage, $"{expectedDeclineMessage} is not equal {actualDeclineMessage}");
        }

        [Test]
        public void PositiveOrderHistoryTabReorderTest()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeaderPageObject = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeaderPageObject.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("katiedoyle@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            ProfileOrderHistoryPageObject profileOrderHistoryPageObject = new ProfileOrderHistoryPageObject(driver);
            profileOrderHistoryPageObject.ClickOrderHistoryTab();
            profileOrderHistoryPageObject.ClickHiscotyTab();
            profileOrderHistoryPageObject.FirstOrderInfoArrowDownButtonClick();
            profileOrderHistoryPageObject.ReorderButtonClick();
            profileOrderHistoryPageObject.SubmitButtonClick();
            string actualStatusMessage = profileOrderHistoryPageObject.GetOrderStatusMessage();
            string expectedStatusMessage = "Order status changed to Waiting for confirm";
            Assert.AreEqual(expectedStatusMessage, actualStatusMessage, $"{expectedStatusMessage} is not equal {actualStatusMessage}");
        }
    }
}
