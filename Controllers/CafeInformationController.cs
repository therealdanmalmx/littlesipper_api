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
        // var getCafeList = _context.Cafes.ToList();
        // if (getCafeList == null)
        // {
        //     return NotFound("No café were found.");
        // }
        return Ok(cafes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CafeInformation>> Get(Guid id)
    {
        var cafe = await _context.Cafes.FindAsync(id);
        if (cafe == null)
        {
            return NotFound($"No café with id {id} was found.");
        }
        return cafe;
    }

    [HttpPost]
    public async Task<ActionResult<CafeInformation>> Post(CafeInformation cafe)
    {
        _context.Cafes.Add(cafe);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = cafe.Id }, cafe);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, CafeInformation cafe)
    {
        if (id != cafe.Id)
        {
            return BadRequest();
        }

        _context.Entry(cafe).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Cafes.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var cafe = await _context.Cafes.FindAsync(id);
        if (cafe == null)
        {
            return NotFound();
        }

        _context.Cafes.Remove(cafe);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
