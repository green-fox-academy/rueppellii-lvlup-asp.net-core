using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.Dtos;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks
{
    class PutPitchRequestMockBody : PitchDto
    {
        public string SetCorrectBody()
        {
            this.BadgeName = "placeholder";
            this.PitchedLevel = 1;
            this.PitchMessage = "placeholder";
            return JsonConvert.SerializeObject(this);
        }
        public string SetEmptyStringsBody()
        {
            this.BadgeName = string.Empty;
            this.PitchedLevel = null;
            this.PitchMessage = string.Empty;
            return JsonConvert.SerializeObject(this);
        }
        public string SetMissingBody()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
