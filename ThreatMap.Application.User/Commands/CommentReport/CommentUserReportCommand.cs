using System.Security.AccessControl;
using MediatR;

namespace ThreatMap.Application.User.Commands.CommentReport;

public class CommentUserReportCommand : IRequest
{
    public long ReportId { get; set; }
    public string Content { get; set; }
}