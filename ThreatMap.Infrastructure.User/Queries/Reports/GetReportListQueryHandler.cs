using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.User.Queries.Reports.GetReportList;
using ThreatMap.Domain.Common.Enums;
using ThreatMap.Domain.Reports.Entities;
using ThreatMap.Persistence;
using ThreatMap.Shared.Extensions;
using ThreatMap.Shared.Models;

namespace ThreatMap.Infrastructure.User.Queries.Reports;

public class GetReportListQueryHandler : IRequestHandler<GetReportListQuery, PaginatedList<GetReportListQueryVm>>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly DbSet<Report> _reports;

    public GetReportListQueryHandler(ThreatMapDbContext context, ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
        _reports = context.Reports;
    }

    public async Task<PaginatedList<GetReportListQueryVm>> Handle(GetReportListQuery request,
        CancellationToken cancellationToken)
    {
        var currentUserId = _currentUserService.UserId;
        var query = _reports.Where(a => a.Status == Status.Active && a.UserId == currentUserId ); // here includes
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