using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks
{
    public class MockRequest : StringContent
    {
        public MockRequest(string content) : base(content)
        {
        }
        public MockRequest SetContentTypeJsonAndUsertokenauth()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            this.Headers.Add("usertokenauth", "<generated UUID>");
            return this;
        }
        public MockRequest SetUsertokenauth()
        {
            this.Headers.Add("usertokenauth", "<generated UUID>");
            return this;
        }
        public MockRequest SetContentTypeXmlAndUsertokenauth()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
            this.Headers.Add("usertokenauth", "<generated UUID>");
            return this;
        }
        public MockRequest SetContentTypeJson()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return this;
        }
        public MockRequest SetContentTypeJsonAndEmptyUsertokenauth()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            this.Headers.Add("usertokenauth", string.Empty);
            return this;
        }
    }
}
