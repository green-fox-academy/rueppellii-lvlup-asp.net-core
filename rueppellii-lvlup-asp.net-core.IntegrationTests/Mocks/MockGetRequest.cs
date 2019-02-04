using System;
using System.Net.Http;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks
{
    class MockGetRequest : HttpRequestMessage
    {

        public MockGetRequest(string requestUri) : base(HttpMethod.Get, requestUri)
        {
        }

        public MockGetRequest SetUsertokenauth()
        {
            this.Headers.Add("usertokenauth", "<generated UUID>");
            return this;
        }

        public MockGetRequest SetEmptyUsertokenauth()
        {
            this.Headers.Add("usertokenauth", String.Empty);
            return this;
        }

        public MockGetRequest SetNoUsertokenauth()
        {
            return this;
        }
    }
}
