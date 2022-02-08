using NUnit.Framework;
using Leaf.xNet;
using Newtonsoft.Json.Linq;

namespace Tests.ApiTests
{
    class WaiterApiTest : BaseApiTest
    {
        [Test]
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
    }
}
