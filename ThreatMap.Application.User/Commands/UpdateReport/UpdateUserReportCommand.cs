using MediatR;

namespace ThreatMap.Application.User.Commands.UpdateReport;

public class UpdateUserReportCommand : IRequest<long>
{
    public long ReportId { get; set; }
    
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? ReportDate { get; set; }
}