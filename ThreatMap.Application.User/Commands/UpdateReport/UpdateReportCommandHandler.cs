using MediatR;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Application.User.Commands.CreateReport;
using ThreatMap.Domain.Reports.Entities;

namespace ThreatMap.Application.User.Commands.UpdateReport;

public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand, long>
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
    public async Task<long> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
    {
        var report = new Report()
        {
            Title = request.Title,
            Description = request.Description,
            ReportDate = request.ReportDate,
        };

        await _reportRepository.UpdateAsync(report);
        
        return report.Id;
    }
}