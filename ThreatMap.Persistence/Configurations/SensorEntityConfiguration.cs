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
        
        builder.OwnsOne(a => a.Address)
            .Property(a => a.Number)
            .HasColumnName("Number");
            
        builder.OwnsOne(a => a.Address)
            .Property(a => a.Street)
            .HasColumnName("Street");
            
        builder.OwnsOne(a => a.Address)
            .Property(a => a.City)
            .HasColumnName("City");

        builder.OwnsOne(a => a.Address)
            .Property(a => a.ZipCode)
            .HasColumnName("ZipCode");
       
    }
}