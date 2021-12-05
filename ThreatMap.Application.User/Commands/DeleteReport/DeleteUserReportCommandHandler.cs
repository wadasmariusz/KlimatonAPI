using MediatR;
using Microsoft.AspNetCore.Components;
using ThreatMap.Application.Shared.Common.Exceptions;
using ThreatMap.Application.Shared.Repositories;

namespace ThreatMap.Application.User.Commands.DeleteReport;

public class DeleteUserReportCommandHandler : IRequestHandler<DeleteUserReportCommand>
{
    private readonly IReportRepository _reportRepository;

    public DeleteUserReportCommandHandler(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }
    public async Task<Unit> Handle(DeleteUserReportCommand request, CancellationToken cancellationToken)
    {
        var report = await _reportRepository.GetAsync(request.ReportId) ??
                     throw new NotFoundException($"Report with requested id '{request.ReportId}' could not be found.");

        await _reportRepository.DeleteAsync(report);

        return Unit.Value;
    }
}