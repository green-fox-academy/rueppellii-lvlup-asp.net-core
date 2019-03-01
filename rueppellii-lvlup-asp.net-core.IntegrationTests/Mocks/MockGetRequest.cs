using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks
{
    class MockGetRequest : HttpRequestMessage
    {

        public MockGetRequest(string requestUri) : base(HttpMethod.Get, requestUri)
        {
        }

        public MockGetRequest SetUsertokenauth(TestContext testContext)
        {
            Headers.Authorization = new AuthenticationHeaderValue("Bearer", testContext.AuthService.GetToken(
                new[]
                {
                    new Claim("test", "test")
                }));
            return this;
        }

        public MockGetRequest SetEmptyUsertokenauth()
        {
            Headers.Authorization = new AuthenticationHeaderValue("Bearer", string.Empty);
            return this;
        }

        public MockGetRequest SetNoUsertokenauth()
        {
            return this;
        }
    }
}
