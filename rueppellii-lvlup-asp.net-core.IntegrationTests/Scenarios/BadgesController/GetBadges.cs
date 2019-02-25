using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using rueppellii_lvlup_asp.net_core.Containers;
using rueppellii_lvlup_asp.net_core.DTOs;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios.BadgesController
{
    [Collection("TestCollection")]
    public class GetBadges
    {
        private readonly TestContext testContext;
        private readonly ObjectContainer objectContainer;

        public GetBadges(TestContext testContext)
        {
            this.testContext = testContext;
            this.testContext.Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", testContext.AuthService.GetToken(
                    new[]
                    {
                        new Claim("test", "test")
                    }));

            objectContainer = new ObjectContainer();
            objectContainer.Badges[0] = new LevelDto() { Name = "Process Improver", Level = 2 };
            objectContainer.Badges[1] = new LevelDto() { Name = "English Speaker", Level = 1 };
            objectContainer.Badges[2] = new LevelDto() { Name = "Feedback Giver", Level = 1 };
        }

        [Fact]
        public async Task Should_ReturnOK()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/badges");
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnUnauthorised()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/badges");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "invalidJwt");
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnBadges()
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var json = JsonConvert.SerializeObject(objectContainer, serializerSettings);
            var request = new HttpRequestMessage(HttpMethod.Get, "/badges");
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(json, response.Content.ReadAsStringAsync().Result);
        }
    }
}
