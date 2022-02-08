using NUnit.Framework;
using Leaf.xNet;
using Newtonsoft.Json.Linq;

namespace Tests.ApiTests
{
    class OwnerApiTest : BaseApiTest
    {
        [Test]
        public void CreateRestaurant_WhenLoggedInAsOwner_ShouldCreateNewRestaurant()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/user_restaurants";
            string json = @"{""name"":""NewPizzaRestaurant"",""address"":""Pizza street"",""phone"":""5555"",""description"":""Best Pizza"",""tags"":[""pizza""],""markup"":""{\""blocks\"":[{\""key\"":\""7cfj8\"",\""text\"":\""\"",\""type\"":\""unstyled\"",\""depth\"":0,\""inlineStyleRanges\"":[],\""entityRanges\"":[],\""data\"":{ }}],\""entityMap\"":{ }}""}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetToken("jasonbrown@test.com", "1111", request));
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, request.Response.StatusCode, $"Created is not equal for {request.Response.StatusCode}");
        }
        [Test]
        public void ArchieveRestaurant_WhenLoggedInAsOwner_ShouldArchieveRestaurant()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/delete_restaurant";
            string json = "{\"id\":8,\"status\":2}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetToken("jasonbrown@test.com", "1111", request));
            request.Put(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
    }
}
