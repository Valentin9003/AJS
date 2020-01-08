using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AJS.Data.DbConfiguration
{
    class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            throw new NotImplementedException();
        }
    }
}
