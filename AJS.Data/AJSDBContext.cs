using AJS.Data.EntityConfiguration;
using AJS.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace AJS.Data
{
    public class AJSDbContext : IdentityDbContext<User>
    {
        public AJSDbContext(DbContextOptions<AJSDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        public DbSet<Ad> Ad { get; set; }

        public DbSet<AdDescription> AdDescription { get; set; }

        public DbSet<AdCategory> AdCategory { get; set; }

        public DbSet<AdLocation> AdLocation { get; set; }

        public DbSet<AdPicture> AdPicture { get; set; } 

        public DbSet<Service> Service { get; set; }

        public DbSet<ServiceCategory> ServiceCategory { get; set; }

        public DbSet<ServiceLocation> ServiceLocation { get; set; }

        public DbSet<ServicePicture> ServicePicture { get; set; }

        public DbSet<ServiceDescription> ServiceDescription { get; set; }

        //public DbSet<Job> Job { get; set; }

        //public DbSet<JobCategory> JobCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new AdConfiguration());

            builder.ApplyConfiguration(new AdDescriptionConfiguration());

            builder.ApplyConfiguration(new AdCategoryConfiguration());

            builder.ApplyConfiguration(new AdLocationConfiguration());

            builder.ApplyConfiguration(new AdPictureConfiguration());

            builder.ApplyConfiguration(new ServiceConfiguration());

            builder.ApplyConfiguration(new ServiceCategoryConfiguration());

            builder.ApplyConfiguration(new ServiceLocationConfiguration());

            builder.ApplyConfiguration(new ServicePictureConfiguration());

            builder.ApplyConfiguration(new ServiceDescriptionConfiguration());

            //builder.ApplyConfiguration(new JobConfiguration());

            //builder.ApplyConfiguration(new JobCategoryConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
