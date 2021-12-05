using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Public.Reports.Queries.GetReport;
using ThreatMap.Application.Shared.Common.DTO;
using ThreatMap.Application.Shared.Common.DTO.Identity;
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
            await _reports
                .Include(q => q.Comments).ThenInclude(q => q.User)
                .Include(q => q.ReportRaises)
                .Where(a => a.Id == request.ReportId)
                .Select(a => new GetPublicReportQueryVm
                {
                    Description = a.Description,
                    Title = a.Title,
                    ReportDate = a.ReportDate,
                    UserId = a.UserId,
                    ReportType = a.ReportType,
                    ReportStatus = a.ReportStatus,
                    AdminComment = a.AdminComment,
                    Comments = a.Comments.Select(c => new GetPublicReportQueryVm.CommentDto
                    {
                        Content = c.Content,
                        UserFirstName = c.User.FirstName
                    }).ToList(),
                    Location = a.Location == null
                        ? null
                        : new LocationDto
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
                .FirstOrDefaultAsync(cancellationToken: cancellationToken) ??
            throw new NotFoundException($"Report with requested id:{request.ReportId} could not be found");
        return report;
    }
}