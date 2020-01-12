﻿using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    /// <summary>
    /// User Data Model Configuration
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasMany(a => a.Ads)
                   .WithOne(c => c.Creator)
                   .HasForeignKey(fk => fk.CreatorId);

            builder.HasMany(j => j.Jobs)
                 .WithOne(c => c.Creator)
                 .HasForeignKey(fk => fk.CreatorId);

            builder.HasMany(s => s.Services)
                 .WithOne(c => c.Creator)
                 .HasForeignKey(fk => fk.CreatorId);
        }
    }
}
