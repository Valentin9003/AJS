using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// JobCategory Data Model Configuration
    /// </summary>
    public class JobCategoryConfiguration : IEntityTypeConfiguration<JobCategory>
    {
        public void Configure(EntityTypeBuilder<JobCategory> builder)
        {
            builder.HasKey(k => k.CategoryId);

            builder.HasMany(c => c.Categories)
                   .WithOne(p => p.ParentJobCategory)
                   .HasForeignKey(fk => fk.ParentJobCategoryId);
        }
    }
}
