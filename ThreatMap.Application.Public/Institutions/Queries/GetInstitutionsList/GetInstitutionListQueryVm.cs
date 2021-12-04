using ThreatMap.Application.Shared.Common.DTO;
using ThreatMap.Domain.Institutions.Enums;

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
    }
}