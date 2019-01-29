using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios
{
    [Collection("TestCollection")]
    class GetPitchesTest
    {
        [Fact]
        public async Task Shoul_ReturnUnsupportedMediaType()
        {
            var httpContent = new StringContent("Random text");
            var response = await testContext.
        }
    }
}
