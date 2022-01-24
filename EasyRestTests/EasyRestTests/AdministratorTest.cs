using NUnit.Framework;
using PageObjects;

namespace Tests
{
    class AdministratorTest : BaseTest
    {
        [Test]
        public void AssignedWaiterTab_WhenLoggedIn_ShouldShowInfoAboutSelectedOrder()
        {
            //Arrange            
            var signInPage = new SignInPage(driver);
            var administratorPanel = new AdministratorPanel(driver);
            string exceptedText = "Order summary";
            string actualText;

            //Act
            signInPage.SignInAsAdministrator();            
            administratorPanel.ClickAssignedWaiterButton();
            administratorPanel.ClickArrowDownButton(1);           
            actualText = administratorPanel.GetOrderInfo();
            //Assert
            Assert.AreEqual(exceptedText, actualText, $"{actualText} is not equal {exceptedText} ");
        }

        [Test]
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
            Assert.That(actualText.Contains(exceptedText), $"{actualText} is not equal {exceptedText} ");
        }

        [Test]
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
            Assert.That(actualText.Contains(exceptedText), $"{actualText} is not equal {exceptedText} ");

        }

        [Test]
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
            Assert.AreEqual(exceptedText, actualText, $"{actualText} is not equal {exceptedText} ");
        }
    }
}
