using MediatR;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.User.Queries.Reports.GetReportCommentList;

public class GetReportCommentListQuery :PaginationRequest, IRequest<PaginatedList<GetReportCommentListQueryVm>>
{
    public long ReportId { get; set; }
}