using NUnit.Framework;
using Leaf.xNet;
using Newtonsoft.Json.Linq;

namespace Tests.ApiTests
{
    class OwnerApiTest : BaseApiTest
    {
        [Test, Order(1)]
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

        [Test, Order(2)]
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

        [Test, Order(3)]
        public void EditDetails_WhenLoggedInAsOwner_ShouldEditDetailsAboutRestaurant()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/user_restaurant/11";
            string json = @"{""name"":""LuxuryRestaurant"",""address"":""Luxury street"",""phone"":""6666"",""description"":""Best eat"",""tags"":[""pizza""],""markup"":""{\""blocks\"":[{\""key\"":\""7cfj8\"",\""text\"":\""\"",\""type\"":\""unstyled\"",\""depth\"":0,\""inlineStyleRanges\"":[],\""entityRanges\"":[],\""data\"":{ }}],\""entityMap\"":{ }}""}";
            
            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetToken("jasonbrown@test.com", "1111", request));
            request.Put(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, request.Response.StatusCode, $"Created is not equal for {request.Response.StatusCode}");
        }

        [Test, Order(4)]
        public void CreateMenu_WhenLoggedInAsOwner_ShouldCreteMenuOfRestaurant()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/restaurant/11/menu";
            string json = "{\"menuName\": \"Luxury Menu\",\"image\": null,\"menuItems\": []}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetToken("jasonbrown@test.com", "1111", request));
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"Created is not equal for {request.Response.StatusCode}");
        }

        [Test, Order(5)]
        public void CreateWaiter_WhenLoggedInAsOwner_ShouldCreteNewWaiterForRestaurant()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/user/6";
            string json = "{\"name\": \"SuperWaiter\",\"email\": \"SuperW@test.com\",\"password\": \"11111111\",\"phone_number\": \"11111111\",\"birth_date\": \"2022-02-08T12:45:33.243Z\",\"restaurant_id\": \"11\"}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetToken("jasonbrown@test.com", "1111", request));
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"Created is not equal for {request.Response.StatusCode}");
        }

        [Test, Order(6)]
        public void CreateAdministrator_WhenLoggedInAsOwner_ShouldCreteNewAdministratorForRestaurant()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/user/5";
            string json = "{\"name\": \"SuperAdministrator\",\"email\": \"SuperAdministrator@test.com\",\"password\": \"11111111\",\"phone_number\": \"11111111\",\"birth_date\": \"2022-02-08T12:58:34.863Z\",\"restaurant_id\": \"11\"}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetToken("jasonbrown@test.com", "1111", request));
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"Created is not equal for {request.Response.StatusCode}");
        }
    }
}   