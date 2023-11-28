using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using littlesipper_api.Dtos.Cafes;

namespace littlesipper_api.Services.CafeinformationService
{
    public interface ICafeInformationService
    {
        Task<List<GetCafesDto>> GetAllCafes();
        Task<GetCafesDto> GetSingleCafe(Guid id);
        Task<List<GetCafesDto>> AddNewCafe(AddCafeDto newCafe);
    }
}