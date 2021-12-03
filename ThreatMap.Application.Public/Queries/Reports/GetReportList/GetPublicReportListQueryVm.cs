namespace ThreatMap.Application.Public.Queries.Reports.GetReportList;

public class GetPublicReportListQueryVm
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? ReportDate { get; set; }
    public long UserId { get; set; }
}