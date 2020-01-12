using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    public class ServicePictureConfiguration : IEntityTypeConfiguration<ServicePicture>
    {
        public void Configure(EntityTypeBuilder<ServicePicture> builder)
        {
            builder.HasKey(k => k.PictureId);

            builder.HasOne(p => p.Service)
                   .WithMany(a => a.Pictures)
                   .HasForeignKey(fk => fk.ServiceId);
        }
    }
}
