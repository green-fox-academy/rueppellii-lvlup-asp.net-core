using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using rueppellii_lvlup_asp.net_core.Structs;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios
{
    [Collection("TestCollection")]
    public class GetPitchesTest
    {
        private readonly TestContext testContext;

        public GetPitchesTest(TestContext testContext)
        {
            this.testContext = testContext;                
         }
       
        [Fact]
        public async Task GetPitches_Should_Return_UnAuthorized()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/pitches");
            request.Headers.Add("usertokenauth", string.Empty);
            var response = await testContext.Client.SendAsync(request);
            var message = new ErrorMessage("Unauthorizied");
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(message), await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task GetPitches_Should_Return_OK()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/pitches");
            request.Headers.Add("usertokenauth", "OK");
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("success", response.Content.ReadAsStringAsync().Result);
        }



    }
}
