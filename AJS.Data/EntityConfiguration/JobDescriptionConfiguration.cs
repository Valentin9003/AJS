using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// JobDescription Data Model Configuration
    /// </summary>
    public class JobDescriptionConfiguration : IEntityTypeConfiguration<JobDescription>
    {
        public void Configure(EntityTypeBuilder<JobDescription> builder)
        {
            builder.HasKey(k => k.DescriptionId);

            builder.HasOne(j => j.Job)
                   .WithOne(d => d.Description)
                   .HasForeignKey<Job>(fk => fk.JobId);
        }
    }
}
