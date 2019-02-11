using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks;
using System.Net;
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
            this._testContext = testContext;
        }
        
        [Fact]
        public async Task Should_ReturnCreated()
        {
            var content = new MockRequestContent(_testContext.AuthService,
                new BadgeDtoMock().SetCorrectBody()).SetContentTypeJson().SetJwt();
            var response = await _testContext.Client.PostAsync("/admin/add", content);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("{\"message\":\"Success\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnUnsupportedMediaType()
        {
            var content = new MockRequestContent(_testContext.AuthService,
                new BadgeDtoMock().SetCorrectBody()).SetJwt();
            var response = await _testContext.Client.PostAsync("/admin/add", content);
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);

            response = await _testContext.Client.PostAsync("/admin/add", content.SetContentTypeXml());
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnUnauthorised()
        {
            var content = new MockRequestContent(_testContext.AuthService,
                new BadgeDtoMock().SetCorrectBody()).SetContentTypeJson();
            var response = await _testContext.Client.PostAsync("/admin/add", content);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

            response = await _testContext.Client.PostAsync("/admin/add", content.SetEmptyJwt());
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnBadRequest()
        {
            var content = new MockRequestContent(_testContext.AuthService,
                new BadgeDtoMock().SetMissingBody()).SetContentTypeJson().SetJwt();
            var response = await _testContext.Client.PostAsync("/admin/add", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"Please provide all fields\"}", response.Content.ReadAsStringAsync().Result);

            content = new MockRequestContent(_testContext.AuthService,
                new BadgeDtoMock().SetEmptyStringsBody()).SetContentTypeJson().SetJwt();
            response = await _testContext.Client.PostAsync("/admin/add", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"Please provide all fields\"}", response.Content.ReadAsStringAsync().Result);
        }
    }
}
