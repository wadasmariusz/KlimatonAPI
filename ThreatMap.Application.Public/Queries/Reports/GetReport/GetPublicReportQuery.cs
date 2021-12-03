using MediatR;

namespace ThreatMap.Application.Public.Queries.Reports.GetReport;

public class GetPublicReportQuery : IRequest<GetPublicReportQueryVm>
{
    public long ReportId { get; set; }
}