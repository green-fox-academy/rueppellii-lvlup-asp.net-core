using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using rueppellii_lvlup_asp.net_core.Models;
using System.Collections.Generic;
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
        private readonly BadgeDto[] list;

        public GetBadges(TestContext testContext)
        {
            this.testContext = testContext;
            this.testContext.Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", testContext.AuthService.GetToken(
                    new[]
                    {
                        new Claim("test", "test")
                    }));
            list = new[] {
                new BadgeDto() {Version = "v2.1", Name = "Process improve/initator", Tag = "general", Levels = new List<Level>()},
                new BadgeDto() {Version = "v1.1", Name = "English speaker", Tag = "mentor", Levels = new List<Level>()},
                new BadgeDto() {Version = "v1.1", Name = "Feedback receiver", Tag = "general", Levels = new List<Level>()},
                new BadgeDto() {Version = "v1.1", Name = "Feedback giver", Tag = "marketing", Levels = new List<Level>()},
                new BadgeDto() {Version = null, Name = "English speaker", Tag = null, Levels = new List<Level>()},
            };
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
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var json = JsonConvert.SerializeObject(list, serializerSettings);
            var request = new HttpRequestMessage(HttpMethod.Get, "/badges");
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(json, response.Content.ReadAsStringAsync().Result);
        }
    }
}
