using AutoMapper;
using CarRental.Domain.DTOs.Brand;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Infrastructure.Profiles
{
    public class MapperProfiles: Profile
    {
        public MapperProfiles()
        {
            CreateMap<CreateBrandDto, Brand>();
        }
    }
}
