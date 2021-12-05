using ThreatMap.Application.Shared.Common.DTO;

namespace ThreatMap.Application.Admin.Population.Queries;

public class GetAdminPopulationListQueryVm
{
    public List<PopulationDTO> Populations { get; set; }
    public class PopulationDTO
    {
        public string Street { get; set; }
        public string HomeNumber { get; set; }
        public int PeopleCount { get; set; }
        public string Address { get; set; }

        public LocationDto Location  { get; set; }
    }
}