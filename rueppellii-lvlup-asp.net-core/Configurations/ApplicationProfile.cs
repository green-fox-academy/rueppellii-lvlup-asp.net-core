﻿using rueppellii_lvlup_asp.net_core.Dtos;
using rueppellii_lvlup_asp.net_core.Models;
using System.Linq;
using System.Security.Claims;

namespace rueppellii_lvlup_asp.net_core.Configurations
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Pitch, GetPitchDto>()
                .ForMember(dto => dto.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dto => dto.BadgeName, opt => opt.MapFrom(src => src.Badge.Name))
                .ForMember(dto => dto.Reviews, opt => opt.MapFrom(src => src.Reviews))
                .ForMember(dto => dto.PitchedLevel, opt => opt.MapFrom(src => src.PitchedLevel))
                .ForMember(dto => dto.BadgeName, opt => opt.MapFrom(src => src.Badge.Name))
                .ReverseMap();
            CreateMap<Pitch, PitchDto>()
                .ForMember(dto => dto.BadgeName, opt => opt.MapFrom(src => src.Badge.Name))
                .ForMember(dto => dto.PitchedLevel, opt => opt.MapFrom(src => src.PitchedLevel))
                .ForMember(dto => dto.PitchMessage, opt => opt.MapFrom(src => src.PitchMessage))
                .ReverseMap();
            CreateMap<Badge, BadgeDto>()
                .ReverseMap();
            CreateMap<Level, LevelDto>()
                .ForMember(dto => dto.Level, opt => opt.MapFrom(src => src.BadgeLevel))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Badge.Name))
                .ReverseMap();
            CreateMap<Review, ReviewDto>()
                .ForMember(dto => dto.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dto => dto.PitchStatus, opt => opt.MapFrom(src => src.PitchStatus))
                .ReverseMap();
            CreateMap<ClaimsPrincipal, User>()
                .ForMember(user => user.Name, opt => opt.MapFrom(principal =>
                    principal.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value))
                .ForMember(user => user.Email, opt => opt.MapFrom(principal =>
                    principal.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value))
                .ForMember(user => user.Pic, opt => opt.MapFrom(principal =>
                    principal.Claims.FirstOrDefault(claim => claim.Type == "profilePic").Value))
                .ForMember(user => user.Surname, opt => opt.MapFrom(principal =>
                    principal.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname").Value))
                .ForMember(user => user.GivenName, opt => opt.MapFrom(principal =>
                    principal.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname").Value));
        }
    }
}