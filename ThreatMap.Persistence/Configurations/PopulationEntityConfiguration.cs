using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreatMap.Domain.Populations;

namespace ThreatMap.Persistence.Configurations
{
    public class PopulationEntityConfiguration : IEntityTypeConfiguration<Population>
    {
        public void Configure(EntityTypeBuilder<Population> builder)
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
}
