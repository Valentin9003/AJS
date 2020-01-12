﻿using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AJS.Data.EntityConfiguration
{
    public class ServiceDescriptionConfiguration : IEntityTypeConfiguration<ServiceDescription>
    {
        public void Configure(EntityTypeBuilder<ServiceDescription> builder)
        {
            builder.HasKey(k => k.DescriptionId);

            builder.HasOne(a => a.Service)
                   .WithOne(d => d.Description)
                   .HasForeignKey<Service>(fk => fk.ServiceId);
        }
    }
}
