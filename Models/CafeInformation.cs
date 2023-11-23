using littlesipper_api.Models;

namespace littlesipper_api;

public class CafeInformation
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string StreetAddress{ get; set; } = "";
    public string City { get; set; } = "";
    public string PostalCode { get; set; } = "";

    public string Latitude { get; set; } = "";
    public string Longitude { get; set; } = "";

    public Amenities Amenities { get; set; } = new Amenities(false, false, false, false, false);

}
