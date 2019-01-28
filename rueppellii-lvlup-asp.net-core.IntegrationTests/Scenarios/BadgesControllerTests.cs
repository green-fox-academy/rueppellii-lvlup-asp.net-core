using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios
{
  [Collection("TestCollection")]
  public class BadgesControllerTests
  {
    private readonly TestContext testContext;

    public BadgesControllerTests(TestContext testContext)
    {
      this.testContext = testContext;
    }

    [Fact]
    public async Task ListBadges_Should_ReturnOK()
    {
      var request = new HttpRequestMessage(HttpMethod.Get, "/badges");
      request.Headers.Add("usertokenauth", "gen");
      var response = await testContext.Client.SendAsync(request);
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task ListBadges_Should_ReturnUnauthorized()
    {
      var request = new HttpRequestMessage(HttpMethod.Get, "/badges");
      request.Headers.Add("usertokenauth", "");
      var response = await testContext.Client.SendAsync(request);
      Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
  }
}
