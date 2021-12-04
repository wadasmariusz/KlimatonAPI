using MediatR;

namespace ThreatMap.Application.User.Queries.Reports.GetReportCommentList;

public class GetReportCommentListQueryVm 
{
    public string Content { get; set; }
    public ReportCommentListUserDto User { get; set; }
    public DateTimeOffset CommentDate { get; set; }

}