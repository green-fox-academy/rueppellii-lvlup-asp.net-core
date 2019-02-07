using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks
{
    public class AddAdminPostRequestMockBody : AddAdminDto
    {
        public string SetCorrectBody()
        {
            this.Version = 2.3;
            this.Name = "Badge inserter";
            this.Tag = "general";
            this.Levels = new[]{ 2, 7, 89, 1515 };
            return JsonConvert.SerializeObject(this);
        }
        public string SetMissingBody()
        {
            return JsonConvert.SerializeObject(this);
        }
        public string SetEmptyStringsBody()
        {
            this.Version = 2.3;
            this.Name = string.Empty;
            this.Tag = string.Empty;
            this.Levels = new int[0];
            return JsonConvert.SerializeObject(this);
        }
    }
}
