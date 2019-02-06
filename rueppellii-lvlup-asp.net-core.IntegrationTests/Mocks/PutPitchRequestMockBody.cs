using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks
{
    class PutPitchRequestMockBody : PutPitchDto
    {
        public string SetCorrectBody()
        {
            this.PitcherName = "placeholder";
            this.BadgeName = "placeholder";
            this.NewStatus = 1;
            this.NewMessage = "placeholder";
            return JsonConvert.SerializeObject(this);
        }
        public string SetEmptyStringsBody()
        {
            this.PitcherName = string.Empty;
            this.BadgeName = string.Empty;
            this.NewStatus = null;
            this.NewMessage = string.Empty;
            return JsonConvert.SerializeObject(this);
        }
        public string SetMissingBody()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
