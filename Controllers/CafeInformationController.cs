using Microsoft.AspNetCore.Mvc;

namespace littlesipper_api.Controllers;

[ApiController]
[Route("[controller]")]
public class CafeInformationController : ControllerBase
{
    private readonly ILogger<CafeInformationController> _logger;

    public CafeInformationController(ILogger<CafeInformationController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CafeInformation>> Get()
    {
        var cafes = new List<CafeInformation>
        {
            new CafeInformation
            {
                Id = Guid.NewGuid(),
                Name = "Espresso House Knalleland",
                StreetAddress = "Lundbygatan 1",
                City = "Borås",
                PostalCode = "503 32",
                Latitude = "57.73296",
                Longitude = "12.93726",
            },
            new CafeInformation
            {
                Id = Guid.NewGuid(),
                Name = "Espresso House Borås Station",
                StreetAddress = "Stationsgatan 16",
                City = "Borås",
                PostalCode = "503 38",
                Latitude = "57.72057",
                Longitude = "12.93258",
            },

            new CafeInformation
            {
                Id = Guid.NewGuid(),
                Name = "Café Viskan",
                StreetAddress = "Södra Strandgatan 6",
                City = "Borås",
                PostalCode = "503 35",
                Latitude = "57.71984",
                Longitude = "12.94025",
            },
        };

        return Ok(cafes);
    }


    [HttpGet("{id}")]
    public ActionResult<CafeInformation> Get(string id, CafeInformation cafe)
    {
        var singleCafe = cafe.Where(cafe => cafe.Id == id);

        return Ok(singleCafe);
    }

    // [HttpPost]
    // public ActionResult<CafeInformation> Post(CafeInformation cafe)
    // {
    //     cafe = new CafeInformation
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "Espresso House",
    //         StreetAddress = "Kungsgatan 1",
    //         City = "Borås",
    //         PostalCode = "503 32",
    //         Latitude = "57.73296",
    //         Longitude = "12.93726",

    //     };

    //     return Ok(cafe);
    // }
}
