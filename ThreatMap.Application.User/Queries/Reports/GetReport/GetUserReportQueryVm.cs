using ThreatMap.Application.Shared.Common.DTO;
using ThreatMap.Application.Shared.Common.DTO.Identity;
using ThreatMap.Domain.ReportRaises.Entities;
using ThreatMap.Domain.Reports.Enums;

namespace ThreatMap.Application.User.Queries.Reports.GetReport;

public class GetUserReportQueryVm
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? ReportDate { get; set; }
    public ReportType ReportType { get; set; }
    public ReportStatus ReportStatus { get; set; }
    public string AdminComment { get; set; }
    public long UserId { get; set; }
    public LocationDto Location { get; set; }

    public UserDto User { get; set; }

    public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
    public ICollection<ReportRaise> ReportRaises { get; set; } = new List<ReportRaise>();
    
    public class CommentDto
    {
        public string Content { get; set; }
        public string UserFirstName { get; set; }
    }
}