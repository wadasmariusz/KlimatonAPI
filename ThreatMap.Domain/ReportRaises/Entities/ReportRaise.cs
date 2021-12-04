using ThreatMap.Domain.Common.Entities;
using ThreatMap.Domain.Identity.Entities;
using ThreatMap.Domain.ReportRaises.Enums;
using ThreatMap.Domain.Reports.Entities;

namespace ThreatMap.Domain.ReportRaises.Entities;

public class ReportRaise : AuditableEntity
{
    public RaiseAction RaiseAction { get; set; }
    
    public Report Report { get; set; }
    public long ReportId { get; set; }
    
    public User User { get; set; }
    public long UserId { get; set; }
}