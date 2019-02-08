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
            var content = new MockRequestContent(new AddAdminPostRequestMockBody().SetCorrectBody())
                .SetContentTypeJson().SetJwt();
            var response = await _testContext.Client.PostAsync("/admin/add", content);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("{\"message\":\"Success\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnUnsupportedMediaType()
        {
            var request = new MockRequestContent(new AddAdminPostRequestMockBody().SetCorrectBody()).SetJwt();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);

            response = await _testContext.Client.PostAsync("/admin/add", request.SetContentTypeXml());
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnUnauthorised()
        {
            var request = new MockRequestContent(new AddAdminPostRequestMockBody().SetCorrectBody()).SetContentTypeJson();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("{\"error\":\"Unauthorized\"}", response.Content.ReadAsStringAsync().Result);

            response = await _testContext.Client.PostAsync("/admin/add", request.SetEmptyJwt());
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("{\"error\":\"Unauthorized\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnBadRequest()
        {
            var request = new MockRequestContent(new AddAdminPostRequestMockBody().SetMissingBody()).SetContentTypeJson();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"Please provide all fields\"}", response.Content.ReadAsStringAsync().Result);

            request = new MockRequestContent(new AddAdminPostRequestMockBody().SetEmptyStringsBody()).SetContentTypeJson();
            response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"Please provide all fields\"}", response.Content.ReadAsStringAsync().Result);
        }
    }
}
