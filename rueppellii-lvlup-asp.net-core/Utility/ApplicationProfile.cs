using rueppellii_lvlup_asp.net_core.Dtos;
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
                .ForMember(dto => dto.PitchedLVL, opt => opt.MapFrom(src => src.PitchedLevel))
                .ForMember(dto => dto.OldLVL, opt => opt.MapFrom(src => src.OldLevel))
                .ReverseMap();
            CreateMap<Pitch, PutPitchDto>()
                .ForMember(dto => dto.PitcherName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dto => dto.BadgeName, opt => opt.MapFrom(src => src.Badge.Name))
                .ForMember(dto => dto.NewStatus, opt => opt.MapFrom(src => src.PitchedLevel))
                .ForMember(dto => dto.NewMessage, opt => opt.MapFrom(src => src.PitchMessage))
                .ReverseMap();
            CreateMap<Badge, AddAdminDto>()
                .ReverseMap();
        }
    }
}
