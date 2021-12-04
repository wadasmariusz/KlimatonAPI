using MediatR;

namespace ThreatMap.Application.Public.Reports.Queries.GetReport;

public class GetPublicReportQuery : IRequest<GetPublicReportQueryVm>
{
    public long ReportId { get; set; }
}