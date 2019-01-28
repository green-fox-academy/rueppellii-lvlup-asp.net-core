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
        private string _requestBody { get; set; }

    public AdminControllerTest(TestContext testContext)
        {
            this._testContext = testContext;
            this._requestBody = JsonConvert.SerializeObject(new AddAdminDto
            {
                Version = 2.3,
                Name = "Badge inserter",
                Tag = "general",
                Levels = "[]"
            });
        }
        [Fact]
        public async Task Add_Should_ReturnCreated()
        {
            var content = new AddAdminDtoMockHeaders(_requestBody);
            content.SetCorrectHeaders();
            var response = await _testContext.Client.PostAsync("/admin/add", content);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(new ResponseMessage("Success")), await response.Content.ReadAsStringAsync());

        }
}
}
