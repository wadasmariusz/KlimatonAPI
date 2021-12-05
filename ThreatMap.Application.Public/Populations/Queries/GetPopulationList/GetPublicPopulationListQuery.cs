using MediatR;

namespace ThreatMap.Application.Public.Populations.Queries.GetPopulationList;

public class GetPublicPopulationListQuery : IRequest<GetPublicPopulationListQueryVm>
{
    public string SearchPhrase { get; set; }
}