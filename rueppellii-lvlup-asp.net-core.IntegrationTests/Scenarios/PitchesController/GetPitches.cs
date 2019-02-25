﻿using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios.PitchesController
{
    [Collection("TestCollection")]
    public class GetPitches
    {
        private readonly TestContext testContext;

        public GetPitches(TestContext testContext)
        {
            this.testContext = testContext;
        }

        [Fact]
        public async Task Should_ReturnUnauthorised()
        {
            var request = new MockGetRequest("/pitches").SetNoUsertokenauth();
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

            request.SetEmptyUsertokenauth();
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnOK()
        {
            var request = new MockGetRequest("/pitches").SetUsertokenauth(testContext);
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(MockJsonResponse.json, response.Content.ReadAsStringAsync().Result);
        }
    }
}
