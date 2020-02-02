using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// Job Price Data Model Configuration
    /// </summary>
    public class JobPriceConfiguration : IEntityTypeConfiguration<JobPrice>
    {
        public void Configure(EntityTypeBuilder<JobPrice> builder)
        {
            builder.HasKey(k => k.JobPriceId);

            builder.HasOne(a => a.Job)
                .WithMany(p => p.Prices)
                .HasForeignKey(fk => fk.JobId);
        }
    }
}
