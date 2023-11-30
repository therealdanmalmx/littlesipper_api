using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using littlesipper_api.Data;
using littlesipper_api.Dtos.Cafes;
using littlesipper_api.Services.CafeinformationService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace littlesipper_api.Services.CafeInformationService
{
    public class CafeInformationService : ICafeInformationService
    {
        private static List<CafeInformation> cafes = new List<CafeInformation>() {
        };
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CafeInformationService(IMapper mapper, DataContext dataContext)
    {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public async Task<List<GetCafesDto>> GetAllCafes()
        {
            var dbCafes = await _dataContext.Cafes.ToListAsync();
            return dbCafes.Select(cafe => _mapper.Map<GetCafesDto>(cafe)).ToList();
        }
        public async Task<GetCafesDto> GetSingleCafe(Guid id)
        {
            var dbCafes = await _dataContext.Cafes.FirstOrDefaultAsync(cafe => cafe.Id == id);
            return _mapper.Map<GetCafesDto>(dbCafes);
        }
        public async Task<List<GetCafesDto>> AddNewCafe(AddCafeDto newCafe)
        {
            CafeInformation cafe = _mapper.Map<CafeInformation>(newCafe);
            cafe.Id = Guid.NewGuid();
            _dataContext.Cafes.Add(cafe);
            await _dataContext.SaveChangesAsync();
            var addCafe = await _dataContext.Cafes.Select(cafe => _mapper.Map<GetCafesDto>(cafe)).ToListAsync();
            return addCafe;
        }

        public async Task<GetCafesDto> UpdateCafe(UpdateCafeDto updateCafe)
        {
            CafeInformation? cafe;

            try
            {
                cafe = await _dataContext.Cafes.FirstOrDefaultAsync(cafe => cafe.Id == updateCafe.Id);

                if (cafe == null)
                {
                    throw new KeyNotFoundException("Cafe not found.");
                }
                else
                {
                    _mapper.Map(updateCafe, cafe);
                    await _dataContext.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Failed to update product.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the product.", ex);
            }

            return _mapper.Map<GetCafesDto>(cafe);
        }

        public async Task<List<GetCafesDto>> DeleteCafe(Guid id)
        {
            try
            {
                CafeInformation cafe = await _dataContext.Cafes.FirstAsync(cafe => cafe.Id == id);

                if (cafe == null)
                {
                    throw new KeyNotFoundException("Cafe not found.");
                }

                _dataContext.Cafes.Remove(cafe);
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Failed to delete product.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the product.", ex);
            }
            return _dataContext.Cafes.Select(cafe => _mapper.Map<GetCafesDto>(cafe)).ToList();
        }
    }
}