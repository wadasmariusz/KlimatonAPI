using MediatR;

namespace ThreatMap.Application.User.Queries.Reports.GetReport;

public class GetUserReportQuery : IRequest<GetUserReportQueryVm>
{
    public long ReportId { get; set; }
}