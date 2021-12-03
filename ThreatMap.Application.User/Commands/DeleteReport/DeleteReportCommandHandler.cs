using MediatR;
using Microsoft.AspNetCore.Components;
using ThreatMap.Application.Shared.Common.Exceptions;
using ThreatMap.Application.Shared.Repositories;

namespace ThreatMap.Application.User.Commands.DeleteReport;

public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand>
{
    private readonly IReportRepository _reportRepository;

    public DeleteReportCommandHandler(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }
    public async Task<Unit> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
    {
        var report = await _reportRepository.GetAsync(request.ReportId) ??
                     throw new NotFoundException($"Report with requested id '{request.ReportId}' could not be found.");

        await _reportRepository.DeleteAsync(report);

        return Unit.Value;
    }
}