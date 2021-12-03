using ThreatMap.Domain.Common.Enums;

namespace ThreatMap.Domain.Common.Entities;

public class AuditableEntity
{
    public long Id { get; set; }
        
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
        
    public string LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDate { get; set; }
        
    public Status Status { get; set; }
        
    public string InactivatedBy { get; set; }
    public DateTimeOffset? InactivatedDate { get; set; }
}