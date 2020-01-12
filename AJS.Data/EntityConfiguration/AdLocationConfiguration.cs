﻿using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    public class AdLocationConfiguration : IEntityTypeConfiguration<AdLocation>
    {
        public void Configure(EntityTypeBuilder<AdLocation> builder)
        {
            builder.HasKey(k => k.LocationId);

            builder.HasOne(a => a.Ad)
                   .WithOne(l => l.Location)
                   .HasForeignKey<Ad>(fk => fk.AdId);
        }
    }
}