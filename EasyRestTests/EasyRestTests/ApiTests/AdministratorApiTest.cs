using NUnit.Framework;
using Leaf.xNet;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace Tests.ApiTests
{
    [AllureNUnit]
    [AllureEpic("Administrator_API")]
    [AllureSuite("API")]
    class AdministratorApiTest : BaseApiTest
    {
        [Test]
        [AllureDescription("Test for administrator role, to check posibility to see information about assigned waiter order")]
        [AllureOwner("Volodymyr")]
        [AllureTag("Administator", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Assigned waiter")]
        [AllureStory("Check info about order")]
        public void AssignedWaiterTab_WhenLoggedIn_ShouldShowInfoAboutSelectedOrder()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/orders";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsAdministrator(request));
            request.Get(url);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }

        [Test]
        [AllureDescription("Test for administrator role, to check posibility to see the information about waiter's orders")]
        [AllureOwner("Volodymyr")]
        [AllureTag("Administator", "TestCase ID#00004")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Waiter")]
        [AllureStory("Check info about order")]
        public void WaiterTab_WhenLoggedIn_ShouldShowInfoAboutOrder()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/waiters?with_orders=True";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsAdministrator(request));
            request.Get(url);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }

        [Test]
        [AllureDescription("Test for administrator role, to check posibility to accept waiting to confirm orders")]
        [AllureOwner("Vitalii")]
        [AllureTag("Administator", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Waiting to confirm")]
        [AllureStory("Confirm order")]
        public void WaitingForConfirm_WhenLoggedInAsAdministrator_ShouldAcceptOrder()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/order/146/status";
            string json = "{\"new_status\": \"Accepted\"}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetToken("tanyasanchez@test.com", "1", request));
            request.Put(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }

        [Test]
        [AllureDescription("Test for administrator role, to check posibility to assign accepted orders")]
        [AllureOwner("Vitalii")]
        [AllureTag("Administator", "TestCase ID#00002")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Accepted")]
        [AllureStory("Assign order")]
        public void WaitingForAssign_WhenLoggedInAsAdministrator_ShouldAssignOrderForWaiter()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/order/132/status";
            string json = "{\"set_waiter_id\": 42,\"new_status\": \"Assigned waiter\"}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetToken("tanyasanchez@test.com", "1", request));
            request.Put(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
    }
}
