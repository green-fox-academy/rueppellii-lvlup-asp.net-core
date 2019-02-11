using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class GetPitchesDto
    {
        public List<PitchDto> MyPitches { get; set; }
        public List<PitchDto> PitchesToReview { get; set; }
    }
}