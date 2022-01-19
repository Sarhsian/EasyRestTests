using NUnit.Framework;
using PageObjects;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    class AdministratorTest : BaseTest
    {
        [Test]
        public void AssignedWaiter()
        {
            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPage signInPageObject = new SignInPage(driver);
            AdministratorPanelPageObject administratorPanel = new AdministratorPanelPageObject(driver);
            string exceptedText = "Order summary";
            string actualText;

            //Act
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("tanyasanchez@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            administratorPanel.ClickAssignedWaiterButton();
            administratorPanel.ClickArrowDownButton(1);           
            actualText = administratorPanel.GetOrderInfo();
            //Assert
            Assert.AreEqual(exceptedText, actualText, $"{actualText} is not equal {exceptedText} ");
        }

        [Test]
        public void WaitingToConfirm()
        {
            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPage signInPageObject = new SignInPage(driver);
            AdministratorPanelPageObject administratorPanel = new AdministratorPanelPageObject(driver);
            string exceptedText = "Accepted";
            string actualText;

            //Act
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("tanyasanchez@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            administratorPanel.ClickWaitingForConfirmTabButton();
            administratorPanel.ClickArrowDownButton(1);
            administratorPanel.ClickAcceptButton();
            actualText = administratorPanel.GetApprovedMessageText();
            //Assert
            Assert.That(actualText.Contains(exceptedText), $"{actualText} is not equal {exceptedText} ");
        }

        [Test]
        public void WaitingToAssign()
        {
            //Arrange
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            SignInPage signInPageObject = new SignInPage(driver);
            AdministratorPanelPageObject administratorPanel = new AdministratorPanelPageObject(driver);
            string exceptedText = "Assigned waiter";
            string actualText;

            //Act
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            signInPageObject.SendTextToEmailTextField("tanyasanchez@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            administratorPanel.ClickAcceptedTabButton();
            administratorPanel.ClickArrowDownButton(1);
            administratorPanel.ClickFirstWaiterButton();
            administratorPanel.ClickAssignButton();
            actualText = administratorPanel.GetAssignedMessageText();
            //Assert
            Assert.That(actualText.Contains(exceptedText), $"{actualText} is not equal {exceptedText} ");

        }

        [Test]
        public void Waiter()
        {
            //Arrange            
            SignInPage signInPageObject = new SignInPage(driver);
            AdministratorPanelPageObject administratorPanel = new AdministratorPanelPageObject(driver);
            string exceptedText = "Order summary";
            string actualText;

            //Act
            signInPageObject.SignIn("tanyasanchez@test.com", "1");
            administratorPanel.ClickWaitersTabButton();
            administratorPanel.ClickArrowDownButton(1);
            administratorPanel.ClickArrowDownSubButton(1);
            actualText = administratorPanel.GetOrderInfo();
            //Assert
            Assert.AreEqual(exceptedText, actualText, $"{actualText} is not equal {exceptedText} ");
        }
    }
}
