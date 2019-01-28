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
    public class AddAdminDtoMockHeaders : StringContent
    {
        public AddAdminDtoMockHeaders(string content) : base(content)
        {
        }
        public AddAdminDtoMockHeaders SetCorrectHeaders()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            this.Headers.Add("usertokenauth", "<generated UUID>");
            return this;
        }
        public AddAdminDtoMockHeaders SetMissingContentTypeHeader()
        {
            this.Headers.Add("usertokenauth", "<generated UUID>");
            return this;
        }
        public AddAdminDtoMockHeaders SetXmlContetnType()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
            this.Headers.Add("usertokenauth", "<generated UUID>");
            return this;
        }
        public AddAdminDtoMockHeaders SetMissingUsertokenauth()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return this;
        }
        public AddAdminDtoMockHeaders SetEmptyUsertokenauth()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            this.Headers.Add("usertokenauth", "");
            return this;
        }
    }
}
