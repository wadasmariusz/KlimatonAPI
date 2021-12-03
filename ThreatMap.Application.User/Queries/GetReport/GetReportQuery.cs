using MediatR;

namespace ThreatMap.Application.User.Queries.GetReport;

public class GetReportQuery : IRequest<GetReportQueryVm>
{
    public long ReportId { get; set; }
}