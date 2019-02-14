using rueppellii_lvlup_asp.net_core.DTOs.BaseDtos;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class GetPitchesDto : BasePitchDto
    {
        public List<PitchDto> MyPitches { get; set; }
        public List<PitchDto> PitchesToReview { get; set; }
    }
}