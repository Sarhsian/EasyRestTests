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
    public class ModeratorTest : BaseTest
    {
        /*[Test]
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

        }*/
        /*[Test]
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
        }*/
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
            moderatorRestaurantsManagmentPageObject.ClickAllRestaurantsListButton();
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

            //PositiveModeratorRestaurantsManagmentAllRestaurantsListTest

        }
        [Test]
        public void PositiveModeratorRestaurantsManagmentUnapprovedRestaurantsListTest()
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
            moderatorRestaurantsManagmentPageObject.ClickUnapprovedRestaurantsListButton();
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

            //PositiveModeratorRestaurantsManagmentUnapprovedRestaurantsListTest

        }
        [Test]
        public void PositiveModeratorRestaurantsManagmentApprovedRestaurantsListTest()
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
            moderatorRestaurantsManagmentPageObject.ClickApprovedRestaurantsListButton();
            ModeratorRestaurantsManagmentAllRestaurantsListPageObject moderatorRestaurantsManagmentAllRestaurantsListPageObject
                = new ModeratorRestaurantsManagmentAllRestaurantsListPageObject(driver);
            string expectedDisapprovedMessageText = "Disapproved";  
   
            moderatorRestaurantsManagmentAllRestaurantsListPageObject.ClickRandomRestaurantsButtonDelete();
            string actualDisapprovedMessageText = moderatorRestaurantsManagmentAllRestaurantsListPageObject.GetDisapprovedMessageText();
            Assert.AreEqual(expectedDisapprovedMessageText, actualDisapprovedMessageText, $"{expectedDisapprovedMessageText} is not equal for {actualDisapprovedMessageText}");

            //PositiveModeratorRestaurantsManagmentApprovedRestaurantsListTest

        }

        [Test]
        public void PositiveModeratorRestaurantsManagmentArchivedRestaurantsListTest()
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
            moderatorRestaurantsManagmentPageObject.ClickArchivedRestaurantsListButton();
            ModeratorRestaurantsManagmentAllRestaurantsListPageObject moderatorRestaurantsManagmentAllRestaurantsListPageObject
                = new ModeratorRestaurantsManagmentAllRestaurantsListPageObject(driver);
            
            string expectedApprovedMessageText = "Approved";
               
            moderatorRestaurantsManagmentAllRestaurantsListPageObject.ClickRandomRestaurantsButtonRestore();
            string actualApprovedMessageText = moderatorRestaurantsManagmentAllRestaurantsListPageObject.GetApprovedMessageText();
            Assert.AreEqual(expectedApprovedMessageText, actualApprovedMessageText, $"{expectedApprovedMessageText} is not equal for {actualApprovedMessageText}");

            //PositiveModeratorRestaurantsManagmentArchivedRestaurantsListTest

        }

        [Test]
        public void PositiveModeratorUsersManagmentAllUsersListTest()
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
            ModeratorPanelPageObject moderatorPanelPageObject
                = new ModeratorPanelPageObject(driver);
            moderatorPanelPageObject.ClickUsersManagmentPageButton();
            //PositiveModeratorPanelTest
            ModeratorUsersManagmentPageObject moderatorUsersManagmentPageObject
                = new ModeratorUsersManagmentPageObject(driver);
            moderatorUsersManagmentPageObject.ClickAllUsersListButton();
            ModeratorUsersManagmentAllUsersListPageObject moderatorUsersManagmentAllUsersListPageObject
                = new ModeratorUsersManagmentAllUsersListPageObject(driver);
            string expectedSuccessMessageText = "success";
            /* List<IWebElement> allUsersButtonsBan = driver.FindElements
                 (By.XPath("//button[contains(@class,'MuiIconButton-colorSecondary')]")).ToList();
             Assert.IsTrue(false, $"{allUsersButtonsBan.Count}");
            */
            moderatorUsersManagmentAllUsersListPageObject.ClickRandomUsersButtonBan();
            string actualSuccesMessageText = moderatorUsersManagmentAllUsersListPageObject.GetSuccessMessageText();
            Assert.AreEqual(expectedSuccessMessageText, actualSuccesMessageText,
                $"{expectedSuccessMessageText} is not equal for {actualSuccesMessageText}");

            moderatorUsersManagmentAllUsersListPageObject.ClickRandomUsersButtonUnban();
            actualSuccesMessageText = moderatorUsersManagmentAllUsersListPageObject.GetSuccessMessageText();
            Assert.AreEqual(expectedSuccessMessageText, actualSuccesMessageText,
                $"{expectedSuccessMessageText} is not equal for {actualSuccesMessageText}");


            //PositiveModeratorRestaurantsManagmentAllRestaurantsListTest

        }
        [Test]
        public void PositiveModeratorUsersManagmentActiveUsersListTest()
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
            ModeratorPanelPageObject moderatorPanelPageObject
                = new ModeratorPanelPageObject(driver);
            moderatorPanelPageObject.ClickUsersManagmentPageButton();
            //PositiveModeratorPanelTest
            ModeratorUsersManagmentPageObject moderatorUsersManagmentPageObject
                = new ModeratorUsersManagmentPageObject(driver);
            moderatorUsersManagmentPageObject.ClickActiveRestaurantsListButton();
            ModeratorUsersManagmentActiveUsersListPageObject moderatorUsersManagmentActiveUsersListPageObject
                = new ModeratorUsersManagmentActiveUsersListPageObject(driver);
            string expectedSuccessMessageText = "success";

            moderatorUsersManagmentActiveUsersListPageObject.ClickRandomUsersButtonBan();
            string actualSuccesMessageText = moderatorUsersManagmentActiveUsersListPageObject.GetSuccessMessageText();
            Assert.AreEqual(expectedSuccessMessageText, actualSuccesMessageText,
                $"{expectedSuccessMessageText} is not equal for {actualSuccesMessageText}");
            //PositiveModeratorRestaurantsManagmentActiveRestaurantsListTest

        }
        [Test]
        public void PositiveModeratorUsersManagmentBannedsUsersListTest()
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
            ModeratorPanelPageObject moderatorPanelPageObject
                = new ModeratorPanelPageObject(driver);
            moderatorPanelPageObject.ClickUsersManagmentPageButton();
            //PositiveModeratorPanelTest
            ModeratorUsersManagmentPageObject moderatorUsersManagmentPageObject
                = new ModeratorUsersManagmentPageObject(driver);
            moderatorUsersManagmentPageObject.ClickBanndeRestaurantsListButton();
            ModeratorUsersManagmentBannedUsersListPageObject moderatorUsersManagmentBannedUsersListPageObject
                = new ModeratorUsersManagmentBannedUsersListPageObject(driver);
            string expectedSuccessMessageText = "success";

            moderatorUsersManagmentBannedUsersListPageObject.ClickRandomUsersButtonUnban();
            string actualSuccesMessageText = moderatorUsersManagmentBannedUsersListPageObject.GetSuccessMessageText();
            Assert.AreEqual(expectedSuccessMessageText, actualSuccesMessageText,
                $"{expectedSuccessMessageText} is not equal for {actualSuccesMessageText}");
            //PositiveModeratorRestaurantsManagmentBannedRestaurantsListTest

        }



    }
}
