using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// JobLocation Data Model Configuration
    /// </summary>
    public class JobLocationConfiguration : IEntityTypeConfiguration<JobLocation>
    {
        public void Configure(EntityTypeBuilder<JobLocation> builder)
        {
            builder.HasKey(k => k.LocationId);

            builder.HasOne(j => j.Job)
                      .WithOne(l => l.Location)
                      .HasForeignKey<JobLocation>(fk => fk.JobId);
        }
    }
}
