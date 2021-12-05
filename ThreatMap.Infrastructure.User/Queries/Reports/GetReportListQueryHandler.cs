using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Shared.Common.DTO;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.User.Queries.Reports.GetReportList;
using ThreatMap.Domain.Reports.Entities;
using ThreatMap.Persistence;
using ThreatMap.Shared.Extensions;
using ThreatMap.Shared.Models;

namespace ThreatMap.Infrastructure.User.Queries.Reports;

public class GetReportListQueryHandler : IRequestHandler<GetUserReportListQuery, PaginatedList<GetUserReportListQueryVm>>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly DbSet<Report> _reports;

    public GetReportListQueryHandler(ThreatMapDbContext context, ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
        _reports = context.Reports;
    }

    public async Task<PaginatedList<GetUserReportListQueryVm>> Handle(GetUserReportListQuery request,
        CancellationToken cancellationToken)
    {
        var query = _reports.AsNoTracking();
        if (!string.IsNullOrEmpty(request.SearchPhrase))
        {
            query = query.Where(a => EF.Functions.ILike(a.Description, request.SearchPhrase));
        }

        var vm = await query
            .Where(q => q.UserId == _currentUserService.UserId)
            .Include(q => q.User)
            .Include(q => q.Comments).ThenInclude(q => q.User)
            .Select(a => new GetUserReportListQueryVm()
            {
                Description = a.Description,
                Title = a.Title,
                ReportDate = a.ReportDate,
                UserId = a.UserId,
                CommentsCount = a.Comments.Count,
                RaisesCount = a.ReportRaises.Count,
                Location = a.Location == null
                    ? null
                    : new LocationDto()
                    {
                        Lat = a.Location.Latitude,
                        Lng = a.Location.Longitude
                    },
                Comments = a.Comments.Select(q => new GetUserReportListQueryVm.CommentDTO
                {
                    Content = q.Content,
                    UserFirstName = q.User.FirstName
                }).ToList()
            }).PaginatedListAsync(request);

        return vm;
    }
}