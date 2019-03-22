using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class GetPitchesDto
    {
        public List<GetPitchDto> MyPitches { get; set; }
        public List<GetPitchDto> PitchesToReview { get; set; }
    }
}