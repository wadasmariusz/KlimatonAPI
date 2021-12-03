using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.User.Queries.GetReportList;
using ThreatMap.Domain.Reports.Entities;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.Queries.User.Reports;

public class GetReportListQueryHandler : IRequestHandler<GetReportListQuery, GetReportListQueryVm>
{
    private readonly DbSet<Report> _reports;
    public GetReportListQueryHandler(ThreatMapDbContext context)
    {
        _reports = context.Reports;
    }
    
    public async Task<GetReportListQueryVm> Handle(GetReportListQuery request, CancellationToken cancellationToken)
    {
        _reports.Where() // tutaj całe zapytanie zajebiste z filtrami z requesta.

        return new GetReportListQueryVm();
    }
}