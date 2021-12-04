using ThreatMap.Domain.Comments.Entities;
using ThreatMap.Domain.Common.Entities;
using ThreatMap.Domain.Identity.Entities;
using ThreatMap.Domain.Reports.Enums;

namespace ThreatMap.Domain.Reports.Entities;

public class Report : AuditableEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? ReportDate { get; set; }

    public ReportType ReportType { get; set; }

    private uint _reportRaise = 0;
    
    public User User { get; set; }
    public long UserId { get; set; }

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public void RaiseReport()
    {
        _reportRaise++;
    }
}