using NUnit.Framework;
using Leaf.xNet;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace Tests.ApiTests
{
    [AllureNUnit]
    [AllureEpic("Admin_API")]
    [AllureSuite("API")]
    class ClientApiTest : BaseApiTest
    {
        [Test, Order(1)]
        [AllureDescription("Test for Client role, to check posibility to create a new Order")]
        [AllureOwner("Sarhsian")]
        [AllureTag("Client", "API", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Order")]
        [AllureStory("Create")]
        public void ClientMakesOrderCreateOrder()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/order";
            string json = "{\"rest_id\": \"2\"}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsClient(request));
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }

        [Test, Order(2)]
        [AllureDescription("Test for Client role, to check posibility to create a new Order")]
        [AllureOwner("Sarhsian")]
        [AllureTag("Client", "API", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Order")]
        [AllureStory("Create")]
        public void ClientMakesOrderAddToBascetOneItem()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/order/151";
            string json = "{\"item_id\": 20,\"q_value\": 1}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsClient(request));
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }

        [Test, Order(3)]
        [AllureDescription("Test for Client role, to check posibility to create a new Order")]
        [AllureOwner("Sarhsian")]
        [AllureTag("Client", "API", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Order")]
        [AllureStory("Create")]
        public void CLientMakesOrderSubmitOrderFromBasket()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/order/151/status";
            string json = "{\"new_status\": \"Waiting for confirm\",\"booked_time\": 1644342203}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsClient(request));
            request.Put(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }

        [Test, Order(4)]
        [AllureDescription("Test for client role, to check posibility to decline order in 'Current Orders'=>'Waiting to confirm'")]
        [AllureOwner("Sarhsian")]
        [AllureTag("Client", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureEpic("Client")]
        [AllureFeature("Waiting for confirm")]
        [AllureStory("Decline")]
        public void ClientDeclinesOrder_FromWaitingToConfirmTab_WhenLoggedIn()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/order/151/status";
            string json = "{\"new_status\": \"Declined\"}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsClient(request));
            request.Put(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }

        [Test, Order(5)]
        [AllureDescription("Test for client role, to check posibility to reorder order in 'Order History'=>'History'")]
        [AllureOwner("Sarhsian")]
        [AllureTag("Client", "TestCase ID#00002")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureEpic("Client")]
        [AllureFeature("History")]
        [AllureStory("Reorder")]
        public void ClientReordersOrder_FromHistoryTab_WhenLooggedIn()
        {
            ClientMakesOrderCreateOrder();
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/order/152/status";
            string json = "{\"new_status\": \"Waiting for confirm\",\"booked_time\": 1644344633}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetTokenAsClient(request));
            request.Put(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
    }
}
