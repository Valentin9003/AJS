using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AJS.Data.DbConfiguration
{
    public class AdDescriptionConfiguration : IEntityTypeConfiguration<AdDescription>
    {
        public void Configure(EntityTypeBuilder<AdDescription> builder)
        {
            throw new NotImplementedException();
        }
    }
}
