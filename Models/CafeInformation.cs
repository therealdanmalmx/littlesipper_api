using System.ComponentModel.DataAnnotations;
using littlesipper_api.Models;

namespace littlesipper_api;

public class CafeInformation
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public string StreetAddress{ get; set; } = "";
    public string City { get; set; } = "";
    public string PostalCode { get; set; } = "";

    public string Latitude { get; set; } = "";
    public string Longitude { get; set; } = "";

    [EnumDataType(typeof(Amenities))]
    public Amenities Amenities { get; set; } = Amenities.None;

}
