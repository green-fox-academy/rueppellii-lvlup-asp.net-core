using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.DTOs;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios.PitchesController
{
    [Collection("TestCollection")]
    public class PostPitch
    {
        private readonly TestContext testContext;
        private readonly PostPitchDto emptyDto;
        private readonly PostPitchDto validDto;

        public PostPitch(TestContext testContext)
        {
            this.testContext = testContext;
            emptyDto = new PostPitchDto();
            validDto = new PostPitchDto()
            {
                BadgeName = "English speaker",
                OldLVL = 2,
                PitchedLVL = 3,
                PitchMessage = "Hello World! My English is bloody gorgeous.",
                Holders = new List<ReviewerDto>()
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
            Assert.Equal("", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnUnauthorised()
        {
            var json = JsonConvert.SerializeObject(emptyDto);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await testContext.Client.PostAsync("/pitch", httpContent);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("{\"error\":\"Unauthorized\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnBadRequest()
        {
            var json = JsonConvert.SerializeObject(emptyDto);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpContent.Headers.Add("usertokenauth", "<generated UUID>");
            var response = await testContext.Client.PostAsync("/pitch", httpContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"error\":\"One or more fields are empty.\"}", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task Should_ReturnCreated()
        {
            var json = JsonConvert.SerializeObject(validDto);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpContent.Headers.Add("usertokenauth", "<generated UUID>");
            var response = await testContext.Client.PostAsync("/pitch", httpContent);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("{\"message\":\"Success\"}", response.Content.ReadAsStringAsync().Result);
        }
    }
}
