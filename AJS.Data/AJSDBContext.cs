using AJS.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<AdPrice> AdPrice { get; set; }

        public DbSet<Service> Service { get; set; }

        public DbSet<ServiceCategory> ServiceCategory { get; set; }

        public DbSet<ServiceLocation> ServiceLocation { get; set; }

        public DbSet<ServicePicture> ServicePicture { get; set; }

        public DbSet<ServiceDescription> ServiceDescription { get; set; }

        public DbSet<ServicePrice> ServicePrice { get; set; }

        public DbSet<Job> Job { get; set; }

        public DbSet<JobCategory> JobCategory { get; set; }

        public DbSet<JobLocation> JobLocation { get; set; }

        public DbSet<JobPicture> JobPicture { get; set; }

        public DbSet<JobDescription> JobDescription { get; set; }

        public DbSet<JobPrice> JobPrice { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            var assembly = typeof(AJSDbContext).Assembly;

            builder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(builder);
        }
    }
}
