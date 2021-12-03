using MediatR;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Application.User.Commands.CreateReport;
using ThreatMap.Domain.Reports.Entities;

namespace ThreatMap.Application.User.Commands.UpdateReport;

public class UpdateReportCommandHandler : IRequestHandler<CreateReportCommand, long>
{
    private readonly IReportRepository _reportRepository;
    private readonly IDateService _dateService;
    private readonly ICurrentUserService _userService;

    public UpdateReportCommandHandler(IReportRepository reportRepository, IDateService dateService, ICurrentUserService userService)
    {
        _reportRepository = reportRepository;
        _dateService = dateService;
        _userService = userService;
    }
    public async Task<long> Handle(CreateReportCommand request, CancellationToken cancellationToken)
    {
        var report = new Report()
        {
            Description = $"Zalało mi dom help fast jaknajszybciej",
            ReportDate = _dateService.CurrentOffsetDate(),
        };

        await _reportRepository.CreateAsync(report);
        
        return report.Id;
    }
}