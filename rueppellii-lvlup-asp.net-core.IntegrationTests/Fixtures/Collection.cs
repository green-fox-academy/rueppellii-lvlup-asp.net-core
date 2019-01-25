using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures
{
  [CollectionDefinition("TestCollection")]
  public class Collection : ICollectionFixture<TestContext>
  {
  }
}
