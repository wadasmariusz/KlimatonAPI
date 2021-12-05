using MediatR;
using ThreatMap.Domain.Reports.Enums;

namespace ThreatMap.Application.User.Commands.CreateReport;

public class CreateUserReportCommand : IRequest<long>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ReportType Type { get; set; }
}