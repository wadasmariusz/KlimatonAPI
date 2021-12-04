using ThreatMap.Domain.Reports.Enums;

namespace ThreatMap.Application.User.Queries.Reports.GetReportList;

public class GetReportListQueryVm
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? ReportDate { get; set; }
    public long UserId { get; set; }
    public int CommentsCount { get; set; }
    public int RaisesCount { get; set; }

    public ReportStatus ReportStatus { get; set; }
    public string AdminComment { get; set; }
}