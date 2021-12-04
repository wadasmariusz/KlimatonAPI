using ThreatMap.Domain.Institutions.Enums;

namespace ThreatMap.Application.Admin.Institutions.Commands.ImportInstitution;

public class InstitutionCSV
{
    public string Name { get; set; }
    public InstitutionType Type { get; set; }

    public string SchoolUrl { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }

    public string Number { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}