﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures
{
  public class TestContext : IDisposable
  {
    private TestServer server;
    public HttpClient Client { get; set; }
    public object Context { get; internal set; }

    public TestContext()
    {
      var builder = new WebHostBuilder()
      .UseEnvironment("Testing")
      .UseStartup<Startup>();

      server = new TestServer(builder);
      Client = server.CreateClient();
    }

    public void Dispose()
    {
      server.Dispose();
      Client.Dispose();
    }
  }
}
