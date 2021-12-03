using MediatR;

namespace ThreatMap.Application.User.Commands.UpdateReport;

public class UpdateReportCommand : IRequest
{
    public long reportId { get; set; }
    // Tutaj mają być dane zgłoszenia
}