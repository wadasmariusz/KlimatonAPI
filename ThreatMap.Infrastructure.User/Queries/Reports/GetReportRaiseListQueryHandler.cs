using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.User.Queries.Reports.GetReportCommentList;
using ThreatMap.Application.User.Queries.Reports.GetReportRaiseList;
using ThreatMap.Domain.Comments.Entities;
using ThreatMap.Domain.Common.Enums;
using ThreatMap.Domain.ReportRaises.Entities;
using ThreatMap.Domain.Reports.Entities;
using ThreatMap.Persistence;
using ThreatMap.Shared.Extensions;
using ThreatMap.Shared.Models;

namespace ThreatMap.Infrastructure.User.Queries.Reports;

public class
    GetReportRaiseListQueryHandler : IRequestHandler<GetReportRaiseListQuery,
        PaginatedList<GetReportRaiseListQueryVm>>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly DbSet<ReportRaise> _raises;

    public GetReportRaiseListQueryHandler(ICurrentUserService currentUserService, ThreatMapDbContext dbContext)
    {
        _currentUserService = currentUserService;
        _raises = dbContext.ReportRaises;
    }

    public async Task<PaginatedList<GetReportRaiseListQueryVm>> Handle(GetReportRaiseListQuery request,
        CancellationToken cancellationToken)
    {
        var currentUserId = _currentUserService.UserId;

        var query = _raises.Where(a =>
            a.ReportId == request.ReportId && a.Status == Status.Active && a.UserId == currentUserId);

        var vm = await query.Select(a => new GetReportRaiseListQueryVm()
        {
            User = new ReportRaiseListUserDto()
            {
                FirstName = a.User.FirstName,
                LastName = a.User.LastName
            },
            RaiseAction = a.RaiseAction
        }).PaginatedListAsync(request);

        return vm;
    }
}