using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// ServiceLocation Data Model Configuration
    /// </summary>
    public class ServiceLocationConfiguration : IEntityTypeConfiguration<ServiceLocation>
    {
        public void Configure(EntityTypeBuilder<ServiceLocation> builder)
        {
            builder.HasKey(k => k.LocationId);

            builder.HasOne(s => s.Service)
                   .WithOne(l => l.Location)
                   .HasForeignKey<ServiceLocation>(fk => fk.ServiceId);
        }
    }
}
