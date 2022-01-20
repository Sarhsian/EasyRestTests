using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tests
{
    public class OwnerManageDetailAboutRestaurantTest : BaseTest
    {
        public string GetRandomManageDetailAboutRestaurantString()
        {
            var chars = "abcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[5];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
            //RandomStringForCreatingModerator
        }

        [Test]
        public void PositiveManageDetailAboutRestaurantTest()
        {

            string name = GetRandomManageDetailAboutRestaurantString();
            string address = GetRandomManageDetailAboutRestaurantString();
            //OurInformationForPositiveEditDetailsOfRestaurant
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPage signInPageObject
                = new SignInPage(driver);
            signInPageObject.SendTextToEmailTextField("jasonbrown@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
            //PositiveOwnerSignIn
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            ClientTabCurrentOrders profileCurrentOrdersPageObject
                = new ClientTabCurrentOrders(driver);
            ClientProfileMyRestaurantPageObject clientProfileMyRestaurantPageObject
                = new ClientProfileMyRestaurantPageObject(driver);
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            driver.Navigate().Refresh();
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickManageButtonForOwner();
            //PositiveManageRestaurantPage
            ManageRestaurantPageObject manageRestaurantPageObject
               = new ManageRestaurantPageObject(driver);
            manageRestaurantPageObject.ClickDetailsForOwnerTab();
            manageRestaurantPageObject.ClickEditInformationButton();
            //PositiveEditInformationAboutRestaurantPage
            manageRestaurantPageObject.SendRestaurantNameTextField(name);
            manageRestaurantPageObject.SendRestaurantAddressTextField(address);
            manageRestaurantPageObject.SendRestaurantPhoneTextField("123");
            manageRestaurantPageObject.SendRestaurantDescriptionTextField("Very delicious!)");
            manageRestaurantPageObject.ClickUpdateNewDetailsAboutRestaurantButton();
            Thread.Sleep(2000);
        }

        [Test]
        public void NegativeManageDetailAboutRestaurantTest()
        {
            //OurInformationForPositiveEditDetailsOfRestaurant
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPage signInPageObject
                = new SignInPage(driver);
            signInPageObject.SendTextToEmailTextField("jasonbrown@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
            //PositiveOwnerSignIn
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            ClientProfileMyRestaurantPageObject clientProfileMyRestaurantPageObject
                = new ClientProfileMyRestaurantPageObject(driver);
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            driver.Navigate().Refresh();
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickManageButtonForOwner();
            //PositiveManageRestaurantPage
            ManageRestaurantPageObject manageRestaurantPageObject
               = new ManageRestaurantPageObject(driver);
            manageRestaurantPageObject.ClickDetailsForOwnerTab();
            manageRestaurantPageObject.ClickEditInformationButton();
            //PositiveEditInformationPageAboutRestaurantPage
            manageRestaurantPageObject.SendRestaurantPhoneTextField("456");
            manageRestaurantPageObject.SendRestaurantDescriptionTextField(" Yes of course!))");
            manageRestaurantPageObject.ClearRestaurantAddress();
            Thread.Sleep(2000);
            //Delete address
            manageRestaurantPageObject.ClickUpdateNewDetailsAboutRestaurantButton();
            Thread.Sleep(2000);
            string actualRestaurantAddressErrorMessageText = manageRestaurantPageObject.GetRestaurantAddressCannotBeEmptyErrorMessage();
            string expectedRestaurantAddressErrorMessageText = "Restaurant address cannot be empty";
            Assert.AreEqual(expectedRestaurantAddressErrorMessageText, actualRestaurantAddressErrorMessageText, $"{expectedRestaurantAddressErrorMessageText} is not equal for {actualRestaurantAddressErrorMessageText}");
            manageRestaurantPageObject.SendRestaurantAddressTextField("76353 Kimberly Bypass Suite 107Suttonburgh, NY 04699");
            //Assert for address error message
            Thread.Sleep(2000);
            manageRestaurantPageObject.ClearRestaurantName();
            Thread.Sleep(2000);
            //Delete name
            manageRestaurantPageObject.ClickUpdateNewDetailsAboutRestaurantButton();
            Thread.Sleep(2000);
            string actualRestaurantNameErrorMessageText = manageRestaurantPageObject.GetRestaurantNameCannotBeEmptyErrorMessage();
            string expectedRestaurantNameErrorMessageText = "Restaurant name cannot be empty";
            Assert.AreEqual(expectedRestaurantNameErrorMessageText, actualRestaurantNameErrorMessageText, $"{expectedRestaurantNameErrorMessageText} is not equal for {actualRestaurantNameErrorMessageText}");
            //Assert for name error message
            Thread.Sleep(2000);
            manageRestaurantPageObject.SendRestaurantNameTextField("Preston, Terrell and Warren");
            manageRestaurantPageObject.ClickUpdateNewDetailsAboutRestaurantButton();
            Thread.Sleep(2000);
        }
    }
} 