using System.Linq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Shared.Common.DTO;
using ThreatMap.Application.Shared.Common.DTO.Identity;
using ThreatMap.Application.User.Queries.Reports.GetReport;
using ThreatMap.Domain.Reports.Entities;
using ThreatMap.Domain.Reports.Enums;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.User.Queries.Reports;

public class GetReportQueryHandler : IRequestHandler<GetUserReportQuery, GetUserReportQueryVm>
{
    private readonly DbSet<Report> _reports;

    public GetReportQueryHandler(ThreatMapDbContext dbContext)
    {
        _reports = dbContext.Reports;
    }

    public async Task<GetUserReportQueryVm> Handle(GetUserReportQuery request, CancellationToken cancellationToken)
        => await _reports.Where(a => a.Id == request.ReportId).AsNoTracking()
            .Include(q => q.Comments).ThenInclude(q => q.User)
            .Include(q => q.ReportRaises)
            .Select(a => new GetUserReportQueryVm
            {
                Description = a.Description,
                Title = a.Title,
                ReportDate = a.ReportDate,
                UserId = a.UserId,
                ReportType = a.ReportType,
                ReportStatus = a.ReportStatus,
                AdminComment = a.AdminComment,
                Comments = a.Comments.Select(c => new GetUserReportQueryVm.CommentDto
                {
                    Content = c.Content,
                    UserFirstName = c.User.FirstName
                }).ToList(),
                Location = a.Location == null? null : new LocationDto
                {
                    Lat = a.Location.Latitude,
                    Lng = a.Location.Longitude
                },
                User = new UserDto
                {
                    FirstName = a.User.FirstName,
                    LastName = a.User.LastName
                },
                ReportRaises = a.ReportRaises
            })
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);
}