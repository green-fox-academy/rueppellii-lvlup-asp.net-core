using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
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
        }

        [Fact]
        public async Task Should_ReturnOK()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/heartbeat");
            request.Headers.Add("usertokenauth", "OK");
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("{\"message\":\"OK\"}", response.Content.ReadAsStringAsync().Result);
        } 

        [Fact]
        public async Task Should_ReturnError()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/heartbeat");
            request.Headers.Add("usertokenauth", string.Empty);
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("{\"error\":\"Unauthorizied\"}", response.Content.ReadAsStringAsync().Result);
        }
    }
}
