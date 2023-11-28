using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using littlesipper_api.Dtos.Cafes;

namespace littlesipper_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CafeInformation, GetCafesDto>();
            CreateMap<AddCafeDto, CafeInformation>();
            CreateMap<UpdateCafeDto, CafeInformation>();
        }
    }
}