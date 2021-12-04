using System.Security.AccessControl;
using MediatR;

namespace ThreatMap.Application.User.Commands.CommentReport;

public class CommentReportCommand : IRequest
{
    public long ReportId { get; set; }
    public string Content { get; set; }
}