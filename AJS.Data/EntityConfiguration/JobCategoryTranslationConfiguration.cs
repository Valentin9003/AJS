using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AJS.Data.Models;

/// <summary>
///  AdCategoryTranslation Data Model Configuration
/// </summary>
namespace AJS.Data.EntityConfiguration
{
   public class JobCategoryTranslationConfiguration : IEntityTypeConfiguration<JobCategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<JobCategoryTranslation> builder)
        {
            builder.HasKey(k => k.JobCategoryTranslationId);
        }
    }
}
