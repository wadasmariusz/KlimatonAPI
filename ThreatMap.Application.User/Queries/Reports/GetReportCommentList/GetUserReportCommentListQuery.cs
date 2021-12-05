using MediatR;
using ThreatMap.Shared.Models;

namespace ThreatMap.Application.User.Queries.Reports.GetReportCommentList;

public class GetUserReportCommentListQuery : PaginationRequest, IRequest<PaginatedList<GetUserReportCommentListQueryVm>>
{
    public long ReportId { get; set; }
}