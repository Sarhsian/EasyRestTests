using NUnit.Framework;
using Leaf.xNet;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace Tests.ApiTests
{
    [AllureNUnit]
    [AllureEpic("UnloginedUser_API")]
    [AllureSuite("API")]
    [AllureLink("https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=1686602044")]
    class UnloginedApiTest : BaseApiTest
    {
        [Test]
        [AllureDescription("Test to check possibility to sign in as client")]
        [AllureOwner("Vitalii")]
        [AllureTag("UnloginedUser", "API", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("MainPage")]
        [AllureStory("SignIn")]
        public void SignInAsClient()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/login";
            string json = "{\"email\":\"katiedoyle@test.com\",\"password\":\"1111\"}";

            //Act            
            request.IgnoreProtocolErrors = true;
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test]
        [AllureDescription("Test to check possibility to sign up as client")]
        [AllureOwner("Vitalii")]
        [AllureTag("UnloginedUser", "API", "TestCase ID#00002")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("MainPage")]
        [AllureStory("SignUp")]
        public void SignUpAsClient()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/user/1";
            string json = "{\"name\": \"NewClient\",\"email\": \"newclient@test.com\",\"password\": \"12345678\",\"phone_number\": null,\"birth_date\": null}";

            //Act            
            request.IgnoreProtocolErrors = true;
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test]
        [AllureDescription("Test to check possibility to log out as client")]
        [AllureOwner("Vitalii")]
        [AllureTag("UnloginedUser", "API")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("MainPage")]
        [AllureStory("LogOut")]
        public void LogOutAsClient()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/login";            

            //Act            
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsClient(request));
            request.Delete(url);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test]
        [AllureDescription("Test to check possibility to check restaurants list")]
        [AllureOwner("Vitalii")]
        [AllureTag("UnloginedUser", "API")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("MainPage")]
        [AllureStory("CheckRestaurants")]
        public void CheckRestaurantList()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/restaurant";

            //Act            
            request.IgnoreProtocolErrors = true;            
            request.Get(url);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
    }
}
