using rueppellii_lvlup_asp.net_core.DTOs.BaseDtos;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class GetPitchesDto : BasePitchDto
    {
        public List<GetPitchDto> MyPitches { get; set; }
        public List<GetPitchDto> PitchesToReview { get; set; }
    }
}