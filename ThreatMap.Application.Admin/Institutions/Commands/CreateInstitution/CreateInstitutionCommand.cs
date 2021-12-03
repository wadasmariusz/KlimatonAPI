using MediatR;
using ThreatMap.Domain.Institutions.Enums;

namespace ThreatMap.Application.Admin.Institutions.Commands.CreateInstitution;

public class CreateInstitutionCommand : IRequest<long>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public InstitutionType Type { get; set; }

    public string SchoolUrl { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }

    public string Number { get; }
    public string Street { get; }
    public string City { get; }
    public string Country { get; }
    public string ZipCode { get; }
    
    public double Latitude { get; }
    public double Longitude { get; }
}