using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// ServicePicture Data Model Configuration
    /// </summary>
    public class ServicePictureConfiguration : IEntityTypeConfiguration<ServicePicture>
    {
        public void Configure(EntityTypeBuilder<ServicePicture> builder)
        {
            builder.HasKey(k => k.PictureId);

            builder.HasOne(s => s.Service)
                   .WithMany(p => p.Pictures)
                   .HasForeignKey(fk => fk.ServiceId);
        }
    }
}
