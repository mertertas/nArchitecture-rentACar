﻿using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.someFeature.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreatedBrandEntityDto>().ReverseMap();
            CreateMap<Brand, CreateBrandEntityCommand>().ReverseMap();
        }
    }
}
