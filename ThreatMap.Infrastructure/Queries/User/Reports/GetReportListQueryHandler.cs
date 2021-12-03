using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.User.Queries.GetReportList;
using ThreatMap.Domain.Reports.Entities;
using ThreatMap.Persistence;
using ThreatMap.Shared.Extensions;
using ThreatMap.Shared.Models;

namespace ThreatMap.Infrastructure.Queries.User.Reports;

public class GetReportListQueryHandler : IRequestHandler<GetReportListQuery, PaginatedList<GetReportListQueryVm>>
{
    private readonly DbSet<Report> _reports;
    public GetReportListQueryHandler(ThreatMapDbContext context)
    {
        _reports = context.Reports;
    }
    
    public async Task<PaginatedList<GetReportListQueryVm>> Handle(GetReportListQuery request, CancellationToken cancellationToken)
    {
        var query = _reports.AsQueryable(); // here includes
        if (!string.IsNullOrEmpty(request.SearchPhrase))
        {
             query = query.Where(a => EF.Functions.ILike(a.Description, request.SearchPhrase));
        }

        var vm = await query.Select(a => new GetReportListQueryVm()
        {
            Description = a.Description,
            Title = a.Title,
            ReportDate = a.ReportDate,
            UserId = a.UserId
        }).PaginatedListAsync(request);

        return vm;
    }
}