using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios.PitchesController
{
    [Collection("TestCollection")]
    public class PutPitch
    {
        private readonly TestContext _testContext;

        public PutPitch(TestContext testcontext)
        {
            this._testContext = testcontext;
        }

        [Fact]
        public async Task Should_ReturnCreated()
        {
            var request = new MockRequestContent(new PutPitchRequestMockBody().SetCorrectBody()).SetContentTypeJsonAndUsertokenauth();
            var response = await _testContext.Client.PutAsync("/pitch", request);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("{\"message\":\"Success\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnUnsupportedMediaType()
        {
            var request = new MockRequestContent(new PutPitchRequestMockBody().SetCorrectBody()).SetUsertokenauth();
            var response = await _testContext.Client.PutAsync("/pitch", request);
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);

            response = await _testContext.Client.PutAsync("/pitch", request.SetContentTypeXmlAndUsertokenauth());
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnUnauthorised()
        {
            var request = new MockRequestContent(new PutPitchRequestMockBody().SetCorrectBody()).SetContentTypeJson();
            var response = await _testContext.Client.PutAsync("/pitch", request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("{\"error\":\"Unauthorized\"}", response.Content.ReadAsStringAsync().Result);

            response = await _testContext.Client.PutAsync("/pitch", request.SetContentTypeJsonAndEmptyUsertokenauth());
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("{\"error\":\"Unauthorized\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnBadRequest()
        {
            var request = new MockRequestContent(new PutPitchRequestMockBody().SetMissingBody()).SetContentTypeJsonAndUsertokenauth();
            var response = await _testContext.Client.PutAsync("/pitch", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"Please provide all fields\"}", response.Content.ReadAsStringAsync().Result);

            request = new MockRequestContent(new PutPitchRequestMockBody().SetEmptyStringsBody()).SetContentTypeJsonAndUsertokenauth();
            response = await _testContext.Client.PutAsync("/pitch", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"Please provide all fields\"}", response.Content.ReadAsStringAsync().Result);
        }
    }
}
