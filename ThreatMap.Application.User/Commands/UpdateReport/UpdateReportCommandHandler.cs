using MediatR;
using ThreatMap.Application.Shared.Common.Exceptions;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Application.User.Commands.CreateReport;
using ThreatMap.Domain.Reports.Entities;

namespace ThreatMap.Application.User.Commands.UpdateReport;

public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand, long>
{
    private readonly IReportRepository _reportRepository;


    public UpdateReportCommandHandler(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task<long> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
    {
        var report = await _reportRepository.GetAsync(request.ReportId) ??
                     throw new NotFoundException($"Report with requested id '{request.ReportId}' could not be found.");

        report.Description = report.Description;
        report.Title = report.Title;

        await _reportRepository.UpdateAsync(report);

        return report.Id;
    }
}