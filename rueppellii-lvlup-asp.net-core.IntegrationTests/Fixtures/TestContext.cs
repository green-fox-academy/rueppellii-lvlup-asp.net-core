using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using rueppellii_lvlup_asp.net_core.Services.Interfaces;

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
            Configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var builder = new WebHostBuilder()
            .UseEnvironment("Testing")
            .UseStartup<Startup>()
            .UseConfiguration(Configuration);

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
