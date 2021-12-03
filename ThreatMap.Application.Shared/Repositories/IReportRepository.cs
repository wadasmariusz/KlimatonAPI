using ThreatMap.Domain.Reports.Entities;

namespace ThreatMap.Application.Shared.Repositories;

public interface IReportRepository
{
    Task<Report> GetAsync(long reportId);
    Task CreateAsync(Report report);
    Task UpdateAsync(Report report);
    Task DeleteAsync(Report report);
}