using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// Service Price Data Model Configuration
    /// </summary>
    public class ServicePriceConfiguration : IEntityTypeConfiguration<ServicePrice>
    {
        public void Configure(EntityTypeBuilder<ServicePrice> builder)
        {
            builder.HasKey(k => k.ServicePriceId);

            builder.HasOne(a => a.Service)
                .WithMany(p => p.Prices)
                .HasForeignKey(fk => fk.ServiceId);
        }
    }
}
