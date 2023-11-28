using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using littlesipper_api.Dtos.Cafes;
using littlesipper_api.Services.CafeinformationService;
using Microsoft.AspNetCore.Http.HttpResults;

namespace littlesipper_api.Services.CafeInformationService
{
    public class CafeInformationService : ICafeInformationService
    {
            private static List<CafeInformation> cafes = new List<CafeInformation>() {
        new CafeInformation {
            Id = Guid.NewGuid(),
            Name = "Espresso House Borås",
            StreetAddress = "Stora Brogatan 20",
            City = "Borås",
            PostalCode = "503 35",
            Latitude = "57.720600",
            Longitude = "12.939520",
            Amenities = Amenities.Changeroom | Amenities.Toys | Amenities.Playground
        },
        new CafeInformation {
            Id = Guid.NewGuid(),
            Name = "Espresso House Borås Station",
            StreetAddress = "Stationsgatan 16",
            City = "Borås",
            PostalCode = "503 38",
            Latitude = "57.720612",
            Longitude = "12.932280",
            Amenities = Amenities.Changeroom | Amenities.Books
        },
        new CafeInformation {
            Id = Guid.NewGuid(),
            Name = "Espresso House Knalleland",
            StreetAddress = "Lundbygatan 1",
            City = "Borås",
            PostalCode = "506 38",
            Latitude = "57.733410",
            Longitude = "12.937820",
            Amenities = Amenities.Changeroom | Amenities.Toys | Amenities.Garden
        },
    };
        private readonly IMapper _mapper;

        public CafeInformationService(IMapper mapper)
    {
            _mapper = mapper;
        }
        public async Task<List<GetCafesDto>> GetAllCafes()
        {
            return cafes.Select(cafe => _mapper.Map<GetCafesDto>(cafe)).ToList();
        }
        public async Task<GetCafesDto> GetSingleCafe(Guid id)
        {
            var cafe = cafes.FirstOrDefault(cafe => cafe.Id == id);
            return _mapper.Map<GetCafesDto>(cafe);
        }
        public async Task<List<GetCafesDto>> AddNewCafe(AddCafeDto newCafe)
        {
            CafeInformation cafe = _mapper.Map<CafeInformation>(newCafe);
            cafe.Id = Guid.NewGuid();
            cafes.Add(cafe);
            var addCafe = cafes.Select(cafe => _mapper.Map<GetCafesDto>(cafe)).ToList();
            return addCafe;
        }


    }
}