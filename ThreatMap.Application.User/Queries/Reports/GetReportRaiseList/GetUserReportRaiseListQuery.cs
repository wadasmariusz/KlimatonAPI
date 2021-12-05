using MediatR;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.User.Queries.Reports.GetReportRaiseList;

public class GetUserReportRaiseListQuery : PaginationRequest, IRequest<PaginatedList<GetUserReportRaiseListQueryVm>>
{
    public long ReportId { get; set; }
}