using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PageObjects;
using System;
using System.Threading;

namespace Tests
{
    [AllureNUnit]
    [AllureSuite("NUnit")]
    [AllureLink("https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=1134371499")]
    public class CreatingRestaurantTest : BaseTest
    {
        public string GetRandomString() //DateForCreateRestaurant
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
        }
        public string GetRandomNumberString() //DateForPositiveCreateRestaurant
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
        }
        public string GetNegativeRandomNumberString() //DateForNegativeCreateRestaurant
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
        }

        [Test, Order(1)]
        [AllureDescription("Test for client role, create new restaurant")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Client", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Client")]
        [AllureFeature("My restaurant")]
        [AllureStory("Create")]
        public void ClientMyRestaurant_WhenLoggedIn_ShouldCreateNewRestaurant()
        {
            //DateForCreatingRestaurant
            string name = GetRandomString();
            string address = GetRandomString();
            //Arrange
            SignInPage signInPageObject
                = new SignInPage(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
               = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ClientProfileMyRestaurantTab clientProfileMyRestaurantPageObject
                = new ClientProfileMyRestaurantTab(driver);
            //Act
            signInPageObject.SignInAsClient(); //PositiveClientSignIn
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            clientProfileMyRestaurantPageObject.ClickAddRestaurantButton();
            clientProfileMyRestaurantPageObject.SendTextToNameTextField(name);
            clientProfileMyRestaurantPageObject.SendTextToAddressTextField(address);
            clientProfileMyRestaurantPageObject.ClickSubmitButton(); //PositiveCreatingRestaurant
            int actualResult = clientProfileMyRestaurantPageObject.GetMyRestaurantInfo();
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.That(actualResult > 0, $"There are {actualResult} My restaurants"); },
                "Check new restaurant");
        }
        [Test, Order(2)]
        [AllureDescription("Test for client role, create new restaurant menu")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Client", "TestCase ID#00002")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Client")]
        [AllureFeature("Menu of restaurant")]
        [AllureStory("Create")]
        public void ClientManageRestaurant_MenueTab_WhenLoggedIn_ShouldCreateNewMenu()
        {
            //DateForCreatingRestaurantMenu
            string menuname = GetRandomString();
            string groupProductName = GetRandomString();
            string groupProductDescription = GetRandomString();
            string groupProductIngredients = GetRandomString();
            string groupProductPrice = GetRandomNumberString();
            // Arrange 
            SignInPage signInPageObject
                = new SignInPage(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ClientProfileMyRestaurantTab clientProfileMyRestaurantPageObject
                = new ClientProfileMyRestaurantTab(driver);
            ManageRestaurant manageRestaurant
                = new ManageRestaurant(driver);
            ManageRestaurantMenuTab manageRestaurantMenu
                = new ManageRestaurantMenuTab(driver);
            //Act
            signInPageObject.SignInAsClient(); //PositiveClientSignIn
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickManageButton(); //PositiveManageRestaurantPage;
            manageRestaurant.ClickMenuesTab();
            manageRestaurant.ClickCreateMenuTab();
            manageRestaurantMenu.SendMenuNameTextField(menuname);
            manageRestaurantMenu.ClickNextCreateMenuNameButton();
            manageRestaurantMenu.SendGroupProductNameTextfield(groupProductName);
            manageRestaurantMenu.SendGroupProductDescriptionTextfield(groupProductDescription);
            manageRestaurantMenu.SendGroupProductIngredientsTextfield(groupProductIngredients);
            manageRestaurantMenu.SendGroupProductPriceTextfield(groupProductPrice);
            manageRestaurantMenu.ClickGroupProductCategoryButton();
            manageRestaurantMenu.ClickSelectMeatProductCategory();
            manageRestaurantMenu.ClickNextCreateMuneButtonStepTwo();
            Thread.Sleep(2000);
            manageRestaurantMenu.ClickFinishCreateMenuButton(); //PositiveCreateMenu
            //Assert 
            int actualResult = manageRestaurant.GetMenuRestaurantInfo();
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.That(actualResult > 0, $"There are {actualResult} Restaurant menu"); },
                "Check new restaurant menu");
        }
        [Test, Order(3)]
        [AllureDescription("Test for client role, create new waiter for restaurant")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Client", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Client")]
        [AllureFeature("Waiter of restaurant")]
        [AllureStory("Create")]
        public void ClientManageRestaurant_WaiterTab_WhenLoggedIn_ShouldCreateNewWaiter()
        {
            //OurDateForCreatingNewWaiter
            string name = GetRandomString();
            string waiterEmail = GetRandomString() + "@test.com";
            string phoneNumber = GetRandomNumberString();
            string password = GetRandomNumberString();
            //Arrange
            SignInPage signInPageObject
                = new SignInPage(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ClientProfileMyRestaurantTab clientProfileMyRestaurantPageObject
                = new ClientProfileMyRestaurantTab(driver);
            ManageRestaurant manageRestaurant
                = new ManageRestaurant(driver);
            ManageRestaurantWaitersTab manageRestaurantWaiters
                = new ManageRestaurantWaitersTab(driver);
            //Act
            signInPageObject.SignInAsClient(); //PositiveClientSignIn
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickManageButton(); //PositiveManageRestaurantPage
            manageRestaurant.ClickWaitersTab();
            manageRestaurantWaiters.ClickAddWaiterButton();
            manageRestaurantWaiters.SendWaiterNameTextField(name);
            manageRestaurantWaiters.SendWaiterEmailTextField(waiterEmail);
            manageRestaurantWaiters.SendWaiterPasswordTextField(password);
            manageRestaurantWaiters.SendWaiterPhoneNumberTextField(phoneNumber);
            manageRestaurantWaiters.ClickSubmitCreateNewWaiterButton(); //PositiveCreateNewWaiter 
            Thread.Sleep(2000);
            //Assert 
            int actualResult = manageRestaurantWaiters.GetRestaurantWaiterInfo();
            AllureLifecycle.Instance.WrapInStep(
                () => { Assert.That(actualResult > 0, $"There are {actualResult} Restaurant Waiter"); },
                "Check new restaurant waiter");
        }
        [Test, Order(4)]
        [AllureDescription("Test for client role, create new Administrator for restaurant")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Client", "TestCase ID#00004")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Client")]
        [AllureFeature("Administrator of restaurant")]
        [AllureStory("Create")]
        public void ClientManageRestaurant_AdministratorTab_WhenLoggedIn_ShouldCreateNewAdministrator()
        {
            //OurDateForCreatingNewAdministrator
            string name = GetRandomString();
            string waiterEmail = GetRandomString() + "@test.com";
            string phoneNumber = GetRandomNumberString();
            string password = GetRandomNumberString();
            //Arrange
            SignInPage signInPageObject
                = new SignInPage(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ClientProfileMyRestaurantTab clientProfileMyRestaurantPageObject
                = new ClientProfileMyRestaurantTab(driver);
            ManageRestaurant manageRestaurant
                = new ManageRestaurant(driver);
            ManageRestaurantAdministratorsTab manageRestaurantAdministrators
                = new ManageRestaurantAdministratorsTab(driver);
            //Act
            signInPageObject.SignInAsClient(); //PositiveClientSignIn
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickManageButton(); //PositiveManageRestaurantPage
            manageRestaurant.ClickAdministratorTab();
            manageRestaurantAdministrators.ClickAddAdministratorButton();
            manageRestaurantAdministrators.SendAdministratorNameTextField(name);
            manageRestaurantAdministrators.SendAdministratorEmailTextField(waiterEmail);
            manageRestaurantAdministrators.SendAdministratorPasswordTextField(password);
            manageRestaurantAdministrators.SendAdministratorPhoneNumberTextField(phoneNumber);
            manageRestaurantAdministrators.ClickSubmitCreateNewAdministratorButton(); //PositiveCreateNewAdministrator 
            Thread.Sleep(2000); //GetRestaurantAdministratorInfo
            //Assert 
            int actualResult = manageRestaurantAdministrators.GetRestaurantAdministratorInfo();
            AllureLifecycle.Instance.WrapInStep(
               () => { Assert.That(actualResult > 0, $"There are {actualResult} Restaurant Administrator"); },
               "Check new restaurant administrator");
        }
        [Test, Order(5)]
        [AllureDescription("Test for client role, archive restaurant")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Client", "TestCase ID#00005")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Client")]
        [AllureFeature("My restaurant")]
        [AllureStory("Archive")]
        public void ClientMyRestaurant_WhenLoggedIn_ShouldArchiveOurRestaurant()
        {
            //Arrange
            SignInPage signInPageObject
                = new SignInPage(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ClientProfileMyRestaurantTab clientProfileMyRestaurantPageObject
                = new ClientProfileMyRestaurantTab(driver);
            //Act
            signInPageObject.SignInAsClient(); //PositiveClientSignIn
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickArchiveButton(); //PositiveArchiveRestaurant
            Thread.Sleep(2000);
        }
        [Test, Order(6)]
        [AllureDescription("Test for client role, create new restaurant with errors in proccess")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Client", "TestCase ID#00006")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Client")]
        [AllureFeature("My restaurant")]
        [AllureStory("Create")]
        public void ClientMyRestaurant_WhenLoggedIn_ShouldNotCreateNewRestaurant()
        {
            //OurDateForCreatingRestautant
            string name = GetRandomString();
            string address = GetRandomString();
            //Arrange
            SignInPage signInPageObject
                = new SignInPage(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ClientProfileMyRestaurantTab clientProfileMyRestaurantPageObject
                = new ClientProfileMyRestaurantTab(driver);
            //Act
            signInPageObject.SignInAsClient();  //PositiveClientSignIn
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            clientProfileMyRestaurantPageObject.ClickAddRestaurantButton();
            Thread.Sleep(2000);
            clientProfileMyRestaurantPageObject.ClickSubmitButton(); //WeCanSeeTwoErrorMessagesToInputDate
            //AssertForName
            string actualRestaurantNameErrorMessageText = clientProfileMyRestaurantPageObject.GetCreateRestaurantNameIsRequiredErrorMessage();
            string expectedRestaurantNameErrorMessageText = "Name is required";
            Assert.AreEqual(expectedRestaurantNameErrorMessageText, actualRestaurantNameErrorMessageText, $"{expectedRestaurantNameErrorMessageText} is not equal for {actualRestaurantNameErrorMessageText}");
            //AssertForAddress
            string actualRestaurantAddressErrorMessageText = clientProfileMyRestaurantPageObject.GetCreateRestaurantAddressIsRequiredErrorMessage();
            string expectedRestaurantAddressErrorMessageText = "Address is required";
            Assert.AreEqual(expectedRestaurantAddressErrorMessageText, actualRestaurantAddressErrorMessageText, $"{expectedRestaurantAddressErrorMessageText} is not equal for {actualRestaurantAddressErrorMessageText}");
            clientProfileMyRestaurantPageObject.SendTextToNameTextField(name);
            clientProfileMyRestaurantPageObject.SendTextToAddressTextField(address);
            clientProfileMyRestaurantPageObject.ClickSubmitButton();
            Thread.Sleep(2000);
            int actualResult = clientProfileMyRestaurantPageObject.GetMyRestaurantInfo();
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.That(actualResult > 1, $"There are {actualResult} My restaurants"); },
              "Check new restaurant");
        }
        [Test, Order(7)]
        [AllureDescription("Test for client role, create new restaurant menu with empty date")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Client", "TestCase ID#00007")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Client")]
        [AllureFeature("Menu of restaurant")]
        [AllureStory("Create")]
        public void ClientManageRestaurant_MenueTab_WhenLoggedIn_ShouldNotCreateNewMenu()
        {
            //OurInformationForCreatingRestautantMenu
            string menuname = GetRandomString();
            //Arrange
            SignInPage signInPageObject
                 = new SignInPage(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ClientProfileMyRestaurantTab clientProfileMyRestaurantPageObject
                = new ClientProfileMyRestaurantTab(driver);
            ManageRestaurant manageRestaurant
                = new ManageRestaurant(driver);
            ManageRestaurantMenuTab manageRestaurantMenu
                = new ManageRestaurantMenuTab(driver);
            //Act
            signInPageObject.SignInAsClient();  //PositiveClientSignIn
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            driver.Navigate().Refresh();
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutNegativeRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickManageNegativeRestaurantButton(); //PositiveManageRestaurantPage
            manageRestaurant.ClickMenuNeagtiveRestaurantTab();
            manageRestaurant.ClickCreateMenuNeagtiveRestaurantTab();
            manageRestaurantMenu.SendMenuNameTextField(menuname);
            manageRestaurantMenu.ClickNextCreateMenuNameButton();
            manageRestaurantMenu.ClickNextCreateMuneButtonStepTwo();
            Thread.Sleep(2000);
            manageRestaurantMenu.ClickFinishCreateMenuButton(); //PositiveCreateMenu
            int actualResult = manageRestaurant.GetMenuRestaurantInfo();
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.That(actualResult > 0, $"There are {actualResult} Restaurant menu"); },
              "Check new restaurant menu");
        }
        [Test, Order(8)]
        [AllureDescription("Test for client role, create new waiter for restaurant with errors in process")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Client", "TestCase ID#00008")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Client")]
        [AllureFeature("Waiter of restaurant")]
        [AllureStory("Create")]
        public void ClientManageRestaurant_WaiterTab_WhenLoggedIn_ShouldNotCreateNewWaiter()
        {
            //OurDateForCreatingNewWaiter
            string name = GetRandomString();
            string negativeWaiterEmail = GetRandomString() + "@testcom";
            string phoneNumber = GetNegativeRandomNumberString();
            string password = GetNegativeRandomNumberString();
            //Arrange);
            SignInPage signInPageObject
                = new SignInPage(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ClientProfileMyRestaurantTab clientProfileMyRestaurantPageObject
                = new ClientProfileMyRestaurantTab(driver);
            ManageRestaurant manageRestaurant
                = new ManageRestaurant(driver);
            ManageRestaurantWaitersTab manageRestaurantWaiters
               = new ManageRestaurantWaitersTab(driver);

            //Act;
            signInPageObject.SignInAsClient();//PositiveClientSignIn
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            driver.Navigate().Refresh();
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutNegativeRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickManageNegativeRestaurantButton(); //PositiveManageRestaurantPage
            manageRestaurant.ClickWaitersNegativeTab();
            manageRestaurantWaiters.ClickAddWaiterButton();
            Thread.Sleep(2000);
            manageRestaurantWaiters.ClickSubmitCreateNewWaiterButton(); //WeCanSeeErrorMessageToInputDate
            //AssertForNewWaiter
            string actualNewWaiterNameIsRequiredErrorMessageText = manageRestaurantWaiters.GetCreateNewWaiterNameIsRequiredErrorMessage();
            string expectedNewWaiterNameIsRequiredErrorMessageText = "Name is required";
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.AreEqual(expectedNewWaiterNameIsRequiredErrorMessageText, actualNewWaiterNameIsRequiredErrorMessageText, $"{expectedNewWaiterNameIsRequiredErrorMessageText} is not equal for {actualNewWaiterNameIsRequiredErrorMessageText}"); },
              "Check error message about name of waiter");
            string actualNewWaiterMailIsRequiredErrorMessageText = manageRestaurantWaiters.GetCreateNewWaiterMailIsRequiredErrorMessage();
            string expectedNewWaiterMailIsRequiredErrorMessageText = "Mail is required";
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.AreEqual(expectedNewWaiterMailIsRequiredErrorMessageText, actualNewWaiterMailIsRequiredErrorMessageText, $"{expectedNewWaiterMailIsRequiredErrorMessageText} is not equal for {actualNewWaiterMailIsRequiredErrorMessageText}"); },
              "Check error message about mail of  waiter");
            string actualNewWaiterPasswordIsRequiredErrorMessageText = manageRestaurantWaiters.GetCreateNewWaiterPasswordIsRequiredErrorMessage();
            string expectedNewWaiterPasswordIsRequiredErrorMessageText = "Password is required";
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.AreEqual(expectedNewWaiterPasswordIsRequiredErrorMessageText, actualNewWaiterPasswordIsRequiredErrorMessageText, $"{expectedNewWaiterPasswordIsRequiredErrorMessageText} is not equal for {actualNewWaiterPasswordIsRequiredErrorMessageText}"); },
              "Check error message about password of  waiter");
            string actualNewWaiterPhoneNumberIsRequiredErrorMessageText = manageRestaurantWaiters.GetCreateNewWaiterPhoneNumberIsRequiredErrorMessage();
            string expectedNewWaiterPhoneNumberIsRequiredErrorMessageText = "Phone number is required";
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.AreEqual(expectedNewWaiterPhoneNumberIsRequiredErrorMessageText, actualNewWaiterPhoneNumberIsRequiredErrorMessageText, $"{expectedNewWaiterPhoneNumberIsRequiredErrorMessageText} is not equal for {actualNewWaiterPhoneNumberIsRequiredErrorMessageText}"); },
              "Check error message about phone number of  waiter");
            Thread.Sleep(2000);
            manageRestaurantWaiters.SendWaiterNameTextField(name);
            manageRestaurantWaiters.SendWaiterEmailTextField(negativeWaiterEmail);
            manageRestaurantWaiters.SendWaiterPasswordTextField(password);
            manageRestaurantWaiters.SendWaiterPhoneNumberTextField(phoneNumber);
            Thread.Sleep(3000);
            manageRestaurantWaiters.ClickSubmitCreateNewWaiterButton(); //NegativeCreateNewWaiter
            //AssertForSubmitCreateNewWaiterButton
            string actualNewWaiterSomethingWentWrongErrorMessageText = manageRestaurantWaiters.GetCreateNewWaiterSomethingWentWrongErrorMessage();
            string expectedNewWaiterSomethingWentWrongErrorMessageText = "Something went wrong";
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.AreEqual(expectedNewWaiterSomethingWentWrongErrorMessageText, actualNewWaiterSomethingWentWrongErrorMessageText, $"{expectedNewWaiterSomethingWentWrongErrorMessageText} is not equal for {actualNewWaiterSomethingWentWrongErrorMessageText}"); },
              "Check error message thay something went wrong in create process");
            Thread.Sleep(2000);
        }
        [Test, Order(9)]
        [AllureDescription("Test for client role, create new waiter for restaurant with errors in process and archive")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Client", "TestCase ID#00009")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Client")]
        [AllureFeature("administrator of restaurant, my restaurant")]
        [AllureStory("Create administrator, archive restaurant")]
        public void ClientManageRestaurant_AdministratorTab_WhenLoggedIn_ShouldNotCreateNewAdministrator()
        {
            //OurDateForCreatingNewAdministrator
            string name = GetRandomString();
            string negativeAdministratorEmail = GetRandomString() + "@testcom";
            string phoneNumber = GetNegativeRandomNumberString();
            string password = GetNegativeRandomNumberString();
            //Arrange
            SignInPage signInPageObject
                = new SignInPage(driver);
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            ClientProfileMyRestaurantTab clientProfileMyRestaurantPageObject
                = new ClientProfileMyRestaurantTab(driver);
            ManageRestaurant manageRestaurant
                 = new ManageRestaurant(driver);
            ManageRestaurantAdministratorsTab manageRestaurantAdministrators
                = new ManageRestaurantAdministratorsTab(driver);
            //Act
            signInPageObject.SignInAsClient(); //PositiveClientSignIn
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            clientProfileMyRestaurantPageObject.ClickMyRestaurantTab();
            driver.Navigate().Refresh();
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutNegativeRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickManageNegativeRestaurantButton(); //PositiveManageRestaurantPage
            manageRestaurant.ClickAdministratorNegativeTab();
            manageRestaurantAdministrators.ClickAddAdministratorButton();
            Thread.Sleep(2000);
            manageRestaurantAdministrators.ClickSubmitCreateNewAdministratorButton();
            //AssertForNewAdministrator
            string actualNewAdministratorNameIsRequiredErrorMessageText = manageRestaurantAdministrators.GetCreateNewAdministratorNameIsRequiredErrorMessage();
            string expectedNewAdministratorNameIsRequiredErrorMessageText = "Name is required";
            AllureLifecycle.Instance.WrapInStep(
             () => { Assert.AreEqual(expectedNewAdministratorNameIsRequiredErrorMessageText, actualNewAdministratorNameIsRequiredErrorMessageText, $"{expectedNewAdministratorNameIsRequiredErrorMessageText} is not equal for {actualNewAdministratorNameIsRequiredErrorMessageText}"); },
             "Check error message about name of administrator");
            string actualNewAdministratorMailIsRequiredErrorMessageText = manageRestaurantAdministrators.GetCreateNewAdministratorMailIsRequiredErrorMessage();
            string expectedNewAdministratorMailIsRequiredErrorMessageText = "Mail is required";
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.AreEqual(expectedNewAdministratorMailIsRequiredErrorMessageText, actualNewAdministratorMailIsRequiredErrorMessageText, $"{expectedNewAdministratorMailIsRequiredErrorMessageText} is not equal for {actualNewAdministratorMailIsRequiredErrorMessageText}"); },
              "Check error message about mail of administrator");
            string actualNewAdministratorPasswordIsRequiredErrorMessageText = manageRestaurantAdministrators.GetCreateNewAdministratorPasswordIsRequiredErrorMessage();
            string expectedNewAdministratorPasswordIsRequiredErrorMessageText = "Password is required";
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.AreEqual(expectedNewAdministratorPasswordIsRequiredErrorMessageText, actualNewAdministratorPasswordIsRequiredErrorMessageText, $"{expectedNewAdministratorPasswordIsRequiredErrorMessageText} is not equal for {actualNewAdministratorPasswordIsRequiredErrorMessageText}"); },
              "Check error message about password of  administrator");
            string actualNewAdministratorPhoneNumberIsRequiredErrorMessageText = manageRestaurantAdministrators.GetCreateNewAdministratorPhoneNumberIsRequiredErrorMessage();
            string expectedNewAdministratorPhoneNumberIsRequiredErrorMessageText = "Phone number is required";
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.AreEqual(expectedNewAdministratorPhoneNumberIsRequiredErrorMessageText, actualNewAdministratorPhoneNumberIsRequiredErrorMessageText, $"{expectedNewAdministratorPhoneNumberIsRequiredErrorMessageText} is not equal for {actualNewAdministratorPhoneNumberIsRequiredErrorMessageText}"); },
              "Check error message about phone number of  administrator");
            Thread.Sleep(2000);
            manageRestaurantAdministrators.SendAdministratorNameTextField(name);
            manageRestaurantAdministrators.SendAdministratorEmailTextField(negativeAdministratorEmail);
            manageRestaurantAdministrators.SendAdministratorPasswordTextField(password);
            manageRestaurantAdministrators.SendAdministratorPhoneNumberTextField(phoneNumber);
            Thread.Sleep(3000);
            manageRestaurantAdministrators.ClickSubmitCreateNewAdministratorButton();  //NegativeCreateNewAdministrator
            //AssertForSubmitCreateNewAdministratorButton
            string actualNewAdministratorSomethingWentWrongErrorMessageText = manageRestaurantAdministrators.GetCreateNewAdministratorSomethingWentWrongErrorMessage();
            string expectedNewAdministratorSomethingWentWrongErrorMessageText = "Something went wrong";
            AllureLifecycle.Instance.WrapInStep(
              () => { Assert.AreEqual(expectedNewAdministratorSomethingWentWrongErrorMessageText, actualNewAdministratorSomethingWentWrongErrorMessageText, $"{expectedNewAdministratorSomethingWentWrongErrorMessageText} is not equal for {actualNewAdministratorSomethingWentWrongErrorMessageText}"); },
              "Check error message that something went wrong in create process");
            Thread.Sleep(2000);
            manageRestaurant.ClickProfileLogoButton();
            manageRestaurant.ClickMyRestaurantsButton(); //MyProfileMyRestaurantPage
            Thread.Sleep(3000);
            clientProfileMyRestaurantPageObject.ClickMoreInfoAboutNegativeRestaurantButton();
            clientProfileMyRestaurantPageObject.ClickArchiveButton(); //PositiveArchiveRestaurant
        }
    }
}