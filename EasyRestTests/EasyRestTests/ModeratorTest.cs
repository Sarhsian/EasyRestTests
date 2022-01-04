﻿using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tests
{
    public class ModeratorTest : BaseTest
    {
        [Test]
        public void PositiveModeratorTest()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("petermoderator@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            Assert.IsTrue(loginedUserPartOfBaseHeaderPageObject.UserMenuDisplayed());
            //PositiveSignInTest
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            string actualRolePanelText = loginedUserPartOfBaseHeaderPageObject.GetRolePanelText();
            string expectedRolePanelText = "Moderator panel";
            Assert.AreEqual(expectedRolePanelText, actualRolePanelText, $"{expectedRolePanelText} is not equal for {actualRolePanelText}");
            //PositiveModeratorSignInTest

        }
        [Test]
        public void PositiveModeratorRestaurantsManagmentTest()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("petermoderator@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            Assert.IsTrue(loginedUserPartOfBaseHeaderPageObject.UserMenuDisplayed());
            //PositiveSignInTest
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            string actualRolePanelText = loginedUserPartOfBaseHeaderPageObject.GetRolePanelText();
            string expectedRolePanelText = "Moderator panel";
            Assert.AreEqual(expectedRolePanelText, actualRolePanelText, $"{expectedRolePanelText} is not equal for {actualRolePanelText}");
            //PositiveModeratorSignInTest
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            ModeratorRestaurantsManagmentPageObject moderatorRestaurantsManagmentPageObject = new ModeratorRestaurantsManagmentPageObject(driver);
            moderatorRestaurantsManagmentPageObject.ClickRestaurantsManagmentPageButton();
            //PositiveModeratorRestaurantsManagmentTest
        }
        [Test]
        public void PositiveModeratorRestaurantsManagmentAllRestaurantsListTest()
        {
            UnloginedUserPartOfBaseHeaderPageObject unloginedUserPartOfBaseHeader = new UnloginedUserPartOfBaseHeaderPageObject(driver);
            unloginedUserPartOfBaseHeader.ClickSignInButton();
            SignInPageObject signInPageObject = new SignInPageObject(driver);
            signInPageObject.SendTextToEmailTextField("petermoderator@test.com");
            signInPageObject.SendTextToPasswordTextField("1");
            signInPageObject.ClickSubmitButton();
            LoginedUserPartOfBaseHeaderPageObject loginedUserPartOfBaseHeaderPageObject = new LoginedUserPartOfBaseHeaderPageObject(driver);
            Assert.IsTrue(loginedUserPartOfBaseHeaderPageObject.UserMenuDisplayed());
            //PositiveSignInTest
            loginedUserPartOfBaseHeaderPageObject.ClickUserMenuButton();
            string actualRolePanelText = loginedUserPartOfBaseHeaderPageObject.GetRolePanelText();
            string expectedRolePanelText = "Moderator panel";
            Assert.AreEqual(expectedRolePanelText, actualRolePanelText, $"{expectedRolePanelText} is not equal for {actualRolePanelText}");
            //PositiveModeratorSignInTest
            loginedUserPartOfBaseHeaderPageObject.ClickRolePanelButton();
            ModeratorRestaurantsManagmentPageObject moderatorRestaurantsManagmentPageObject 
                = new ModeratorRestaurantsManagmentPageObject(driver);
            moderatorRestaurantsManagmentPageObject.ClickRestaurantsManagmentPageButton();
            //PositiveModeratorRestaurantsManagmentTest           
            ModeratorRestaurantsManagmentAllRestaurantsListPageObject moderatorRestaurantsManagmentAllRestaurantsListPageObject
                = new ModeratorRestaurantsManagmentAllRestaurantsListPageObject(driver);
            string expectedDisapprovedMessageText = "Disapproved";
            string expectedApprovedMessageText = "Approved";
            moderatorRestaurantsManagmentAllRestaurantsListPageObject.ClickRandomRestaurantsButtonDisapprove();
            string actualDisapprovedMessageText = moderatorRestaurantsManagmentAllRestaurantsListPageObject.GetDisapprovedMessageText();
            Assert.AreEqual(expectedDisapprovedMessageText, actualDisapprovedMessageText, $"{expectedDisapprovedMessageText} is not equal for {actualDisapprovedMessageText}");
            
            moderatorRestaurantsManagmentAllRestaurantsListPageObject.ClickRandomRestaurantsButtonApprove();
            string actualApprovedMessageText = moderatorRestaurantsManagmentAllRestaurantsListPageObject.GetApprovedMessageText();
            Assert.AreEqual(expectedApprovedMessageText, actualApprovedMessageText, $"{expectedApprovedMessageText} is not equal for {actualApprovedMessageText}");
            
            moderatorRestaurantsManagmentAllRestaurantsListPageObject.ClickRandomRestaurantsButtonDelete();
            actualDisapprovedMessageText = moderatorRestaurantsManagmentAllRestaurantsListPageObject.GetDisapprovedMessageText();
            Assert.AreEqual(expectedDisapprovedMessageText, actualDisapprovedMessageText, $"{expectedDisapprovedMessageText} is not equal for {actualDisapprovedMessageText}");

            moderatorRestaurantsManagmentAllRestaurantsListPageObject.ClickRandomRestaurantsButtonRestore();
            actualApprovedMessageText = moderatorRestaurantsManagmentAllRestaurantsListPageObject.GetApprovedMessageText();
            Assert.AreEqual(expectedApprovedMessageText, actualApprovedMessageText, $"{expectedApprovedMessageText} is not equal for {actualApprovedMessageText}");





        }




    }
}
