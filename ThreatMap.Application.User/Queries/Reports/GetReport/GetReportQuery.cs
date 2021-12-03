using MediatR;

namespace ThreatMap.Application.User.Queries.Reports.GetReport;

public class GetReportQuery : IRequest<GetReportQueryVm>
{
    public long ReportId { get; set; }
}