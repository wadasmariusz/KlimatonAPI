using ThreatMap.Application.Shared.Common.DTO;

namespace ThreatMap.Application.Public.Populations.Queries.GetPopulationList;

public class GetPublicPopulationListQueryVm
{
    public List<PopulationListDto> Items { get; set; }
    
    public class PopulationListDto
    {
        public LocationDto Location { get; set; }
        public int PeopleCount { get; set; }
    }
}