﻿using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Utility
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Pitch, PitchDto>()
                .ReverseMap();
            CreateMap<Pitch, PutPitchDto>()
                .ForMember(dto => dto.PitcherName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dto => dto.BadgeName, opt => opt.MapFrom(src => src.Badge.BadgeName))
                .ForMember(dto => dto.NewStatus, opt => opt.MapFrom(src => src.PitchedLevel))
                .ForMember(dto => dto.NewMessage, opt => opt.MapFrom(src => src.PitchMessage))
                .ReverseMap();
        }
    }
}
