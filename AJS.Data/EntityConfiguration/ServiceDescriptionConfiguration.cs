using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// ServiceDescription Data Model Configuration
    /// </summary>
    public class ServiceDescriptionConfiguration : IEntityTypeConfiguration<ServiceDescription>
    {
        public void Configure(EntityTypeBuilder<ServiceDescription> builder)
        {
            builder.HasKey(k => k.DescriptionId);

            builder.HasOne(s => s.Service)
                   .WithOne(d => d.Description)
                   .HasForeignKey<ServiceDescription>(fk => fk.ServiceId);
        }
    }
}
