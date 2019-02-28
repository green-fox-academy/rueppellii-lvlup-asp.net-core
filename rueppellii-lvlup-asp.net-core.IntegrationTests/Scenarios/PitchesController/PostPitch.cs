using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios.PitchesController
{
    [Collection("TestCollection")]
    public class PostPitch
    {
        private readonly TestContext testContext;
        private readonly GetPitchDto emptyDto;
        private readonly GetPitchDto validDto;

        public PostPitch(TestContext testContext)
        {
            this.testContext = testContext;
            this.testContext.Client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", testContext.AuthService.GetToken(
                    new[]
                    {
                        new Claim("test", "test")
                    }));
            emptyDto = new GetPitchDto();
            validDto = new GetPitchDto()
            {
                BadgeName = "English speaker",
                OldLVL = 2,
                PitchedLevel = 3,
                PitchMessage = "Hello World! My English is bloody gorgeous.",
                Reviewers = new List<ReviewerDto>()
                {
                    new ReviewerDto
                    {
                        Name = "test reviewer",
                    }
                }
            };
        }

        [Fact]
        public async Task Should_ReturnUnsupportedMediaType()
        {
            var httpContent = new StringContent("Random string text");
            var response = await testContext.Client.PostAsync("/pitch", httpContent);
            Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnUnauthorised()
        {
            var json = JsonConvert.SerializeObject(emptyDto);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            testContext.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", string.Empty);
            var response = await testContext.Client.PostAsync("/pitch", httpContent);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnBadRequest()
        {
            var json = JsonConvert.SerializeObject(emptyDto);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await testContext.Client.PostAsync("/pitch", httpContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"One or more fields are empty.\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnCreated()
        {
            var json = JsonConvert.SerializeObject(validDto);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await testContext.Client.PostAsync("/pitch", httpContent);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("{\"message\":\"Success\"}", response.Content.ReadAsStringAsync().Result);
        }
    }
}
