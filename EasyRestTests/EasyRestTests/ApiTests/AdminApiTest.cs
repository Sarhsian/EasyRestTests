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
    class AdminApiTest : BaseApiTest
    {
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
        [AllureDescription("Test for admin role, to check posibility to ban user in tab 'Users'=>'All'")]
        [AllureOwner("Vitalii")]
        [AllureTag("Admin", "API", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Users")]
        [AllureStory("Ban")]
        public void BanUser_WhenLoggedInAsAdmin_ShouldBanUser()
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
    }
}
