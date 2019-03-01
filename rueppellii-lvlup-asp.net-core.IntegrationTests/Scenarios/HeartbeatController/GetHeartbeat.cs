using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios.HeartbeatController
{
    [Collection("TestCollection")]
    public class GetHeartbeat
    {
        private readonly TestContext testContext;

        public GetHeartbeat(TestContext testContext)
        {
            this.testContext = testContext;
            this.testContext.Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", testContext.AuthService.GetToken(
                    new[]
                    {
                        new Claim("test", "test")
                    }));
        }

        [Fact]
        public async Task Should_ReturnOK()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/heartbeat");
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("{\"message\":\"OK\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnError()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/heartbeat");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", string.Empty);
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
