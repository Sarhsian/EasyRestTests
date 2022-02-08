using NUnit.Framework;
using Leaf.xNet;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Tests.ApiTests
{
    [AllureNUnit]
    [AllureEpic("Admin_API")]
    [AllureSuite("API")]
    [AllureLink("https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=298696230")]
    class AdminApiTest : BaseApiTest
    {        
        [Test]
        [AllureDescription("Test for admin role, to check posibility to ban user")]
        [AllureOwner("Vitalii")]
        [AllureTag("Admin", "API", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Users")]
        [AllureStory("Ban")]
        public void BanUser_WhenLoggedInAsAdmin_ShouldBanUserFromActiveTab()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/user/toggle_activity/18";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsAdmin(request));            
            request.Get(url);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test]
        [AllureDescription("Test for admin role, to check posibility to ban owner")]
        [AllureOwner("Vitalii")]
        [AllureTag("Admin", "API", "TestCase ID#00004")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Owners")]
        [AllureStory("Ban")]
        public void BanOwner_WhenLoggedInAsAdmin_ShouldBanOwnerFromActiveTab()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/user/toggle_activity/5";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsAdmin(request));
            request.Get(url);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test]
        [AllureDescription("Test for admin role, to check posibility to check info about all moderators")]
        [AllureOwner("Vitalii")]
        [AllureTag("Admin", "API")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Moderators")]
        [AllureStory("CheckInfo")]
        public void CheckInfoAboutModerators_WhenLoggedInAsAdmin_ShouldShowInfoAboutModerators()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/users/3";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsAdmin(request));
            request.Get(url);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test]
        [AllureDescription("Test for admin role, to check posibility to create new moderator")]
        [AllureOwner("Vitalii")]
        [AllureTag("Admin", "API", "TestCase ID#00008")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Moderators")]
        [AllureStory("Create")]
        public void CreatingModerator_WhenLoggedInAsAdmin_ShouldCreateNewModerator()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/user/3";
            string json = "{\"name\":\"NewModerator\",\"email\":\"newmoderator@test.com\",\"password\":\"12345678\",\"phone_number\":null,\"birth_date\":null}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsAdmin(request));
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test]
        [AllureDescription("Test for admin role, to check posibility to check info about all restautants")]
        [AllureOwner("Vitalii")]
        [AllureTag("Admin", "API", "TestCase ID#00009")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Restaurants")]
        [AllureStory("CheckInfo")]
        public void CheckInfoAboutRestaurants_WhenLoggedInAsAdmin_ShouldShowInfoAboutRestaurants()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/moderator/restaurants";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsAdmin(request));
            request.Get(url);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
    }
}
