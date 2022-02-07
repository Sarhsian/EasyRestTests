using NUnit.Framework;
using Leaf.xNet;
using Newtonsoft.Json.Linq;

namespace Tests
{
    public class ApiTest 
    {
        public string SignInToGetToken(string email, string password, HttpRequest request)
        {            
            string url = "http://localhost:6543/api/login";
            string json = "{\"email\":\""+email+ "\",\"password\":\"" + password + "\"}";            
            request.IgnoreProtocolErrors = true;
            string answer = request.Post(url, json, "json").ToString();
            var jOp = JObject.Parse(answer);
            string token = jOp["data"]["token"].ToString();
            return token;
        }
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
        [Test]
        public void CreatingModerator_WhenLoggedInAsAdmin_ShouldCreateNewModerator()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/user/3";
            string json = "{\"name\":\"NewModerator\",\"email\":\"newmoderator@test.com\",\"password\":\"12345678\",\"phone_number\":null,\"birth_date\":null}";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetToken("steveadmin@test.com", "1", request));
            request.Post(url, json, "json");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
        [Test]
        public void BanUser_WhenLoggedInAsAdmin_ShouldBanUser()
        {
            //Arrange
            var request = new HttpRequest();
            string url = "http://localhost:6543/api/user/toggle_activity/18";

            //Act
            request.IgnoreProtocolErrors = true;
            request.AddHeader("x-auth-token", SignInToGetToken("steveadmin@test.com", "1", request));
            request.Get(url);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, request.Response.StatusCode, $"OK is not equal for {request.Response.StatusCode}");
        }
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
