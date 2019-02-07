using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.DTOs
{
    public class GetPitchesDto
    {
        public List<PitchDto> MyPitches { get; set; }
        public List<PitchDto> PitchesToReview { get; set; }

    }
}
