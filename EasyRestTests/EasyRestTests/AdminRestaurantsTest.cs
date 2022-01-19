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
    public class AdminRestaurantsTest : BaseTest
    {

        [Test]
        public void PositiveAdminInfoAboutRestaurantsTest()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPage signInPageObject
                = new SignInPage(driver);
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            //PositiveAdminSignIn
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            AdminPanelPageObject adminPanelPageObject
                = new AdminPanelPageObject(driver);
            adminPanelPageObject.ClickRestaurantsManagmentPageButton();
            //PositiveRestaurantManagment
            adminPanelPageObject.ClickAllRestaurantsListButton();
            //PositiveInfoAboutAllRestaurants
        }

        [Test]
        public void PositiveAdminInfoAboutUnapprovedRestaurantsListTest()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);

            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPage signInPageObject
                = new SignInPage(driver);
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            //PositiveAdminSignIn
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            AdminPanelPageObject adminPanelPageObject
                    = new AdminPanelPageObject(driver);
            adminPanelPageObject.ClickRestaurantsManagmentPageButton();
            //PositiveRestaurantManagment
            adminPanelPageObject.ClickUnapprovedRestaurantsListButton();
            //PositiveInfoAboutUnapprovedRestaurants
        }

        [Test]
        public void PositiveAdminInfoAboutApprovedRestaurantsListTest()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPage signInPageObject
                = new SignInPage(driver);
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            //PositiveAdminSignIn
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            AdminPanelPageObject adminPanelPageObject
                    = new AdminPanelPageObject(driver);
            adminPanelPageObject.ClickRestaurantsManagmentPageButton();
            //PositiveRestaurantManagment
            adminPanelPageObject.ClickApprovedRestaurantsListButton();
            //PositiveInfoAboutApprovedRestaurants
        }

        [Test]
        public void PositiveAdminInfoAboutArchivedRestaurantsListTest()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader
                = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPage signInPageObject
                = new SignInPage(driver);
            signInPageObject.SendTextToEmailTextField("steveadmin@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            //PositiveAdminSignIn
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject
                = new LoginedUserPartOfBaseHeaderPageObject(driver);
            AdminPanelPageObject adminPanelPageObject
                    = new AdminPanelPageObject(driver);
            adminPanelPageObject.ClickRestaurantsManagmentPageButton();
            //PositiveRestaurantManagment
            adminPanelPageObject.ClickArchivedRestaurantsListButton();
            //PositiveInfoAboutArchivedRestaurants
        }

    }

}