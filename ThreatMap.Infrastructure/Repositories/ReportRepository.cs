using Microsoft.EntityFrameworkCore;
using ThreatMap.Application.Shared.Repositories;
using ThreatMap.Domain.Reports.Entities;
using ThreatMap.Persistence;

namespace ThreatMap.Infrastructure.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly ThreatMapDbContext _db;

    public ReportRepository(ThreatMapDbContext db)
    {
        _db = db;
    }
    
    public async Task<Report> GetAsync(long reportId)
    {
        return await _db.Reports.FirstOrDefaultAsync(a => a.Id == reportId); //TODO Pamietac o dodaniu includow - tutaj include to zdj must have
    }

    public async Task CreateAsync(Report report)
    {
        await _db.Reports.AddAsync(report);
        await _db.SaveChangesAsync();

    }

    public async Task UpdateAsync(Report report)
    {
        _db.Reports.Update(report);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Report report)
    {
        _db.Reports.Remove(report);
        await _db.SaveChangesAsync();
    }
}