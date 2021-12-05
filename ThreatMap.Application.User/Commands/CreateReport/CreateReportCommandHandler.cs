using MediatR;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Domain.Reports.Entities;
using ThreatMap.Domain.Reports.Enums;

namespace ThreatMap.Application.User.Commands.CreateReport;

public class CreateReportCommandHandler : IRequestHandler<CreateUserReportCommand, long>
{
    private readonly IReportRepository _reportRepository;
    private readonly IDateService _dateService;
    private readonly ICurrentUserService _userService;

    public CreateReportCommandHandler(IReportRepository reportRepository, IDateService dateService, ICurrentUserService userService)
    {
        _reportRepository = reportRepository;
        _dateService = dateService;
        _userService = userService;
    }
    public async Task<long> Handle(CreateUserReportCommand request, CancellationToken cancellationToken)
    {
        
        //TODO: MockedData
        var currentUserId = _userService.UserId;
        if (currentUserId == null || currentUserId == 0)
            currentUserId = 5;
        
        var report = new Report()
        {
            Title = request.Title,
            Description = request.Description,
            ReportDate = _dateService.CurrentDate(),
            ReportStatus = ReportStatus.New,
            UserId = currentUserId
        };

        await _reportRepository.CreateAsync(report);
        
        return report.Id;
    }
}