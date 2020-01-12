using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// AdCategory Data Model Configuration
    /// </summary>
    public class AdCategoryConfiguration : IEntityTypeConfiguration<AdCategory>
    {
        public void Configure(EntityTypeBuilder<AdCategory> builder)
        {
            builder.HasKey(k => k.CategoryId);

            builder.HasMany(s => s.Categories)
                   .WithOne(p => p.ParentAdCategory)
                   .HasForeignKey(fk => fk.ParentAdCategoryId);
        }
    }
}
