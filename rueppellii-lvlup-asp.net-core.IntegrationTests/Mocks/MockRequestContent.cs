using rueppellii_lvlup_asp.net_core.Services;
using System.Net.Http;
using System.Net.Http.Headers;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks
{
    public class MockRequestContent : StringContent
    {
        public MockRequestContent(string content) : base(content)
        {
        }

        public MockRequestContent SetContentTypeJson()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return this;
        }

        public MockRequestContent SetContentTypeXml()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
            return this;
        }
    }
}
