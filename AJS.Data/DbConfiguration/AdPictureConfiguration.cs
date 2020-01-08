using AJS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AJS.Data.DbConfiguration
{
    public class AdPictureConfiguration : IEntityTypeConfiguration<AdPicture>
    {
        public void Configure(EntityTypeBuilder<AdPicture> builder)
        {
            throw new NotImplementedException();
        }
    }
}
