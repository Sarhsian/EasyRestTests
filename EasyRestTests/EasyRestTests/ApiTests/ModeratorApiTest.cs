using NUnit.Framework;
using Leaf.xNet;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace Tests.ApiTests
{
    [AllureNUnit]
    [AllureSuite("API")]
    [AllureEpic("Moderator_API")]
    [AllureLink("https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=1168516342")]
    class ModeratorApiTest : BaseApiTest 
    {
        [Test, Order(1)]
        [AllureDescription("Test for moderator role, to check posibility to approve restaurant")]
        [AllureOwner("Vadym")]
        [AllureTag("Moderator", "API", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Restaurants")]
        [AllureStory("Approve")]
        public void Restaurants_WhenLoggedInAsModerator_ShouldApproveRestaurant()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/moderator/restaurants";
            string json = "{\"id\":10,\"status\":1}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsModerator(request));
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test, Order(2)]
        [AllureDescription("Test for moderator role, to check posibility to disapprove restaurant")]
        [AllureOwner("Vadym")]
        [AllureTag("Moderator", "API", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Restaurants")]
        [AllureStory("Disapprove")]
        public void Restaurants_WhenLoggedInAsModerator_ShouldDisapproveRestaurant()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/moderator/restaurants";
            string json = "{\"id\":7,\"status\":2}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsModerator(request));
            request.Delete(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test, Order(3)]
        [AllureDescription("Test for moderator role, to check posibility to restore restaurant")]
        [AllureOwner("Vadym")]
        [AllureTag("Moderator", "API", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Restaurants")]
        [AllureStory("Restore")]
        public void Restaurants_WhenLoggedInAsModerator_ShouldRestoreRestaurant()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/moderator/restaurants";
            string json = "{\"id\":9,\"status\":1}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsModerator(request));
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test, Order(4)]
        [AllureDescription("Test for moderator role, to check posibility to delete restaurant")]
        [AllureOwner("Vadym")]
        [AllureTag("Moderator", "API", "TestCase ID#00002")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Restaurants")]
        [AllureStory("Delete")]
        public void Restaurants_WhenLoggedInAsModerator_ShouldDeleteRestaurant()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/moderator/restaurants";
            string json = "{\"id\":8,\"status\":2}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsModerator(request));
            request.Delete(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test, Order(5)]
        [AllureDescription("Test for moderator role, to check posibility to ban users")]
        [AllureOwner("Vadym")]
        [AllureTag("Moderator", "API", "TestCase ID#00005")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Users")]
        [AllureStory("Ban")]
        public void Users_WhenLoggedInAsModerator_ShouldBanUser()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/moderator/users";
            string json = "{\"id\":18}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsModerator(request));
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test, Order(6)]
        [AllureDescription("Test for moderator role, to check posibility to unban users")]
        [AllureOwner("Vadym")]
        [AllureTag("Moderator", "API", "TestCase ID#00005")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Users")]
        [AllureStory("Unban")]
        public void Users_WhenLoggedInAsModerator_ShouldUnbanUser()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/moderator/users";
            string json = "{\"id\":18}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsModerator(request));
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test, Order(7)]
        [AllureDescription("Test for moderator role, to check posibility to ban owners")]
        [AllureOwner("Vadym")]
        [AllureTag("Moderator", "API", "TestCase ID#00009")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Owners")]
        [AllureStory("Ban")]
        public void Owners_WhenLoggedInAsModerator_ShouldBanOwner()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/moderator/owners";
            string json = "{\"id\":5}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsModerator(request));
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test, Order(8)]
        [AllureDescription("Test for moderator role, to check posibility to unban owners")]
        [AllureOwner("Vadym")]
        [AllureTag("Moderator", "API", "TestCase ID#00010")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Owners")]
        [AllureStory("Unban")]
        public void Owners_WhenLoggedInAsModerator_ShouldUnbanOwner()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/moderator/owners";
            string json = "{\"id\":5}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsModerator(request));
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
    }
}
