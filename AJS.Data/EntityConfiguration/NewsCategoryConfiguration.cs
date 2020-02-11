using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// JobCategory Data Model Configuration
    /// </summary>
    public class NewsCategoryConfiguration : IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
        {
            builder.HasKey(k => k.CategoryId);

            builder.HasMany(n => n.News)
                   .WithOne(c => c.Category)
                   .HasForeignKey(fk => fk.CategoryId);
        }
    }
}
