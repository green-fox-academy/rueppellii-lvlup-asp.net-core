using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using rueppellii_lvlup_asp.net_core.Structs;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios
{
    [Collection("TestCollection")]
    public class GetPitchesTest
    {
        private readonly TestContext testContext;

        public GetPitchesTest(TestContext testContext)
        {
            this.testContext = testContext;                
         }
       
        [Fact]
        public async Task GetPitches_Should_Return_UnAuthorized()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/pitches");
            request.Headers.Add("usertokenauth", string.Empty);
            var response = await testContext.Client.SendAsync(request);
            var message = new ErrorMessage("Unauthorizied");
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(message), await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task GetPitches_Should_Return_OK()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/pitches");
            request.Headers.Add("usertokenauth", "OK");
            var response = await testContext.Client.SendAsync(request);
            string jsonResponse = "{    \"myPitches\": [        {            \"timeStamp\": \"2018-11-29 17:10:47\",            \"userName\": \"balazs.barna\",            \"badgeName\": \"Programming\",            \"oldLvl\": 2,            \"pitchedLvl\": 3,            \"pitchMessage\": \"I improved in React, Redux, basic JS, NodeJS, Express and in LowDB, pls give me more money\",            \"holders\": [               {                    \"name\": \"sandor.vass\",                    \"message\": null,                    \"pitchStatus\": false                }            ]        }    ],    \"pitchesToReview\": [        {            \"timeStamp\": \"2018-11-29 17:10:47\",            \"userName\": \"berei.daniel\",            \"badgeName\": \"English speaker\",            \"oldLvl\": 2,            \"pitchedLvl\": 3,            \"pitchMessage\": \"I was working abroad for six years, so I can speak english very well. Pls improve my badge level to 3.\",            \"holders\": [                {                  \"name\": \"balazs.jozsef\",                  \"message\": \"Yes, you are able to speak english\",                 \"pitchStatus\": true                }            ]        }    ]}";
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(jsonResponse, response.Content.ReadAsStringAsync().Result);
        }



    }
}
