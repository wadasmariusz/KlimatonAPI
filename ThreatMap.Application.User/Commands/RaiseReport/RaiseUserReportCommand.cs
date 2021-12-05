using MediatR;
using ThreatMap.Domain.ReportRaises.Enums;

namespace ThreatMap.Application.User.Commands.RaiseReport;

public class RaiseUserReportCommand : IRequest
{
    public long ReportId { get; set; }
    
    public RaiseAction RaiseAction { get; set; }
}