using MediatR;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Domain.Comments.Entities;
using ThreatMap.Domain.Common.Enums;
using ThreatMap.Domain.ReportRaises.Entities;
using ThreatMap.Domain.Reports.Entities;
using ThreatMap.Domain.Reports.Enums;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Application.Admin.Reports.Commands;

public class ImportReportCommandHandler : IRequestHandler<ImportReportCommand, long>
{
    private readonly IReportRepository _reportRepository;
    private readonly IDateService _dateService;
    private readonly ICurrentUserService _userService;

    public ImportReportCommandHandler(IReportRepository reportRepository, IDateService dateService,
        ICurrentUserService userService)
    {
        _reportRepository = reportRepository;
        _dateService = dateService;
        _userService = userService;
    }

    public async Task<long> Handle(ImportReportCommand req, CancellationToken cancellationToken)
    {
        Random rnd = new Random();
        foreach (var item in req.Features)
        {
            var report = new Report
            {
                Title = $"Podtopienie {item.properties.adres}",
                Description = item.properties.adres,
                ReportType = ReportType.Inundation,
                ReportStatus = ReportStatus.Finished,
                Location = Location.Create(item.geometry.coordinates[0], item.geometry.coordinates[1]),
            };
            var reportDate = new DateTime(item.properties.rok, item.properties.miesiac ?? 6, 1);
            report.ReportDate = DateTime.SpecifyKind(reportDate, DateTimeKind.Utc);
            report.UserId = rnd.Next(2, 5);
            await _reportRepository.CreateAsync(report);
        }

        return 1;
    }
}