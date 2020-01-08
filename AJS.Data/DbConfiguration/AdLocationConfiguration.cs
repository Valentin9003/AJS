using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AJS.Data.DbConfiguration
{
    public class AdLocationConfiguration : IEntityTypeConfiguration<AdLocation>
    {
        public void Configure(EntityTypeBuilder<AdLocation> builder)
        {
            throw new NotImplementedException();
        }
    }
}
