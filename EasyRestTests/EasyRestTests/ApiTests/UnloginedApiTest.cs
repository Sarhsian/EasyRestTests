using NUnit.Framework;
using Leaf.xNet;
using Newtonsoft.Json.Linq;

namespace Tests.ApiTests
{
    class UnloginedApiTest : BaseApiTest
    {
        [Test]
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
    }
}
