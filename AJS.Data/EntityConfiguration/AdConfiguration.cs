using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// Ad Data Model Configuration
    /// </summary>
    public class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.HasKey(k => k.AdId);

            builder.HasOne(c => c.Category)
                   .WithMany(a => a.Ads) 
                   .HasForeignKey(fk => fk.CategoryId);
        }
    }
}
