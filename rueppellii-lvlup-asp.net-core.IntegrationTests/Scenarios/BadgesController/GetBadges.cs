﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios.BadgesController
{
    [Collection("TestCollection")]
    public class GetBadges
    {
        private readonly TestContext testContext;
        private readonly LevelDto[] list;

        public GetBadges(TestContext testContext)
        {
            this.testContext = testContext;
            list[0] = new LevelDto() { Name = "Process Improver", Level = 2 };
            list[1] = new LevelDto() { Name = "English Speaker", Level = 1 };
            list[2] = new LevelDto() { Name = "Feedback Giver", Level = 1 };
        }

        [Fact]
        public async Task Should_ReturnOK()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/badges");
            request.Headers.Add("usertokenauth", "gen");
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnUnauthorised()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/badges");
            request.Headers.Add("usertokenauth", "invalid");
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnBadges()
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var json = JsonConvert.SerializeObject(list, serializerSettings);
            var request = new HttpRequestMessage(HttpMethod.Get, "/badges");
            request.Headers.Add("usertokenauth", "gen");
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(json, response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnErrorMessage()
        {
            string errorMessage = "{\"error\":\"Unauthorized\"}";
            var request = new HttpRequestMessage(HttpMethod.Get, "/badges");
            request.Headers.Add("usertokenauth", "invalid");
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(errorMessage, response.Content.ReadAsStringAsync().Result);
        }
    }
}
