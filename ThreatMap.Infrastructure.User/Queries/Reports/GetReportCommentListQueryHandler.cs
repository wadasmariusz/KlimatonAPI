using MediatR;
using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Application.User.Queries.Reports.GetReportCommentList;
using ThreatMap.Domain.Comments.Entities;
using ThreatMap.Domain.Common.Enums;
using ThreatMap.Domain.Reports.Entities;
using ThreatMap.Persistence;
using ThreatMap.Shared.Extensions;
using ThreatMap.Shared.Models;

namespace ThreatMap.Infrastructure.User.Queries.Reports;

public class
    GetReportCommentListQueryHandler : IRequestHandler<GetUserReportCommentListQuery,
        PaginatedList<GetUserReportCommentListQueryVm>>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly DbSet<Comment> _comments;

    public GetReportCommentListQueryHandler(ICurrentUserService currentUserService, ThreatMapDbContext dbContext)
    {
        _currentUserService = currentUserService;
        _comments = dbContext.Comments;
    }

    public async Task<PaginatedList<GetUserReportCommentListQueryVm>> Handle(GetUserReportCommentListQuery request,
        CancellationToken cancellationToken)
    {
        var currentUserId = _currentUserService.UserId;

        var query = _comments.Where(a =>
            a.ReportId == request.ReportId && a.Status == Status.Active && a.UserId == currentUserId);

        var vm = await query.Select(a => new GetUserReportCommentListQueryVm()
        {
            Content = a.Content,
            CommentDate = a.CreatedDate,
            User = new ReportCommentListUserDto()
            {
                FirstName = a.User.FirstName,
                LastName = a.User.LastName
            }
        }).PaginatedListAsync(request);

        return vm;
    }
}