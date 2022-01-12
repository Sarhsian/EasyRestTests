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
            SignInPageObject signInPageObject = new SignInPageObject(driver);
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
    }
}
