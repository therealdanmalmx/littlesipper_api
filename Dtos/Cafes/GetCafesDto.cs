using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace littlesipper_api.Dtos.Cafes
{
    public class GetCafesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string StreetAddress{ get; set; } = "";
        public string City { get; set; } = "";
        public string PostalCode { get; set; } = "";

        public string Latitude { get; set; } = "";
        public string Longitude { get; set; } = "";

        public Amenities Amenities { get; set; }
    }
}