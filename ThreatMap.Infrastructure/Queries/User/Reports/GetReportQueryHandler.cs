using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.User.Queries.GetReport;
using ThreatMap.Domain.Reports.Entities;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.Queries.User.Reports;

public class GetReportQueryHandler : IRequestHandler<GetReportQuery, GetReportQueryVm>
{
    private readonly DbSet<Report> _reports;

    public GetReportQueryHandler(ThreatMapDbContext dbContext)
    {
        _reports = dbContext.Reports;
    }

    public async Task<GetReportQueryVm> Handle(GetReportQuery request, CancellationToken cancellationToken)
        => await _reports.Where(a => a.Id == request.ReportId)
            .Select(a => new GetReportQueryVm()
            {
                Description = a.Description,
                Title = a.Title,
                ReportDate = a.ReportDate,
                UserId = a.UserId
            })
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);
}