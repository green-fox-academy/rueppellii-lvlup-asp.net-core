using rueppellii_lvlup_asp.net_core.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks
{
    public class MockRequestContent : StringContent
    {
        public IAuthService AuthService { get; }

        public MockRequestContent(IAuthService authService, string content) : base(content)
        {
            this.AuthService = authService;
        }
        public MockRequestContent SetJwt()
        {
            this.Headers.Add("Authorization", "Bearer " + AuthService.GetToken(new[]
                            {
                    new Claim("test", "test")
            }));
            return this;
        }
        public MockRequestContent SetContentTypeJson()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return this;
        }
        public MockRequestContent SetEmptyJwt()
        {
            this.Headers.Add("Authorization", "Bearer ");
            return this;
        }
        public MockRequestContent SetContentTypeXml()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
            return this;
        }
    }
}
