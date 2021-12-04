using MediatR;
using ThreatMap.Application.Shared.Common.Exceptions;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Domain.ReportRaises.Entities;

namespace ThreatMap.Application.User.Commands.RaiseReport;

public class RaiseReportCommandHandler : IRequestHandler<RaiseReportCommand>
{
    private readonly IReportRepository _reportRepository;
    private readonly ICurrentUserService _currentUserService;

    public RaiseReportCommandHandler(IReportRepository reportRepository, ICurrentUserService currentUserService)
    {
        _reportRepository = reportRepository;
        _currentUserService = currentUserService;
    }

    public async Task<Unit> Handle(RaiseReportCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _currentUserService.UserId;
        var report =await _reportRepository.GetAsync(request.ReportId) ??
                     throw new NotFoundException($"Report with requested id: '{request.ReportId}' could not be found.");

        var reportRaise = new ReportRaise()
        {
            ReportId = report.Id,
            UserId = currentUserId,
            RaiseAction = request.RaiseAction
        };
        
        report.ReportRaises.Add(reportRaise);
        await _reportRepository.UpdateAsync(report);
        
        return Unit.Value;
    }
}