using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios.PitchesController
{
    [Collection("TestCollection")]
    public class PutPitch
    {
        private readonly TestContext _testcontext;

        public PutPitch(TestContext testcontext)
        {
            this._testcontext = testcontext;
        }

        [Fact]
        public async Task Should_ReturnCreated()
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "/pitch");
            request.Headers.Add("ContentType", "application/json");
            request.Headers.Add("usertokentauth", "placeholder");
            var response = await _testcontext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("{\"message\": \"Success\"}", response.Content.ReadAsStringAsync().Result);
        }
    }
}
