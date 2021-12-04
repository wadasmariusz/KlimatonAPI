using ThreatMap.Domain.Reports.Enums;

namespace ThreatMap.Application.Public.Reports.Queries.GetReportList;

public class GetPublicReportListQueryVm
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? ReportDate { get; set; }
    public long UserId { get; set; }

    public ReportType ReportType { get; set; }
    public ReportStatus ReportStatus { get; set; }
    public string AdminComment { get; set; }

}