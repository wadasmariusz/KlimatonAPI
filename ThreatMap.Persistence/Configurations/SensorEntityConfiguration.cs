using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThreatMap.Domain.Sensors.Entities;

namespace ThreatMap.Persistence.Configurations;

public class SensorEntityConfiguration : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
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