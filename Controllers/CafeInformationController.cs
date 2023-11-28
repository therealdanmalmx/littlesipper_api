using ChildFriendlyCafes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace littlesipper_api.Controllers;

[ApiController]
[Route("[controller]")]
public class CafeInformationController : ControllerBase
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

    private readonly AppDbContext _context;
    public CafeInformationController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<CafeInformation>> Get()
    {
        return Ok(cafes);
    }

    [HttpGet("{id}")]
    public ActionResult<CafeInformation> GetSingle(Guid id)
    {
        var cafe = cafes.FirstOrDefault(cafe => cafe.Id == id);
        return Ok(cafe);
    }

    [HttpPost]
    public ActionResult<List<CafeInformation>> AddCafe(CafeInformation cafe)
    {
        cafes.Add(cafe);
        return Ok(cafes);
    }

    [HttpPut("{id}")]
    public ActionResult Put(Guid id)
    {

        var cafe = cafes.FirstOrDefault(cafe => cafe.Id == id);

        if (cafe == null)
        {
            return NotFound($"No café with id {id} was found.");
        }

        var updatedCafe  =
            cafe.Name = cafe.Name;
            cafe.StreetAddress = cafe.StreetAddress;
            cafe.City = cafe.City;
            cafe.PostalCode = cafe.PostalCode;
            cafe.Latitude = cafe.Latitude;
            cafe.Longitude = cafe.Longitude;
            cafe.Amenities = cafe.Amenities;

        return Ok(cafe);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        var cafe = cafes.FirstOrDefault(cafe => cafe.Id == id);

        if (cafe == null)
        {
            return NotFound($"No café with id {id} was found.");
        }

            cafes.Remove(cafe);

            return Ok();

    }
}
