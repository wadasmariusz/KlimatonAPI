using MediatR;

namespace ThreatMap.Application.User.Commands.DeleteReport;

public class DeleteReportCommand : IRequest
{
    public long ReportId { get; set; }
}