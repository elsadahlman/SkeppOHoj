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
        }
    }
}
