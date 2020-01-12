using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    public class AdPictureConfiguration : IEntityTypeConfiguration<AdPicture>
    {
        public void Configure(EntityTypeBuilder<AdPicture> builder)
        {
            builder.HasKey(k => k.PictureId);

            builder.HasOne(p => p.Ad)
                   .WithMany(a => a.Pictures)
                   .HasForeignKey(fk => fk.AdId);
        }
    }
}
