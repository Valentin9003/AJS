using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// JobPicture Data Model Configuration
    /// </summary>
    public class JobPictureConfiguration : IEntityTypeConfiguration<JobPicture>
    {
        public void Configure(EntityTypeBuilder<JobPicture> builder)
        {
            builder.HasKey(k => k.PictureId);

            builder.HasOne(j => j.Job)
                .WithOne(p => p.Picture)
                .HasForeignKey<Job>(fk => fk.PictureId);
        }
    }
}
