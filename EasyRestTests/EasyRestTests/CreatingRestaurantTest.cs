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
    public class CreatingRestaurantTest : BaseTest
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

        public string GetRandomNumberString()
        {
            var chars = "123456789";
            var stringChars = new char[8];
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

        public void PositiveCreatingRestaurantTest()
        {
            string name = GetRandomString();
            string menuname = GetRandomString();
            string groupProductName = GetRandomString();
            string groupProductDescription = GetRandomString();
            string groupProductIngredients = GetRandomString();
            string waiterEmail = GetRandomString() + "@test.com";
            string administratorEmail = GetRandomString() + "@test.com";
            string address = GetRandomString();
            string phoneNumber = GetRandomNumberString();
            string groupProductPrice = GetRandomNumberString();
            string password = GetRandomNumberString();
            //OurInformationForCreatingRestautantMenuWaiterAndAdministrator
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPage signInPageObject
                = new SignInPage(driver);
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
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            clientProfileMyRestaurantPageObject.ClickAddRestaurantButton();
            clientProfileMyRestaurantPageObject.SendTextToNameTextField(name);
            clientProfileMyRestaurantPageObject.SendTextToAddressTextField(address);
            clientProfileMyRestaurantPageObject.ClickSubmitButton();
            driver.Navigate().Refresh();
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickManageButton();
            //PositiveManageRestaurantPage
            ManageRestaurantPageObject manageRestaurantPageObject
                = new ManageRestaurantPageObject(driver);
            manageRestaurantPageObject.ClickDetailsTab();
            manageRestaurantPageObject.ClickMenuesTab();
            manageRestaurantPageObject.ClickCreateMenuTab();
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
            manageRestaurantPageObject.ClickWaitersTab();
            manageRestaurantPageObject.ClickAddWaiterButton();
            manageRestaurantPageObject.SendWaiterNameTextField(name);
            manageRestaurantPageObject.SendWaiterEmailTextField(waiterEmail);
            manageRestaurantPageObject.SendWaiterPasswordTextField(password);
            manageRestaurantPageObject.SendWaiterPhoneNumberTextField(phoneNumber);
            Thread.Sleep(3000);
            manageRestaurantPageObject.ClickSubmitCreateNewWaiterButton();
            Thread.Sleep(2000);
            //PositiveCreateNewWaiter
            manageRestaurantPageObject.ClickAdministratorTab();
            manageRestaurantPageObject.ClickAddAdministratorButton();
            manageRestaurantPageObject.SendAdministratorNameTextField(name);
            manageRestaurantPageObject.SendAdministratorEmailTextField(administratorEmail);
            manageRestaurantPageObject.SendAdministratorPasswordTextField(password);
            manageRestaurantPageObject.SendAdministratorPhoneNumberTextField(phoneNumber);
            Thread.Sleep(3000);
            manageRestaurantPageObject.ClickSubmitCreateNewAdministratorButton();
            Thread.Sleep(2000);
            //PositiveCreateNewAdministrator
            manageRestaurantPageObject.ClickProfileLogoButton();
            manageRestaurantPageObject.ClickMyRestaurantsButton();
            //PositiveRestaurantCreatAndBackToMyRestaurantTab
            Thread.Sleep(3000);
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickArchiveButton();
            //PositiveArchiveRestaurant
        }
    }
}