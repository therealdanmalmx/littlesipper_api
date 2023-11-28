using ChildFriendlyCafes.Models;
using littlesipper_api.Dtos.Cafes;
using littlesipper_api.Services.CafeinformationService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace littlesipper_api.Controllers;

[ApiController]
[Route("[controller]")]
public class CafeInformationController : ControllerBase
{
    private readonly ICafeInformationService _cafeInformationService;

    public CafeInformationController(ICafeInformationService cafeInformationService)
    {
        _cafeInformationService = cafeInformationService;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetCafesDto>>> Get()
    {
        return Ok(await _cafeInformationService.GetAllCafes());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetCafesDto>> GetSingle(Guid id)
    {
        return Ok(await _cafeInformationService.GetSingleCafe(id));
    }

    [HttpPost]
    public async Task<ActionResult<List<GetCafesDto>>> AddCafe(AddCafeDto newCafe)
    {
        return Ok(await _cafeInformationService.AddNewCafe(newCafe));
    }

    // [HttpPut("{id}")]
    // public ActionResult Put(Guid id)
    // {

    //     var cafe = _cafeInformationService.FirstOrDefault(cafe => cafe.Id == id);

    //     if (_cafeInformationService == null)
    //     {
    //         return NotFound($"No café with id {id} was found.");
    //     }

    //     var updatedCafe  =
    //         cafe.Name = cafe.Name;
    //         cafe.StreetAddress = cafe.StreetAddress;
    //         cafe.City = cafe.City;
    //         cafe.PostalCode = cafe.PostalCode;
    //         cafe.Latitude = cafe.Latitude;
    //         cafe.Longitude = cafe.Longitude;
    //         cafe.Amenities = cafe.Amenities;

    //     return Ok(cafe);
    // }

    // [HttpDelete("{id}")]
    // public ActionResult Delete(Guid id)
    // {
    //     var cafe = _cafeInformationService.FirstOrDefault(cafe => cafe.Id == id);

    //     return Ok(_cafeInformationService.Remove(cafe));

    // }
}
