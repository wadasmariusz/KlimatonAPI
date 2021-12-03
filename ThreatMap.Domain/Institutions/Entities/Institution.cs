using ThreatMap.Domain.Common.Entities;
using ThreatMap.Domain.Institutions.Enums;
using ThreatMap.Domain.ValueObjects;

namespace ThreatMap.Domain.Institutions.Entities;

public class Institution : AuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public InstitutionType Type { get; set; }

    public string SchoolUrl { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }

    public Address Address { get; set; }
    public Location Location { get; set; }
}