﻿using NUnit.Framework;
using PageObjects;
using System;
using System.Threading;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Tests
{
    [AllureNUnit]
    [AllureLink("https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=1816686683")]
    [AllureSuite("NUnit")]
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
        [AllureDescription("Test for owner role, to check posibility to edit details about restaurant")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Owner", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Owner")]
        [AllureFeature("Details of restaurant")]
        [AllureStory("Edit")]
        public void OwnerManageRestaurant_DetailTab_WhenLoggedIn_ShouldEditDetailsAboutRestaurant()
        {
            //OurInformationForPositiveEditDetailsOfRestaurant
            string name = GetRandomManageDetailAboutRestaurantString();
            string address = GetRandomManageDetailAboutRestaurantString();
            //Arrange
            SignInPage signInPageObject
                = new SignInPage(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ClientProfileMyRestaurantTab clientProfileMyRestaurantPageObject
                = new ClientProfileMyRestaurantTab(driver);
            ManageRestaurant manageRestaurant
                = new ManageRestaurant(driver);
            ManageRestaurantDetailsTab manageRestaurantDetails
                = new ManageRestaurantDetailsTab(driver);
            //Act
            signInPageObject.SignInAsOwner(); //PositiveOwnerSignIn
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            driver.Navigate().Refresh();
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickManageButtonForOwner(); //PositiveManageRestaurantPage
            manageRestaurant.ClickDetailsForOwnerTab();
            manageRestaurantDetails.ClickEditInformationButton(); //PositiveEditInformationAboutRestaurantPage
            Thread.Sleep(2000);
            manageRestaurantDetails.SendRestaurantNameTextField(name);
            manageRestaurantDetails.SendRestaurantAddressTextField(address);
            manageRestaurantDetails.SendRestaurantPhoneTextField("123");
            manageRestaurantDetails.SendRestaurantDescriptionTextField("Very delicious!)");
            manageRestaurantDetails.ClickUpdateNewDetailsAboutRestaurantButton(); //UpdateDetail
            Thread.Sleep(2000);
        }
        [Test]
        [AllureDescription("Test for admin role, to check posibility to  edit details about restaurant with erros in process")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Owner", "TestCase ID#00002")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Owner")]
        [AllureFeature("Details of restaurant")]
        [AllureStory("Edit with errors in process")]
        public void OwnerManageRestaurant_DetailTab_WhenLoggedIn_ShouldNotEditDetailsAboutRestaurant()
        {
            //Arrange
            SignInPage signInPageObject
                = new SignInPage(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ClientProfileMyRestaurantTab clientProfileMyRestaurantPageObject
                = new ClientProfileMyRestaurantTab(driver);
            ManageRestaurant manageRestaurant
                = new ManageRestaurant(driver);
            ManageRestaurantDetailsTab manageRestaurantDetails
                = new ManageRestaurantDetailsTab(driver);
            //Act;
            signInPageObject.SignInAsOwner(); //PositiveOwnerSignIn
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickManageButtonForOwner(); //PositiveManageRestaurantPage
            manageRestaurant.ClickDetailsForOwnerTab();
            manageRestaurantDetails.ClickEditInformationButton();   //PositiveEditInformationPageAboutRestaurantPage
            Thread.Sleep(2000);
            manageRestaurantDetails.SendRestaurantPhoneTextField("456");
            manageRestaurantDetails.SendRestaurantDescriptionTextField(" Yes of course!))");
            manageRestaurantDetails.ClearRestaurantAddress();  //Delete address
            manageRestaurantDetails.ClickUpdateNewDetailsAboutRestaurantButton();
            Thread.Sleep(2000);
            //AssertForAddress
            string actualRestaurantAddressErrorMessageText = manageRestaurantDetails.GetRestaurantAddressCannotBeEmptyErrorMessage();
            string expectedRestaurantAddressErrorMessageText = "Restaurant address cannot be empty";
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(expectedRestaurantAddressErrorMessageText, actualRestaurantAddressErrorMessageText, $"{expectedRestaurantAddressErrorMessageText} is not equal for {actualRestaurantAddressErrorMessageText}"); },
                 "Check error message that restaurant address cannot be empty");
            manageRestaurantDetails.SendRestaurantAddressTextField("76353 Kimberly Bypass Suite 107Suttonburgh, NY 04699");
            Thread.Sleep(2000);
            manageRestaurantDetails.ClearRestaurantName();  //Delete name
            manageRestaurantDetails.ClickUpdateNewDetailsAboutRestaurantButton();
            //AssertForName
            string actualRestaurantNameErrorMessageText = manageRestaurantDetails.GetRestaurantNameCannotBeEmptyErrorMessage();
            string expectedRestaurantNameErrorMessageText = "Restaurant name cannot be empty";
            AllureLifecycle.Instance.WrapInStep(
                 () => { Assert.AreEqual(expectedRestaurantNameErrorMessageText, actualRestaurantNameErrorMessageText, $"{expectedRestaurantNameErrorMessageText} is not equal for {actualRestaurantNameErrorMessageText}"); },
                 "Check error message that restaurant name cannot be empty");
            manageRestaurantDetails.SendRestaurantNameTextField("Preston, Terrell and Warren");
            manageRestaurantDetails.ClickUpdateNewDetailsAboutRestaurantButton();  //DetailUpate
            Thread.Sleep(2000);
        }
    }
}