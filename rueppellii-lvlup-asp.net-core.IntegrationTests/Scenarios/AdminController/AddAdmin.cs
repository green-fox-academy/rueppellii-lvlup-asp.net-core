using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios.AdminController
{
    [Collection("TestCollection")]
    public class AddAdmin
    {
        private readonly TestContext _testContext;

        public AddAdmin(TestContext testContext)
        {
            this._testContext = testContext;
        }

        [Fact]
        public async Task Should_ReturnCreated()
        {
            var request = new AddAdminPostRequestMock(new AddAdminPostRequestMockBody().SetCorrectBody()).SetCorrectHeaders();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("{\"message\":\"Success\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnUnsupportedMediaType()
        {
            var request = new AddAdminPostRequestMock(new AddAdminPostRequestMockBody().SetCorrectBody()).SetMissingContentType();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);

            response = await _testContext.Client.PostAsync("/admin/add", request.SetXmlContentType());
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnUnauthorised()
        {
            var request = new AddAdminPostRequestMock(new AddAdminPostRequestMockBody().SetCorrectBody()).SetMissingUsertokenauth();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("{\"error\":\"Unauthorized\"}", response.Content.ReadAsStringAsync().Result);

            response = await _testContext.Client.PostAsync("/admin/add", request.SetEmptyUsertokenauth());
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("{\"error\":\"Unauthorized\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnBadRequest()
        {
            var request = new AddAdminPostRequestMock(new AddAdminPostRequestMockBody().SetMissingBody()).SetCorrectHeaders();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"Please provide all fields\"}", response.Content.ReadAsStringAsync().Result);

            request = new AddAdminPostRequestMock(new AddAdminPostRequestMockBody().SetEmptyStringsBody()).SetCorrectHeaders();
            response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"Please provide all fields\"}", response.Content.ReadAsStringAsync().Result);
        }
    }
}
