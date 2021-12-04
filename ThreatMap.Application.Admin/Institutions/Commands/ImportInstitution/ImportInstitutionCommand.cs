using MediatR;

namespace ThreatMap.Application.Admin.Institutions.Commands.ImportInstitution;

public class ImportInstitutionCommand : IRequest<List<long>>
{
    public List<InstitutionCSV> Institutions { get; set; }
}