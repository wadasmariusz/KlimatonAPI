using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Domain.Institutions.Entities;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.Repositories;

public class InstitutionRepository : IInstitutionRepository
{
    private readonly ThreatMapDbContext _db;

    public InstitutionRepository(ThreatMapDbContext db)
    {
        _db = db;
    }
    
    public async Task<Institution> GetAsync(long institutionId)
    {
        return await _db.Institutions.FirstOrDefaultAsync(a => a.Id == institutionId);
    }

    public async Task CreateAsync(Institution institution)
    {
        await _db.Institutions.AddAsync(institution);
        await _db.SaveChangesAsync();

    }

    public async Task UpdateAsync(Institution institution)
    {
        _db.Institutions.Update(institution);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Institution institution)
    {
        _db.Institutions.Remove(institution);
        await _db.SaveChangesAsync();
    }
}