using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasKey(k => k.CategoryId);

            builder.HasMany(s => s.Categories)
                   .WithOne(p => p.ParentServiceCategory)
                   .HasForeignKey(fk => fk.ParentServiceCategoryId);
        }
    }
}
