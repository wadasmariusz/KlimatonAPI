using ThreatMap.Domain.Common.Entities;
using ThreatMap.Domain.Identity.Entities;

namespace ThreatMap.Domain.Reports.Entities;

public class Report : AuditableEntity
{
    // public Point Type { get; set; } // Musi być odpowiedni using - NetTopologySuite
    public string Description { get; set; }
    public DateTimeOffset? ReportDate { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }
}