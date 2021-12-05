using MediatR;
using ThreatMap.Application.Shared.Common.Exceptions;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Domain.Comments.Entities;

namespace ThreatMap.Application.User.Commands.CommentReport;

public class CommentReportCommandHandler : IRequestHandler<CommentUserReportCommand>
{
    private readonly ICurrentUserService _userService;
    private readonly IReportRepository _reportRepository;

    public CommentReportCommandHandler(ICurrentUserService userService, IReportRepository reportRepository)
    {
        _userService = userService;
        _reportRepository = reportRepository;
    }

    public async Task<Unit> Handle(CommentUserReportCommand request, CancellationToken cancellationToken)
    {
        var report = await _reportRepository.GetAsync(request.ReportId) ??
                     throw new NotFoundException($"Report with requested id: '{request.ReportId}' could not be found.");


        var currentUserId = _userService.UserId;
        var comment = new Comment()
        {
            Content = request.Content,
            UserId = currentUserId,
            ReportId = report.Id
        };
        
        report.Comments.Add(comment);

        await _reportRepository.UpdateAsync(report);
        
        return Unit.Value;
    }
}