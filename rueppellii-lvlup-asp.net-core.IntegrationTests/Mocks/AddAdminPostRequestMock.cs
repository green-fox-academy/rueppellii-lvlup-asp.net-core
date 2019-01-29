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
    public class AddAdminPostRequestMock : StringContent
    {
        public AddAdminPostRequestMock(string content) : base(content)
        {
        }
        public AddAdminPostRequestMock SetCorrectHeaders()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            this.Headers.Add("usertokenauth", "<generated UUID>");
            return this;
        }
        public AddAdminPostRequestMock SetMissingContentType()
        {
            this.Headers.Add("usertokenauth", "<generated UUID>");
            return this;
        }
        public AddAdminPostRequestMock SetXmlContentType()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
            this.Headers.Add("usertokenauth", "<generated UUID>");
            return this;
        }
        public AddAdminPostRequestMock SetMissingUsertokenauth()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return this;
        }
        public AddAdminPostRequestMock SetEmptyUsertokenauth()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            this.Headers.Add("usertokenauth", "");
            return this;
        }
    }
}
