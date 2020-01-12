using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    public class ServiceLocationConfiguration : IEntityTypeConfiguration<ServiceLocation>
    {
        public void Configure(EntityTypeBuilder<ServiceLocation> builder)
        {
            builder.HasKey(k => k.LocationId);

            builder.HasOne(a => a.Service)
                   .WithOne(l => l.Location)
                   .HasForeignKey<Service>(fk => fk.ServiceId);
        }
    }
}
