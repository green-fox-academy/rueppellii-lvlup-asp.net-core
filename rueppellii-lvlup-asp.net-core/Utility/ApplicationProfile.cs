﻿using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;

namespace rueppellii_lvlup_asp.net_core.Utility
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Pitch, PitchDto>()
                .ForMember(dto => dto.Username, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dto => dto.BadgeName, opt => opt.MapFrom(src => src.Badge.Name))
                .ForMember(dto => dto.Holders, opt => opt.MapFrom(src => src.Reviewers))
                .ReverseMap();
            CreateMap<Pitch, PostPitchDto>()
                .ForMember(dto => dto.PitchedLVL, opt => opt.MapFrom(src => src.PitchedLevel))
                .ForMember(dto => dto.OldLVL, opt => opt.MapFrom(src => src.OldLevel))
                .ForMember(dto => dto.BadgeName, opt => opt.MapFrom(src => src.Badge.Name))
                .ReverseMap();
            CreateMap<Pitch, PutPitchDto>()
                .ForMember(dto => dto.PitcherName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dto => dto.BadgeName, opt => opt.MapFrom(src => src.Badge.Name))
                .ForMember(dto => dto.NewStatus, opt => opt.MapFrom(src => src.PitchedLevel))
                .ForMember(dto => dto.NewMessage, opt => opt.MapFrom(src => src.PitchMessage))
                .ReverseMap();
            CreateMap<Badge, BadgeDto>()
                .ReverseMap();
            CreateMap<Level, LevelDto>()
                .ForMember(dto => dto.Level, opt => opt.MapFrom(src => src.BadgeLevel))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Badge.Name))
                .ReverseMap();
            CreateMap<Review, ReviewDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.User.Name))
                .ReverseMap();
            CreateMap<Review, ReviewerDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.User.Name));
        }
    }
}
