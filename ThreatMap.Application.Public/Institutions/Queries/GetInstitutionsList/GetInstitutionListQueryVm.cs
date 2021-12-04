using ThreatMap.Domain.Institutions.Entities;
using ThreatMap.Domain.Institutions.Enums;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Application.Public.Institutions.Queries.GetInstitutionsList;

public class GetInstitutionListQueryVm
{
    public List<InstitutioDto> Items { get; set; }
    public class InstitutioDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public InstitutionType Type { get; set; }

        public string SchoolUrl { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }

        public AddressDto Address { get; set; }
        public LocationDto Location { get; set; }
        
        public class AddressDto
        {
            public string Number { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string ZipCode { get; set; }
        }

        public class LocationDto
        {
            public double Lat { get; set; }
            public double Lng { get; set; }
        }
    }
}