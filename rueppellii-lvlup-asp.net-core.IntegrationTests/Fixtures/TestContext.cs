using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using rueppellii_lvlup_asp.net_core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Fixtures
{
    public class TestContext : IDisposable
    {
        private TestServer server;
        public HttpClient Client { get; set; }
        public IAuthService AuthService { get; internal set; }
        public IConfiguration Configuration { get; internal set; }

        public TestContext()
        {
            var builder = new WebHostBuilder()
            .UseEnvironment("Testing")
            .UseStartup<Startup>();

            Configuration = new ConfigurationBuilder()
                .AddUserSecrets("1f0d2808455195f476302e8eb4ccf6ad")
                .Build();
            server = new TestServer(builder);
            Client = server.CreateClient();
            AuthService = server.Host.Services.GetService<IAuthService>();
        }

        public void Dispose()
        {
            server.Dispose();
            Client.Dispose();
        }
    }
}
