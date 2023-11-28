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

    [HttpPatch]
    public async Task<ActionResult<GetCafesDto>> UpdatedCafe(UpdateCafeDto updateCafe)
    {
        var cafeToUpdate = await _cafeInformationService.UpdateCafe(updateCafe);

        if (cafeToUpdate == null)
        {
            return NotFound("Cafe not found or update failed");
        }
        return Ok(cafeToUpdate);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<GetCafesDto>>Delete(Guid id)
    {
        var cafeToDelete = await _cafeInformationService.DeleteCafe(id);
        if (cafeToDelete == null)
        {
            return NotFound("Cafe not found or delete failed");
        }
        return Ok(cafeToDelete);


    }
}
