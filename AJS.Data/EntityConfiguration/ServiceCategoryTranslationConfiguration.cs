using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AJS.Data.Models;

/// <summary>
///  ServiceCategoryTranslation Data Model Configuration
/// </summary>
namespace AJS.Data.EntityConfiguration
{
   public class ServiceCategoryTranslationConfiguration : IEntityTypeConfiguration<ServiceCategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<ServiceCategoryTranslation> builder)
        {
            builder.HasKey(k => k.ServiceCategoryTranslationId);
        }
    }
}
