using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
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
        public async Task Add_Should_ReturnCreated()
        {
            
        }
    }
}
