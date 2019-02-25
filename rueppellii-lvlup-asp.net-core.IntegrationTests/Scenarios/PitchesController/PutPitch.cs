using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
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
            _testContext = testcontext;
            _testContext.Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _testContext.AuthService.GetToken(
                    new[]
                    {
                        new Claim("test", "test")
                    }));
        }

        [Fact]
        public async Task Should_ReturnCreated()
        {
            var request = new MockRequestContent(new PutPitchRequestMockBody().SetCorrectBody()).SetContentTypeJson();
            var response = await _testContext.Client.PutAsync("/pitch", request);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("{\"message\":\"Success\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnUnsupportedMediaType()
        {
            var request = new MockRequestContent(new PutPitchRequestMockBody().SetCorrectBody());
            var response = await _testContext.Client.PutAsync("/pitch", request);
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);

            response = await _testContext.Client.PutAsync("/pitch", request.SetContentTypeXml());
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnUnauthorised()
        {
            _testContext.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "invalidJwt");
            var request = new MockRequestContent(new PutPitchRequestMockBody().SetCorrectBody()).SetContentTypeJson();
            var response = await _testContext.Client.PutAsync("/pitch", request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

            _testContext.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", string.Empty);
            response = await _testContext.Client.PutAsync("/pitch", request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnBadRequest()
        {
            var request = new MockRequestContent(new PutPitchRequestMockBody().SetMissingBody()).SetContentTypeJson();
            var response = await _testContext.Client.PutAsync("/pitch", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"Please provide all fields\"}", response.Content.ReadAsStringAsync().Result);

            request = new MockRequestContent(new PutPitchRequestMockBody().SetEmptyStringsBody()).SetContentTypeJson();
            response = await _testContext.Client.PutAsync("/pitch", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"Please provide all fields\"}", response.Content.ReadAsStringAsync().Result);
        }
    }
}
