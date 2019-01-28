using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using System.Net;
using System.Net.Http;
using System.Text;
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
        public async Task CreatePitch_Should_ReturnUnsupportedMediaType()
        {
            var httpContent = new StringContent("Random string text");
            var response = await testContext.Client.PostAsync("/pitch", httpContent);
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        [Fact]
        public async Task CreatePitch_Should_ReturnUnauthorized()
        {
            var emptyDto = new PitchDto();
            var json = JsonConvert.SerializeObject(emptyDto);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await testContext.Client.PostAsync("/pitch", httpContent);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task CreatePitch_Should_ReturnCreated()
        {
            var inputDto = new PitchDto()
            {
                BadgeName = "English speaker",
                OldLvl = 2,
                PitchedLvl = 3,
                PitchMessage = "Hello World! My English is bloody gorgeous.",
                Holders = new[] { "balazs.jozsef", "benedek.vamosi", "balazs.barna" }
            };
            var json = JsonConvert.SerializeObject(inputDto);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpContent.Headers.Add("usertokenauth", "<generated UUID>");
            var response = await testContext.Client.PostAsync("/pitch", httpContent);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
