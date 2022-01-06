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
        
        [Test,Order(1)]
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
        [Test, Order(2)]
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
        [Test, Order(3)]
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

        [Test, Order(4)]
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

        [Test, Order(5)]
        
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

            moderatorUsersManagmentAllUsersListPageObject.ClickRandomUsersButtonBan();
            string actualSuccesMessageText = moderatorUsersManagmentAllUsersListPageObject.GetSuccessMessageText();
            Assert.AreEqual(expectedSuccessMessageText, actualSuccesMessageText,
                $"{expectedSuccessMessageText} is not equal for {actualSuccesMessageText}");
            moderatorUsersManagmentAllUsersListPageObject.ClickCloseMessageButton();
            
            moderatorUsersManagmentAllUsersListPageObject.ClickRandomUsersButtonUnban();
            actualSuccesMessageText = moderatorUsersManagmentAllUsersListPageObject.GetSuccessMessageText();
            Assert.AreEqual(expectedSuccessMessageText, actualSuccesMessageText,
                $"{expectedSuccessMessageText} is not equal for {actualSuccesMessageText}");
            moderatorUsersManagmentAllUsersListPageObject.ClickCloseMessageButton();


            //PositiveModeratorUsersManagmentAllUsersListTest

        }
        [Test, Order(6)]
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
            moderatorUsersManagmentPageObject.ClickActiveUsersListButton();
            ModeratorUsersManagmentActiveUsersListPageObject moderatorUsersManagmentActiveUsersListPageObject
                = new ModeratorUsersManagmentActiveUsersListPageObject(driver);
            string expectedSuccessMessageText = "success";

            moderatorUsersManagmentActiveUsersListPageObject.ClickRandomUsersButtonBan();
            string actualSuccesMessageText = moderatorUsersManagmentActiveUsersListPageObject.GetSuccessMessageText();
            Assert.AreEqual(expectedSuccessMessageText, actualSuccesMessageText,
                $"{expectedSuccessMessageText} is not equal for {actualSuccesMessageText}");
            //PositiveModeratorUsersManagmentActiveUsersListTest

        }
        [Test, Order(7)]
        public void PositiveModeratorUsersManagmentBannedUsersListTest()
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
            moderatorUsersManagmentPageObject.ClickBanndeUsersListButton();
            ModeratorUsersManagmentBannedUsersListPageObject moderatorUsersManagmentBannedUsersListPageObject
                = new ModeratorUsersManagmentBannedUsersListPageObject(driver);
            string expectedSuccessMessageText = "success";

            moderatorUsersManagmentBannedUsersListPageObject.ClickRandomUsersButtonUnban();
            string actualSuccesMessageText = moderatorUsersManagmentBannedUsersListPageObject.GetSuccessMessageText();
            Assert.AreEqual(expectedSuccessMessageText, actualSuccesMessageText,
                $"{expectedSuccessMessageText} is not equal for {actualSuccesMessageText}");
            //PositiveModeratorUsersManagmentBannedUsersListTest

        }
        [Test, Order(8)]
        public void PositiveModeratorOwnersManagmentAllOwnersListTest()
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
            moderatorPanelPageObject.ClickOwnersManagmentPageButton();
            //PositiveModeratorPanelTest
            ModeratorOwnersManagmentPageObject moderatorOwnersManagmentPageObject
                = new ModeratorOwnersManagmentPageObject(driver);
            moderatorOwnersManagmentPageObject.ClickAllOwnersListButton();
            ModeratorOwnersManagmentAllOwnersListPageObject moderatorOwnersManagmentAllOwnersListPageObject
                = new ModeratorOwnersManagmentAllOwnersListPageObject(driver);
            string expectedSuccessMessageText = "success";

            moderatorOwnersManagmentAllOwnersListPageObject.ClickRandomOwnersButtonBan();
            string actualSuccesMessageText = moderatorOwnersManagmentAllOwnersListPageObject.GetSuccessMessageText();
            Assert.AreEqual(expectedSuccessMessageText, actualSuccesMessageText,
                $"{expectedSuccessMessageText} is not equal for {actualSuccesMessageText}");

            moderatorOwnersManagmentAllOwnersListPageObject.ClickRandomOwnersButtonUnban();
            actualSuccesMessageText = moderatorOwnersManagmentAllOwnersListPageObject.GetSuccessMessageText();
            Assert.AreEqual(expectedSuccessMessageText, actualSuccesMessageText,
                $"{expectedSuccessMessageText} is not equal for {actualSuccesMessageText}");
            //PositiveModeratorOwnersManagmentAllOwnersListTest

        }

        [Test, Order(9)]
        public void PositiveModeratorOwnersManagmentActiveOwnersListTest()
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
            moderatorPanelPageObject.ClickOwnersManagmentPageButton();
            //PositiveModeratorPanelTest
            ModeratorOwnersManagmentPageObject moderatorOwnersManagmentPageObject
                = new ModeratorOwnersManagmentPageObject(driver);
            moderatorOwnersManagmentPageObject.ClickActiveOwnersListButton();
            ModeratorOwnersManagmentActiveOwnersListPageObject moderatorOwnersManagmentActiveOwnersListPageObject
                = new ModeratorOwnersManagmentActiveOwnersListPageObject(driver);
            string expectedSuccessMessageText = "success";

            moderatorOwnersManagmentActiveOwnersListPageObject.ClickRandomOwnersButtonBan();
            string actualSuccesMessageText = moderatorOwnersManagmentActiveOwnersListPageObject.GetSuccessMessageText();
            Assert.AreEqual(expectedSuccessMessageText, actualSuccesMessageText,
                $"{expectedSuccessMessageText} is not equal for {actualSuccesMessageText}");


            //PositiveModeratorOwnersManagmentActiveOwnersListTest

        }

        [Test, Order(10)]
        public void PositiveModeratorOwnersManagmentBannedOwnersListTest()
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
            moderatorPanelPageObject.ClickOwnersManagmentPageButton();
            //PositiveModeratorPanelTest
            ModeratorOwnersManagmentPageObject moderatorOwnersManagmentPageObject
                = new ModeratorOwnersManagmentPageObject(driver);
            moderatorOwnersManagmentPageObject.ClickBannedOwnersListButton();
            ModeratorOwnersManagmentBannedOwnersListPageObject moderatorOwnersManagmentBannedOwnersListPageObject
                = new ModeratorOwnersManagmentBannedOwnersListPageObject(driver);
            string expectedSuccessMessageText = "success";

            moderatorOwnersManagmentBannedOwnersListPageObject.ClickRandomOwnersButtonUnban();
            string actualSuccesMessageText = moderatorOwnersManagmentBannedOwnersListPageObject.GetSuccessMessageText();
            Assert.AreEqual(expectedSuccessMessageText, actualSuccesMessageText,
                $"{expectedSuccessMessageText} is not equal for {actualSuccesMessageText}");
            //PositiveModeratorOwnersManagmentAllOwnersListTest
            DataBaseHelper dataBaseHelper = new DataBaseHelper();
            dataBaseHelper.ResetDB();
        }


    }
}




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
/* List<IWebElement> allUsersButtonsBan = driver.FindElements
         (By.XPath("//button[contains(@class,'MuiIconButton-colorSecondary')]")).ToList();
     Assert.IsTrue(false, $"{allUsersButtonsBan.Count}");
    */