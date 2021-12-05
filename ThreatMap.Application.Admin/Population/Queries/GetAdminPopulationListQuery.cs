using MediatR;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.Admin.Population.Queries;

public class GetAdminPopulationListQuery : PaginationRequest, IRequest<PaginatedList<GetAdminPopulationListQueryVm>>
{
    public string SearchPhrase { get; set; }
}
