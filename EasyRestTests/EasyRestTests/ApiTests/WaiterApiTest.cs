using NUnit.Framework;
using Leaf.xNet;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace Tests.ApiTests
{
    [AllureNUnit]
    [AllureSuite("API")]
    [AllureEpic("Waiter_API")]
    [AllureLink("https://docs.google.com/spreadsheets/d/1KvQebEOdgZxL8gbtz1mG_5xvF9WzucCWdPmjLLTQuSw/edit#gid=1420718935")]
    class WaiterApiTest : BaseApiTest
    {
        [Test]
        [AllureDescription("Test for waiter role, to check posibility to start order")]
        [AllureOwner("Vitalii")]
        [AllureTag("Waiter", "API", "TestCase ID#00002")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Orders")]
        [AllureStory("Start order")]
        public void AssignedWaiter_WhenLoggedInAsWaiter_ShouldStartOrder()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/order/58/status";
            string json = "{\"new_status\": \"In progress\",\"booked_time\": 1644162683}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetToken("karenperez@test.com", "1", request));
            request.Put(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test]
        [AllureDescription("Test for waiter role, to check posibility to close order")]
        [AllureOwner("Vitalii")]
        [AllureTag("Waiter", "API", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Orders")]
        [AllureStory("Close order")]
        public void InProgress_WhenLoggedInAsWaiter_ShouldCloseOrder()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/order/74/status";
            string json = "{\"new_status\": \"History\",\"booked_time\": 1644162791}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetToken("karenperez@test.com", "1", request));
            request.Put(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test]
        [AllureDescription("Test for waiter role, to check posibility to get info about orders")]
        [AllureOwner("Vadym")]
        [AllureTag("Waiter", "API", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Orders")]
        [AllureStory("Info about orders")]
        public void All_WhenLoggedInAsWaiter_ShouldGetInfo()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/waiter/orders";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsWaiter1(request));
            request.Get(url);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
    }
}
