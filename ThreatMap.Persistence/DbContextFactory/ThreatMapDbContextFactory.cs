using Microsoft.EntityFrameworkCore;

namespace ThreatMap.Persistence.DbContextFactory;

public class ThreatMapDbContextFactory : DesignTimeDbContextFactoryBase<ThreatMapDbContext>
{
    protected override ThreatMapDbContext CreateNewInstance(DbContextOptions<ThreatMapDbContext> options)
    {
        return new ThreatMapDbContext(options);
    }
}