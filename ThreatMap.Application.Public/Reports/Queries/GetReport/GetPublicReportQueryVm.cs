using ThreatMap.Domain.Reports.Enums;

namespace ThreatMap.Application.Public.Reports.Queries.GetReport;

public class GetPublicReportQueryVm
{
    public string Title { get; set; }
    public string Description { get; set; }

    public DateTimeOffset? ReportDate { get; set; }
    public long UserId { get; set; }


    public ReportType ReportType { get; set; }
    public ReportStatus ReportStatus { get; set; }
    public string AdminComment { get; set; }
}