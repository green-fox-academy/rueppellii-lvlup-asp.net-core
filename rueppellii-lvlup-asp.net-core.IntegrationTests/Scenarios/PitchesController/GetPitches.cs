using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using rueppellii_lvlup_asp.net_core.Utility;
using System.Net;
using System.Net.Http;
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
            var request = new HttpRequestMessage(HttpMethod.Get, "/pitches");
            request.Headers.Add("usertokenauth", string.Empty);
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("{\"error\":\"Unauthorized\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnOK()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/pitches");
            request.Headers.Add("usertokenauth", "OK");
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(Mocks.MockJsonResponse.json, response.Content.ReadAsStringAsync().Result);
        }
    }
}
