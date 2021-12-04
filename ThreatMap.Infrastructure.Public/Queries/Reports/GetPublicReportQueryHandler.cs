using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Public.Reports.Queries.GetReport;
using ThreatMap.Application.Shared.Common.Exceptions;
using ThreatMap.Domain.Reports.Entities;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.Public.Queries.Reports;

public class GetPublicReportQueryHandler : IRequestHandler<GetPublicReportQuery, GetPublicReportQueryVm>
{
    private readonly DbSet<Report> _reports;

    public GetPublicReportQueryHandler(ThreatMapDbContext context)
    {
        _reports = context.Reports;
    }

    public async Task<GetPublicReportQueryVm> Handle(GetPublicReportQuery request, CancellationToken cancellationToken)
    {
        var report =
            await _reports.FirstOrDefaultAsync(a => a.Id == request.ReportId, cancellationToken: cancellationToken) ??
            throw new NotFoundException($"Report with requested id:{request.ReportId} could not be found");

        return new GetPublicReportQueryVm()
        {
            Description = report.Description,
            Title = report.Title,
            ReportDate = report.ReportDate,
            UserId = report.UserId
        };
    }
}