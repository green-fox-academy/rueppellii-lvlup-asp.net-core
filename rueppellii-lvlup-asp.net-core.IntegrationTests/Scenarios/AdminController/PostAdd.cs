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
            var request = new MockRequest(new AddAdminPostRequestMockBody().SetCorrectBody()).SetContentTypeJsonAndUsertokenauth();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("{\"message\":\"Success\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnUnsupportedMediaType()
        {
            var request = new MockRequest(new AddAdminPostRequestMockBody().SetCorrectBody()).SetUsertokenauth();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);

            response = await _testContext.Client.PostAsync("/admin/add", request.SetContentTypeXmlAndUsertokenauth());
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnUnauthorised()
        {
            var request = new MockRequest(new AddAdminPostRequestMockBody().SetCorrectBody()).SetContentTypeJson();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("{\"error\":\"Unauthorized\"}", response.Content.ReadAsStringAsync().Result);

            response = await _testContext.Client.PostAsync("/admin/add", request.SetContentTypeJsonAndEmptyUsertokenauth());
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("{\"error\":\"Unauthorized\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnBadRequest()
        {
            var request = new MockRequest(new AddAdminPostRequestMockBody().SetMissingBody()).SetContentTypeJsonAndUsertokenauth();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"Please provide all fields\"}", response.Content.ReadAsStringAsync().Result);

            request = new MockRequest(new AddAdminPostRequestMockBody().SetEmptyStringsBody()).SetContentTypeJsonAndUsertokenauth();
            response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"Please provide all fields\"}", response.Content.ReadAsStringAsync().Result);
        }
    }
}
