using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using rueppellii_lvlup_asp.net_core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures
{
    public class TestContext : IDisposable
    {
        private TestServer server;
        public HttpClient Client { get; set; }
        public object Context { get; internal set; }
        public AuthService AuthService { get; set; }

        public TestContext()
        {
            var builder = new WebHostBuilder()
            .UseEnvironment("Testing")
            .UseStartup<Startup>();

            server = new TestServer(builder);
            AuthService = server.Host.Services.GetService<AuthService>();
            Client = server.CreateClient();
        }

        public void Dispose()
        {
            server.Dispose();
            Client.Dispose();
        }
    }
}
