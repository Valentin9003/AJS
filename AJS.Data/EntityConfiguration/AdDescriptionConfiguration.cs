using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// AdDescription Data Model Configuration
    /// </summary>
    public class AdDescriptionConfiguration : IEntityTypeConfiguration<AdDescription>
    {
        public void Configure(EntityTypeBuilder<AdDescription> builder)
        {
            builder.HasKey(k => k.DescriptionId);

            builder.HasOne(a => a.Ad)
                   .WithOne(d => d.Description)
                   .HasForeignKey<AdDescription>(fk => fk.AdId);
        }
    }
}
