using ThreatMap.Domain.Institutions.Entities;

namespace ThreatMap.Application.Public.Queries.GetInstitutionsList;

public class GetInstitutionListQueryVm
{
    public List<Institution> Items { get; set; }
}