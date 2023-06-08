﻿using AutoMapper;
using SkeppOHoj.Models;
using SkeppOHoj.Models.DTOs;

namespace SkeppOHoj
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserCreationDto, User>().ForAllMembers(
                opts 
                    => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<InsuranceCreationDto, Insurance>().ForAllMembers(
                opts
                    => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<InsuranceUpdateDto, Insurance>().ForAllMembers(
                opts
                    => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<InsuranceClaimCommentCreationDto, InsuranceClaimComment>().ForAllMembers(
                opts
                    => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<InsuranceClaimCreationDto, InsuranceClaim>().ForAllMembers(
                opts
                    => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<InsuranceTypeCreationDto, InsuranceType>().ForAllMembers(
                opts
                    => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ClaimStatusCreationDto, ClaimStatus>().ForAllMembers(
                opts
                    => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
