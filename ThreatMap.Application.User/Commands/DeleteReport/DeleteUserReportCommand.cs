using MediatR;

namespace ThreatMap.Application.User.Commands.DeleteReport;

public class DeleteUserReportCommand : IRequest
{
    public long ReportId { get; set; }
}