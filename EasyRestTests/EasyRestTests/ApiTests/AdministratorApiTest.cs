using NUnit.Framework;
using Leaf.xNet;
using Newtonsoft.Json.Linq;

namespace Tests.ApiTests
{
    class AdministratorApiTest : BaseApiTest
    {
        [Test]
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
