using Leaf.xNet;
using Newtonsoft.Json.Linq;
using NUnit.Allure.Attributes;

namespace Tests
{
    public class BaseApiTest
    {
        public string SignInToGetToken(string email, string password, HttpRequest request)
        {
            string url = "http://localhost:6543/api/login";
            string json = "{\"email\":\"" + email + "\",\"password\":\"" + password + "\"}";
            request.IgnoreProtocolErrors = true;
            string answer = request.Post(url, json, "json").ToString();
            var jOp = JObject.Parse(answer);
            string token = jOp["data"]["token"].ToString();
            return token;
        }
        [AllureStep("Sign in as client and get token")]
        public string SignInToGetTokenAsClient(HttpRequest request)
        {
            return SignInToGetToken("katiedoyle@test.com", "1111",request);
        }
        [AllureStep("Sign in as owner and get token")]
        public string SignInToGetTokenAsOwner(HttpRequest request)
        {
            return SignInToGetToken("jasonbrown@test.com", "1111", request);
        }
        [AllureStep("Sign in as moderator and get token")]
        public string SignInToGetTokenAsModerator(HttpRequest request)
        {
            return SignInToGetToken("petermoderator@test.com", "1", request);
        }
        [AllureStep("Sign in as admin and get token")]
        public string SignInToGetTokenAsAdmin(HttpRequest request)
        {
            return SignInToGetToken("steveadmin@test.com", "1", request);
        }
        [AllureStep("Sign in as administrator and get token")]
        public string SignInToGetTokenAsAdministrator(HttpRequest request)
        {
            return SignInToGetToken("tanyasanchez@test.com", "1", request);
        }
        [AllureStep("Sign in as waiter and get token")]
        public string SignInToGetTokenAsWaiter1(HttpRequest request)
        {
            return SignInToGetToken("karenperez@test.com", "1", request);
        }
    }
}
