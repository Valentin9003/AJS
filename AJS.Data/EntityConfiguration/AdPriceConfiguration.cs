using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// Ad Price Data Model Configuration
    /// </summary>
    public class AdPriceConfiguration : IEntityTypeConfiguration<AdPrice>
    {
        public void Configure(EntityTypeBuilder<AdPrice> builder)
        {
            builder.HasKey(k => k.AdPriceId);

            builder.HasOne(a => a.Ad)
                .WithMany(p => p.Prices)
                .HasForeignKey(fk => fk.AdId);
        }
    }
}
