using MediatR;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.User.Queries.Reports.GetReportList;

public class GetUserReportListQuery : PaginationRequest,IRequest<PaginatedList<GetUserReportListQueryVm>>
{
    public string SearchPhrase { get; set; }
}