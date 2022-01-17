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
    public class NegativeCreatingRestaurantTest : BaseTest
    {
        public string GetRandomString()
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

        public string GetNegativeRandomNumberString()
        {
            var chars = "123456789";
            var stringChars = new char[3];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
            //RandomStringForNegativeCreatingModerator
        }

        [Test]

        public void negativeCreatingRestaurantTest()
        {
            string name = GetRandomString();
            string menuname = GetRandomString();
            string groupProductName = GetRandomString();
            string groupProductDescription = GetRandomString();
            string groupProductIngredients = GetRandomString();
            string negativeWaiterEmail = GetRandomString() + "@testcom";
            string negativeAdministratorEmail = GetRandomString() + "@testcom";
            string address = GetRandomString();
            string phoneNumber = GetNegativeRandomNumberString();
            string groupProductPrice = GetNegativeRandomNumberString();
            string password = GetNegativeRandomNumberString();
            //OurInformationForCreatingRestautantMenuWaiterAndAdministrator
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPageObject signInPageObject
                = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("katiedoyle@test.com");
            signInPageObject.SendTextToPasswordTextField("1111");
            signInPageObject.ClickSubmitButton();
            //PositiveClientSignIn
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            ProfileCurrentOrdersPageObject profileCurrentOrdersPageObject
                = new ProfileCurrentOrdersPageObject(driver);
            ClientProfileMyRestaurantPageObject clientProfileMyRestaurantPageObject
                = new ClientProfileMyRestaurantPageObject(driver);
           ManageRestaurantPageObject manageRestaurantPageObject
                = new ManageRestaurantPageObject(driver);
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            clientProfileMyRestaurantPageObject.ClickAddRestaurantButton();
            Thread.Sleep(2000);
            clientProfileMyRestaurantPageObject.ClickSubmitButton();
            //WeCanSeeErrorMessageToInputDate
            string actualMenuNameErrorMessageText = manageRestaurantPageObject.GetCreateMenuNameIsRequiredErrorMessage();
            string expectedMenuNameErrorMessageText = "Name is required";
            Assert.AreEqual(expectedMenuNameErrorMessageText, actualMenuNameErrorMessageText, $"{expectedMenuNameErrorMessageText} is not equal for {actualMenuNameErrorMessageText}");
            string actualMenuAddressErrorMessageText = manageRestaurantPageObject.GetCreateMenuAddressIsRequiredErrorMessage();
            string expectedMenuAddressErrorMessageText = "Address is required";
            Assert.AreEqual(expectedMenuAddressErrorMessageText, actualMenuAddressErrorMessageText, $"{expectedMenuAddressErrorMessageText} is not equal for {actualMenuAddressErrorMessageText}");
            //AssertForCreateRestaurant
            clientProfileMyRestaurantPageObject.SendTextToNameTextField(name);
            clientProfileMyRestaurantPageObject.SendTextToAddressTextField(address);
            clientProfileMyRestaurantPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            //NegativeAndThanPositiveCreateRestaurant
            driver.Navigate().Refresh();
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutNegativeRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickManageNegativeRestaurantButton();
            //PositiveManageRestaurantPage
            manageRestaurantPageObject.ClickMenuNeagtiveRestaurantTab();
            manageRestaurantPageObject.ClickCreateMenuNeagtiveRestaurantTab();
            manageRestaurantPageObject.SendMenuNameTextField(menuname);
            manageRestaurantPageObject.ClickNextCreateMenuNameButton();
            manageRestaurantPageObject.SendGroupProductNameTextfield(groupProductName);
            manageRestaurantPageObject.SendGroupProductDescriptionTextfield(groupProductDescription);
            manageRestaurantPageObject.SendGroupProductIngredientsTextfield(groupProductIngredients);
            manageRestaurantPageObject.SendGroupProductPriceTextfield(groupProductPrice);
            manageRestaurantPageObject.ClickGroupProductCategoryButton();
            manageRestaurantPageObject.ClickSelectMeatProductCategory();
            manageRestaurantPageObject.ClickNextCreateMuneButtonStepTwo();
            Thread.Sleep(2000);
            manageRestaurantPageObject.ClickFinishCreateMuneButton();
            //PositiveCreateMenu
            manageRestaurantPageObject.ClickWaitersNegativeTab();
            manageRestaurantPageObject.ClickAddWaiterButton();
            Thread.Sleep(2000);
            manageRestaurantPageObject.ClickSubmitCreateNewWaiterButton();
            Thread.Sleep(2000);
            //WeCanSeeErrorMessageToInputDate
            string actualNewWaiterNameIsRequiredErrorMessageText = manageRestaurantPageObject.GetCreateNewWaiterNameIsRequiredErrorMessage();
            string expectedNewWaiterNameIsRequiredErrorMessageText = "Name is required";
            Assert.AreEqual(expectedNewWaiterNameIsRequiredErrorMessageText, actualNewWaiterNameIsRequiredErrorMessageText, $"{expectedNewWaiterNameIsRequiredErrorMessageText} is not equal for {actualNewWaiterNameIsRequiredErrorMessageText}");
            string actualNewWaiterMailIsRequiredErrorMessageText = manageRestaurantPageObject.GetCreateNewWaiterMailIsRequiredErrorMessage();
            string expectedNewWaiterMailIsRequiredErrorMessageText = "Mail is required";
            Assert.AreEqual(expectedNewWaiterMailIsRequiredErrorMessageText, actualNewWaiterMailIsRequiredErrorMessageText, $"{expectedNewWaiterMailIsRequiredErrorMessageText} is not equal for {actualNewWaiterMailIsRequiredErrorMessageText}");
            string actualNewWaiterPasswordIsRequiredErrorMessageText = manageRestaurantPageObject.GetCreateNewWaiterPasswordIsRequiredErrorMessage();
            string expectedNewWaiterPasswordIsRequiredErrorMessageText = "Password is required";
            Assert.AreEqual(expectedNewWaiterPasswordIsRequiredErrorMessageText, actualNewWaiterPasswordIsRequiredErrorMessageText, $"{expectedNewWaiterPasswordIsRequiredErrorMessageText} is not equal for {actualNewWaiterPasswordIsRequiredErrorMessageText}");
            string actualNewWaiterPhoneNumberIsRequiredErrorMessageText = manageRestaurantPageObject.GetCreateNewWaiterPhoneNumberIsRequiredErrorMessage();
            string expectedNewWaiterPhoneNumberIsRequiredErrorMessageText = "Phone number is required";
            Assert.AreEqual(expectedNewWaiterPhoneNumberIsRequiredErrorMessageText, actualNewWaiterPhoneNumberIsRequiredErrorMessageText, $"{expectedNewWaiterPhoneNumberIsRequiredErrorMessageText} is not equal for {actualNewWaiterPhoneNumberIsRequiredErrorMessageText}");
            //AssertForWaiter
            manageRestaurantPageObject.SendWaiterNameTextField(name);
            manageRestaurantPageObject.SendWaiterEmailTextField(negativeWaiterEmail);
            manageRestaurantPageObject.SendWaiterPasswordTextField(password);
            manageRestaurantPageObject.SendWaiterPhoneNumberTextField(phoneNumber);
            Thread.Sleep(3000);
            manageRestaurantPageObject.ClickSubmitCreateNewWaiterButton();
            Thread.Sleep(2000);
            //Lets wait Something went wrong error message
            string actualNewWaiterSomethingWentWrongErrorMessageText = manageRestaurantPageObject.GetCreateNewWaiterSomethingWentWrongErrorMessage();
            string expectedNewWaiterSomethingWentWrongErrorMessageText = "Something went wrong";
            Assert.AreEqual(expectedNewWaiterSomethingWentWrongErrorMessageText, actualNewWaiterSomethingWentWrongErrorMessageText, $"{expectedNewWaiterSomethingWentWrongErrorMessageText} is not equal for {actualNewWaiterSomethingWentWrongErrorMessageText}");
            //NegativePositiveCreateNewWaiter
            manageRestaurantPageObject.ClickAdministratorNegativeTab();
            manageRestaurantPageObject.ClickAddAdministratorButton();
            Thread.Sleep(2000);
            manageRestaurantPageObject.ClickSubmitCreateNewAdministratorButton();
            Thread.Sleep(2000);
            //WeCanSeeErrorMessageToInputDate
            string actualNewAdministratorNameIsRequiredErrorMessageText = manageRestaurantPageObject.GetCreateNewAdministratorNameIsRequiredErrorMessage();
            string expectedNewAdministratorNameIsRequiredErrorMessageText = "Name is required";
            Assert.AreEqual(expectedNewAdministratorNameIsRequiredErrorMessageText, actualNewAdministratorNameIsRequiredErrorMessageText, $"{expectedNewAdministratorNameIsRequiredErrorMessageText} is not equal for {actualNewAdministratorNameIsRequiredErrorMessageText}");
            string actualNewAdministratorMailIsRequiredErrorMessageText = manageRestaurantPageObject.GetCreateNewAdministratorMailIsRequiredErrorMessage();
            string expectedNewAdministratorMailIsRequiredErrorMessageText = "Mail is required";
            Assert.AreEqual(expectedNewAdministratorMailIsRequiredErrorMessageText, actualNewAdministratorMailIsRequiredErrorMessageText, $"{expectedNewAdministratorMailIsRequiredErrorMessageText} is not equal for {actualNewAdministratorMailIsRequiredErrorMessageText}");
            string actualNewAdministratorPasswordIsRequiredErrorMessageText = manageRestaurantPageObject.GetCreateNewAdministratorPasswordIsRequiredErrorMessage();
            string expectedNewAdministratorPasswordIsRequiredErrorMessageText = "Password is required";
            Assert.AreEqual(expectedNewAdministratorPasswordIsRequiredErrorMessageText, actualNewAdministratorPasswordIsRequiredErrorMessageText, $"{expectedNewAdministratorPasswordIsRequiredErrorMessageText} is not equal for {actualNewAdministratorPasswordIsRequiredErrorMessageText}");
            string actualNewAdministratorPhoneNumberIsRequiredErrorMessageText = manageRestaurantPageObject.GetCreateNewAdministratorPhoneNumberIsRequiredErrorMessage();
            string expectedNewAdministratorPhoneNumberIsRequiredErrorMessageText = "Phone number is required";
            Assert.AreEqual(expectedNewAdministratorPhoneNumberIsRequiredErrorMessageText, actualNewAdministratorPhoneNumberIsRequiredErrorMessageText, $"{expectedNewAdministratorPhoneNumberIsRequiredErrorMessageText} is not equal for {actualNewAdministratorPhoneNumberIsRequiredErrorMessageText}");
            //AssertForAdministrator
            manageRestaurantPageObject.SendAdministratorNameTextField(name);
            manageRestaurantPageObject.SendAdministratorEmailTextField(negativeAdministratorEmail);
            manageRestaurantPageObject.SendAdministratorPasswordTextField(password);
            manageRestaurantPageObject.SendAdministratorPhoneNumberTextField(phoneNumber);
            Thread.Sleep(3000);
            manageRestaurantPageObject.ClickSubmitCreateNewAdministratorButton();
            Thread.Sleep(2000);
            string actualNewAdministratorSomethingWentWrongErrorMessageText = manageRestaurantPageObject.GetCreateNewAdministratorSomethingWentWrongErrorMessage();
            string expectedNewAdministratorSomethingWentWrongErrorMessageText = "Something went wrong";
            Assert.AreEqual(expectedNewAdministratorSomethingWentWrongErrorMessageText, actualNewAdministratorSomethingWentWrongErrorMessageText, $"{expectedNewAdministratorSomethingWentWrongErrorMessageText} is not equal for {actualNewAdministratorSomethingWentWrongErrorMessageText}");
            //NegativeCreateNewAdministrator
            manageRestaurantPageObject.ClickProfileLogoButton();
            manageRestaurantPageObject.ClickMyRestaurantsButton();
            //PositiveRestaurantCreatAndBackToMyRestaurantTab
            Thread.Sleep(3000);
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutNegativeRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickArchiveButton();
            //PositiveArchiveRestaurant
        }
    }
} 