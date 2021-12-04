using ThreatMap.Domain.Common.Entities;
using ThreatMap.Domain.Identity.Entities;
using ThreatMap.Domain.Reports.Entities;

namespace ThreatMap.Domain.Comments.Entities;

public class Comment : AuditableEntity
{
    public string Content { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }

    public Report Report { get; set; }
    public long ReportId { get; set; }
}