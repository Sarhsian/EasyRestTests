﻿using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PageObjects;

namespace Tests
{
    [AllureNUnit]    
    [AllureLink("https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=737541119")]
    [AllureSuite("NUnit")]
    class AdministratorTest : BaseTest
    {

        [Test]
        [AllureDescription("Test for administrator role, to check posibility to see information about assigned waiter order")]
        [AllureOwner("Vitalii")]
        [AllureTag("Administator","TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Administrator")]
        [AllureFeature("Assigned waiter")]
        [AllureStory("Check info about order")]
        public void AssignedWaiterTab_WhenLoggedIn_ShouldShowInfoAboutSelectedOrder()
        {
            //Arrange            
            var signInPage = new SignInPage(driver);
            var administratorPanel = new AdministratorPanel(driver);
            string exceptedText = "Order summary";
            string actualText;

            //Act
            
            signInPage.SignInAsAdministrator();            
            administratorPanel.ClickAssignedWaiterTabButton();
            administratorPanel.ClickArrowDownButton(1);           
            actualText = administratorPanel.GetOrderInfo();

            //Assert
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(exceptedText, actualText, $"{actualText} is not equal {exceptedText} "); },
                 "Check for text");
        }

        [Test]
        [AllureDescription("Test for administrator role, to check posibility to accept waiting to confirm orders")]
        [AllureOwner("Volodymyr")]
        [AllureTag("Administator", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Administrator")]
        [AllureFeature("Waiting to confirm")]
        [AllureStory("Confirm order")]
        public void WaitingToConfirm_WhenLoggedIn_ShouldShowMessage_Accepted()
        {
            //Arrange            
            var signInPage = new SignInPage(driver);
            var administratorPanel = new AdministratorPanel(driver);
            string exceptedText = "Accepted";
            string actualText;

            //Act
            signInPage.SignInAsAdministrator();
            administratorPanel.ClickWaitingForConfirmTabButton();
            administratorPanel.ClickArrowDownButton(1);
            administratorPanel.ClickAcceptButton();
            actualText = administratorPanel.GetApprovedMessageText();
            //Assert
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.That(actualText.Contains(exceptedText), $"{actualText} is not equal {exceptedText} "); },
                 "Check the text");
        }

        [Test]
        [AllureDescription("Test for administrator role, to check posibility to assign accepted orders")]
        [AllureOwner("Volodymyr")]
        [AllureTag("Administator", "TestCase ID#00002")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Administrator")]
        [AllureFeature("Accepted")]
        [AllureStory("Assign order")]
        public void WaitingToAssign_WhenLoggedIn_ShouldShowMessage_AssignedWaiter() 
        {
            //Arrange            
            var signInPage = new SignInPage(driver);
            var administratorPanel = new AdministratorPanel(driver);
            string exceptedText = "Assigned waiter";
            string actualText;

            //Act
            signInPage.SignInAsAdministrator();
            administratorPanel.ClickAcceptedTabButton();
            administratorPanel.ClickArrowDownButton(1);
            administratorPanel.ClickFirstWaiterButton();
            administratorPanel.ClickAssignButton();
            actualText = administratorPanel.GetAssignedMessageText();
            //Assert
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.That(actualText.Contains(exceptedText), $"{actualText} is not equal {exceptedText} "); },
                 "Check the text");
        }

        [Test]
        [AllureDescription("Test for administrator role, to check posibility to see the information about waiter's orders")]
        [AllureOwner("Vitalii")]
        [AllureTag("Administator", "TestCase ID#00004")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Administrator")]
        [AllureFeature("Waiter")]
        [AllureStory("Check info about order")]
        public void WaiterTab_WhenLoggedIn_ShouldShowInfoAboutOrder()
        {
            //Arrange            
            var signInPage = new SignInPage(driver);
            var administratorPanel = new AdministratorPanel(driver);
            string exceptedText = "Order summary";
            string actualText;

            //Act
            signInPage.SignInAsAdministrator();
            administratorPanel.ClickWaitersTabButton();
            administratorPanel.ClickArrowDownButton(1);
            administratorPanel.ClickArrowDownSubButton(1);
            actualText = administratorPanel.GetOrderInfo();

            //Assert
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.AreEqual(exceptedText, actualText, $"{actualText} is not equal {exceptedText} "); },
                "Check for text");            
        }
    }
}
