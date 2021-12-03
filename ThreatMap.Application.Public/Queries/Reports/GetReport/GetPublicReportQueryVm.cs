namespace ThreatMap.Application.Public.Queries.Reports.GetReport;

public class GetPublicReportQueryVm
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? ReportDate { get; set; }
    public long UserId { get; set; }
}