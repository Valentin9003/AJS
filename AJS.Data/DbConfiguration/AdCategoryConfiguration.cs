using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AJS.Data.DbConfiguration
{
    public class AdCategoryConfiguration : IEntityTypeConfiguration<AdCategory>
    {
        public void Configure(EntityTypeBuilder<AdCategory> builder)
        {
            throw new NotImplementedException();
        }
    }
}
