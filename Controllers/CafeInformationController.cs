using ChildFriendlyCafes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace littlesipper_api.Controllers;

[ApiController]
[Route("[controller]")]
public class CafeInformationController : ControllerBase
{
    private readonly AppDbContext _context;
    public CafeInformationController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CafeInformation>>> Get()
    {
        var getCafeList = await _context.Cafes.ToListAsync();
        if (getCafeList == null)
        {
            return NotFound($"Café with ID was not found.");
        }
        return await _context.Cafes.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<CafeInformation>> Get(Guid id)
    {
        var cafe = await _context.Cafes.FindAsync(id);
        if (cafe == null)
        {
            return NotFound();
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
