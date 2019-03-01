using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks
{
    public class BadgeDtoMock : BadgeDto
    {
        public string SetCorrectBody()
        {
            this.Version = "2.3";
            this.Name = "Badge inserter";
            this.Tag = "general";
            this.Levels = new List<Level>() { new Level
                {
                    BadgeLevel = 1,
                    Description = "abc",
                }};
            return JsonConvert.SerializeObject(this);
        }

        public string SetMissingBody()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string SetEmptyStringsBody()
        {
            this.Version = string.Empty;
            this.Name = string.Empty;
            this.Tag = string.Empty;
            this.Levels = null;
            return JsonConvert.SerializeObject(this);
        }
    }
}
