using ThreatMap.Domain.Institutions.Entities;

namespace ThreatMap.Application.Shared.Repositories;

public interface IInstitutionRepository
{
    Task CreateAsync(Institution institution);
    Task UpdateAsync(Institution institution);
    Task DeleteAsync(Institution institution);
}