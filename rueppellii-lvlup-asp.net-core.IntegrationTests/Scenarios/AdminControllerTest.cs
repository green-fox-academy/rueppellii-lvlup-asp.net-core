using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.DTOs;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks;
using rueppellii_lvlup_asp.net_core.Utility;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios
{
    [Collection("TestCollection")]
    public class AdminControllerTest
    {
        private readonly TestContext _testContext;

        public AdminControllerTest(TestContext testContext)
        {
            this._testContext = testContext;
        }
        [Fact]
        public async Task Add_Should_Return_Created()
        {
            var request = new AddAdminPostRequestMock(new AddAdminPostRequestMockBody().SetCorrectBody()).SetCorrectHeaders();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(new ResponseMessage("Success")), await response.Content.ReadAsStringAsync());
        }
        [Fact]
        public async Task Incorrect_ContentType_Should_Return_UnsupportedMediaType()
        {
            var request = new AddAdminPostRequestMock(new AddAdminPostRequestMockBody().SetCorrectBody()).SetMissingContentType();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);

            response = await _testContext.Client.PostAsync("/admin/add", request.SetXmlContentType());
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }
        [Fact]
        public async Task Missing_Or_Empty_Usertokenauth_Should_Return_Unauthorised()
        {
            var request = new AddAdminPostRequestMock(new AddAdminPostRequestMockBody().SetCorrectBody()).SetMissingUsertokenauth();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(new ErrorMessage("usertokenauth missing")), await response.Content.ReadAsStringAsync());

            response = await _testContext.Client.PostAsync("/admin/add", request.SetEmptyUsertokenauth());
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(new ErrorMessage("usertokenauth missing")), await response.Content.ReadAsStringAsync());
        }
        [Fact]
        public async Task Missing_Or_Empty_RequestBody_Fields_Should_Return_BadRequest()
        {
            var request = new AddAdminPostRequestMock(new AddAdminPostRequestMockBody().SetMissingBody()).SetCorrectHeaders();
            var response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(new ErrorMessage("Please provide all fields")), await response.Content.ReadAsStringAsync());

            request = new AddAdminPostRequestMock(new AddAdminPostRequestMockBody().SetEmptyStringsBody()).SetCorrectHeaders();
            response = await _testContext.Client.PostAsync("/admin/add", request);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(new ErrorMessage("Please provide all fields")), await response.Content.ReadAsStringAsync());
        }
    }
}
