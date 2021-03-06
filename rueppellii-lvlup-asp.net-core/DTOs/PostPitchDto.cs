﻿using rueppellii_lvlup_asp.net_core.DTOs.BaseDtos;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class PostPitchDto : BasePitchDto
    {
        public string BadgeName { get; set; }
        public int? OldLVL { get; set; }
        public int? PitchedLVL { get; set; }
        public string PitchMessage { get; set; }
        public List<ReviewerDto> Holders { get; set; }
    }
}
