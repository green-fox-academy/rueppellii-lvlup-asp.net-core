using rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Scenarios.PitchesController
{
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

        }
    }
}
