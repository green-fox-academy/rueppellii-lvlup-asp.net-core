using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios
{
    [Collection("TestCollection")]
    public class PostPitchTests
    {
        private readonly TestContext testContext;

        public PostPitchTests(TestContext testContext)
        {
            this.testContext = testContext;
        }

        [Fact]
        public async Task CreatePitch_Should_Return415()
        {
            var content = new StringContent("asdasdasdasda");
            var response = await testContext.Client.PostAsync("/pitch", content);
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }
    }
}
