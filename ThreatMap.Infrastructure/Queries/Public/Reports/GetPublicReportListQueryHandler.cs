using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Public.Queries.Reports.GetReportList;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Domain.Common.Enums;
using ThreatMap.Domain.Reports.Entities;
using ThreatMap.Persistence;
using ThreatMap.Shared.Extensions;
using ThreatMap.Shared.Models;

namespace ThreatMap.Infrastructure.Queries.Public.Reports;

public class GetPublicReportListQueryHandler : IRequestHandler<GetPublicReportListQuery, PaginatedList<GetPublicReportListQueryVm>>
{
    
    private readonly DbSet<Report> _reports;

    public GetPublicReportListQueryHandler(ThreatMapDbContext context)
    {
        
        _reports = context.Reports;
    }

    public async Task<PaginatedList<GetPublicReportListQueryVm>> Handle(GetPublicReportListQuery request,
        CancellationToken cancellationToken)
    {
        
        var query = _reports.Where(a => a.Status == Status.Active ); // here includes
        if (!string.IsNullOrEmpty(request.SearchPhrase))
        {
            query = query.Where(a => EF.Functions.ILike(a.Description, request.SearchPhrase));
        }

        var vm = await query.Select(a => new GetPublicReportListQueryVm()
        {
            Description = a.Description,
            Title = a.Title,
            ReportDate = a.ReportDate,
            UserId = a.UserId
        }).PaginatedListAsync(request);

        return vm;
    }
}