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
        public AuthService AuthService { get; internal set; }

        public TestContext()
        {
            var builder = new WebHostBuilder()
            .UseEnvironment("Testing")
            .UseStartup<Startup>();

            server = new TestServer(builder);
            Client = server.CreateClient();
            AuthService = server.Host.Services.GetService<AuthService>();
        }

        public void Dispose()
        {
            server.Dispose();
            Client.Dispose();
        }
    }
}
