using NUnit.Framework;
using Leaf.xNet;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace Tests.ApiTests
{
    [AllureNUnit]
    [AllureEpic("Client_API")]
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
        public void CreatingOrder_WhenLoggedInAsClient_ShouldCreateOrder()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/order";
            string json = "{\"rest_id\": \"2\"}";

            //Act
            request.IgnoreProtocolErrors = true;
            string token = SignInToGetTokenAsClient(request);
            request.AddHeader("x-auth-token", token);
            string answer = request.Post(url, json, "json").ToString();
            var jObject = JObject.Parse(answer);
            string orderId = jObject["data"]["order_id"].ToString();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"{HttpStatusCode.OK} is not equal for {request.Response.StatusCode}");          
            
            //Arrange
            var request1 = new HttpRequest();
            url = "http://localhost:6543/api/order/" + orderId;
            json = "{\"item_id\": 20,\"q_value\": 1}";      
            
            //Act
            request1.IgnoreProtocolErrors = true;
            request1.AddHeader("x-auth-token", token);
            request1.Post(url, json, "json");
         
            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");

            //Arrange
            var request3 = new HttpRequest();
            url = "http://localhost:6543/api/order/"+orderId+"/status";
            json = "{\"new_status\": \"Waiting for confirm\",\"booked_time\": 1644342203}";

            //Act
            request3.IgnoreProtocolErrors = true;
            request3.AddHeader("x-auth-token", SignInToGetTokenAsClient(request));
            request3.Put(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        
        [Test, Order(2)]
        [AllureDescription("Test for client role, to check posibility to decline order in 'Current Orders'=>'Waiting to confirm'")]
        [AllureOwner("Sarhsian")]
        [AllureTag("Client", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureFeature("Waiting for confirm")]
        [AllureStory("Decline")]
        public void DeclinesOrder_WhenLoggedInAsClient_ShouldDeleteOrderFromWaitingToConfirmTab()
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

        [Test, Order(3)]
        [AllureDescription("Test for client role, to check posibility to reorder order in 'Order History'=>'History'")]
        [AllureOwner("Sarhsian")]
        [AllureTag("Client", "TestCase ID#00002")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("History")]
        [AllureStory("Reorder")]
        public void ReordersOrder_WhenLoggedInAsClient_ShouldCreateNewOrder()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/order";
            string json = "{\"rest_id\": \"2\"}";

            //Act
            request.IgnoreProtocolErrors = true;
            string token = SignInToGetTokenAsClient(request);
            request.AddHeader("x-auth-token", token);
            string answer = request.Post(url, json, "json").ToString();
            var jObject = JObject.Parse(answer);
            string reorderId = jObject["data"]["order_id"].ToString();
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"{HttpStatusCode.OK} is not equal for {request.Response.StatusCode}");

            //Arrange
            var request1 = new HttpRequest();
            url = "http://localhost:6543/api/order/"+reorderId+"/status";
            json = "{\"new_status\": \"Waiting for confirm\",\"booked_time\": 1644344633}";

            //Act
            request1.IgnoreProtocolErrors = true;
            request1.AddHeader("x-auth-token", SignInToGetTokenAsClient(request));
            request1.Put(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
    }
}
