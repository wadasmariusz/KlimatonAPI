using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ThreatMap.Application.Shared.Common.Services;
using ThreatMap.Domain;
using ThreatMap.Domain.Comments.Entities;
using ThreatMap.Domain.Common.Entities;
using ThreatMap.Domain.Common.Enums;
using ThreatMap.Domain.Identity.Entities;
using ThreatMap.Domain.Institutions.Entities;
using ThreatMap.Domain.Populations;
using ThreatMap.Domain.ReportRaises.Entities;
using ThreatMap.Domain.Reports.Entities;
using ThreatMap.Domain.Sensors.Entities;

namespace ThreatMap.Persistence;

public class ThreatMapDbContext : IdentityDbContext<User, IdentityRole<long>, long>
{
    private readonly IDateService _dateTimeOffset;
    private readonly ICurrentUserService _currentUserService;

    public ThreatMapDbContext(DbContextOptions<ThreatMapDbContext> options) : base(options)
    {
    }

    public ThreatMapDbContext(DbContextOptions<ThreatMapDbContext> options, IDateService dateTimeOffset,
        ICurrentUserService currentUserService) : base(options)
    {
        _dateTimeOffset = dateTimeOffset;
        _currentUserService = currentUserService;
    }

    public DbSet<Report> Reports { get; set; }
    public DbSet<Institution> Institutions { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<ReportRaise> ReportRaises { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<SensorData> SensorData { get; set; }
    public DbSet<Population> Populations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ThreatMapDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService.Email;
                    entry.Entity.CreatedDate = _dateTimeOffset.CurrentOffsetDate();
                    entry.Entity.Status = Status.Active;
                    
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _currentUserService.Email;
                    entry.Entity.LastModifiedDate = _dateTimeOffset.CurrentOffsetDate();
                    break;

                case EntityState.Deleted:
                    entry.Entity.LastModifiedBy = _currentUserService.Email;
                    entry.Entity.LastModifiedDate = _dateTimeOffset.CurrentOffsetDate();
                    entry.Entity.InactivatedBy = _currentUserService.Email;
                    entry.Entity.InactivatedDate = _dateTimeOffset.CurrentOffsetDate();
                    entry.Entity.Status = Status.Deleted;
                    entry.State = EntityState.Modified;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}