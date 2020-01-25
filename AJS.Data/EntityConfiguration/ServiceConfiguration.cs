using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// Service Data Model Configuration
    /// </summary>
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(k => k.ServiceId);

            builder.HasOne(c => c.Category)
                   .WithMany(s => s.Services)
                   .HasForeignKey(fk => fk.CategoryId);
        }
    }
}
