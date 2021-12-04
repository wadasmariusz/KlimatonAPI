using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThreatMap.Domain.Reports.Entities;

namespace ThreatMap.Persistence.Configurations;

public class ReportEntityConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.HasKey(pl => pl.Id);
        
        builder.OwnsOne(a => a.Location)
            .Property(a => a.Latitude)
            .HasColumnName("Latitude");
        
        builder.OwnsOne(a => a.Location)
            .Property(a => a.Altitude)
            .HasColumnName("Altitude");

        builder.OwnsOne(a => a.Location)
            .Property(a => a.Longitude)
            .HasColumnName("Longitude");
    }
}