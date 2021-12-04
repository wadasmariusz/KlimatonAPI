using ThreatMap.Domain.Comments.Entities;
using ThreatMap.Domain.Common.Entities;
using ThreatMap.Domain.Identity.Entities;
using ThreatMap.Domain.ReportRaises.Entities;
using ThreatMap.Domain.Reports.Enums;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Domain.Reports.Entities;

public class Report : AuditableEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? ReportDate { get; set; }

    public ReportType ReportType { get; set; }

    public ReportStatus ReportStatus { get; set; }
    public string AdminComment { get; set; }
    
    public Location Location { get; set; }

    public User User { get; set; }
    public long UserId { get; set; }

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<ReportRaise> ReportRaises { get; set; } = new List<ReportRaise>();
}