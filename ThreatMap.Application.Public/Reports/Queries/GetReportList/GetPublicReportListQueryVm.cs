namespace ThreatMap.Application.Public.Reports.Queries.GetReportList;

public class GetPublicReportListQueryVm
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? ReportDate { get; set; }
    public long UserId { get; set; }
}