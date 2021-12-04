using MediatR;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.Public.Reports.Queries.GetReportList;

public class GetPublicReportListQuery :PaginationRequest, IRequest<PaginatedList<GetPublicReportListQueryVm>>
{
    public string SearchPhrase { get; set; }
}