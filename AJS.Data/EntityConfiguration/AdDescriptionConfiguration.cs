using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    public class AdDescriptionConfiguration : IEntityTypeConfiguration<AdDescription>
    {
        public void Configure(EntityTypeBuilder<AdDescription> builder)
        {
            builder.HasKey(k => k.DescriptionId);

            builder.HasOne(a => a.Ad)
                   .WithOne(d => d.Description)
                   .HasForeignKey<Ad>(fk => fk.AdId);
        }
    }
}
