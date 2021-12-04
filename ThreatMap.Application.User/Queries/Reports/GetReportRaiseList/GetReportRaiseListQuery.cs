using MediatR;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.User.Queries.Reports.GetReportRaiseList;

public class GetReportRaiseListQuery : PaginationRequest, IRequest<PaginatedList<GetReportRaiseListQueryVm>>
{
    public long ReportId { get; set; }
}