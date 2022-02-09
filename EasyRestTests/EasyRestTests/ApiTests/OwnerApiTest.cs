using NUnit.Framework;
using Leaf.xNet;
using Newtonsoft.Json.Linq;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Tests.ApiTests
{
    [AllureNUnit]
    [AllureEpic("Owner_API")]
    [AllureSuite("API")]
    class OwnerApiTest : BaseApiTest
    {
        [Test, Order(1)]
        [AllureDescription("Test for owner role, to check posibility to create restaurant")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Owner", "API", "TestCase ID#00002")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Restaurant")]
        [AllureStory("Create")]
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
        [AllureDescription("Test for owner role, to check posibility to archive restaurant")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Owner", "API", "TestCase ID#00006")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Restaurant")]
        [AllureStory("Archive")]
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
        [AllureDescription("Test for owner role, to check posibility to edit details about restaurant")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Owner", "API", "TestCase ID#00001")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Restaurant")]
        [AllureStory("Edit details")]
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
        [AllureDescription("Test for owner role, to check posibility to create menu of restaurant")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Owner", "API", "TestCase ID#00003")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Restaurant")]
        [AllureStory("Create menu")]
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
        [AllureDescription("Test for owner role, to check posibility to create new waiter for restaurant")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Owner", "API", "TestCase ID#00004")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Restaurant")]
        [AllureStory("Create waiter")]
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
        [AllureDescription("Test for owner role, to check posibility to create new administrator for restaurant")]
        [AllureOwner("Misha Tokmakov")]
        [AllureTag("Owner", "API", "TestCase ID#00005")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureFeature("Restaurant")]
        [AllureStory("Create administrator")]
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