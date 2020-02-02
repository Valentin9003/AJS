using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// Job Data Model Configuration
    /// </summary>
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(k => k.JobId);

            builder.HasOne(c => c.Category)
                   .WithMany(j => j.Jobs)
                   .HasForeignKey(fk => fk.CategoryId);
        }
    }
}
