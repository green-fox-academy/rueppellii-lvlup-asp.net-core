using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios.AdminController
{
    [Collection("TestCollection")]
    public class PostAdd
    {
        private readonly TestContext _testContext;

        public PostAdd(TestContext testContext)
        {
            _testContext = testContext;
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
            var content = new MockRequestContent(new BadgeDtoMock().SetCorrectBody()).SetContentTypeJson();
            var response = await _testContext.Client.PostAsync("/admin/add", content);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("{\"message\":\"Success\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnUnsupportedMediaType()
        {
            var content = new MockRequestContent(new BadgeDtoMock().SetCorrectBody());
            var response = await _testContext.Client.PostAsync("/admin/add", content);
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);

            response = await _testContext.Client.PostAsync("/admin/add", content.SetContentTypeXml());
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnUnauthorised()
        {
            _testContext.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "invalidJwt");
            var content = new MockRequestContent(new BadgeDtoMock().SetCorrectBody()).SetContentTypeJson();
            var response = await _testContext.Client.PostAsync("/admin/add", content);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

            _testContext.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", string.Empty);
            response = await _testContext.Client.PostAsync("/admin/add", content);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnBadRequest()
        {
            var content = new MockRequestContent(new BadgeDtoMock().SetMissingBody()).SetContentTypeJson();
            var response = await _testContext.Client.PostAsync("/admin/add", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"Please provide all fields\"}", response.Content.ReadAsStringAsync().Result);

            content = new MockRequestContent(new BadgeDtoMock().SetEmptyStringsBody()).SetContentTypeJson();
            response = await _testContext.Client.PostAsync("/admin/add", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"Please provide all fields\"}", response.Content.ReadAsStringAsync().Result);
        }
    }
}
