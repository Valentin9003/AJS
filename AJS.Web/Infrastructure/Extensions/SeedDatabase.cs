using AJS.Data;
using AJS.Data.Models;
using AJS.Data.Models.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AJS.Web.Infrastructure.Extensions
{
    public static class SeedDatabase
    {
        public static IApplicationBuilder Seed(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();

                var db = serviceScope.ServiceProvider.GetRequiredService<AJSDbContext>();

                SeedUser(userManager);

                SeedAdCategory(db);

                SeedJobCategory(db);

                SeedServiceCategory(db);
            }
            return app;
        }

        private static void SeedAdCategory(AJSDbContext db)
        {
            for (int i = 0; i < 10; i++)
            {
                var adCategory = $"AdCategory{i}";

                var isCreated = db.AdCategory.Any(c => c.Name == adCategory);

                if (!isCreated)
                {
                    var parentCategoryId = Guid.NewGuid().ToString();

                    var category = new AdCategory
                    {
                        CategoryId = parentCategoryId,
                        Description = $"Some Text{i}",
                        Name = adCategory,
                        ParentAdCategory = null,

                        Categories = new HashSet<AdCategory>()
                            {
                            new AdCategory
                            {
                              Name = $"AdSubCategory{i}.1",
                              CategoryId = Guid.NewGuid().ToString(),
                              ParentAdCategoryId = parentCategoryId,
                              Description = $"Some Description{i}.1",
                              Categories = null,
                              Ads = null
                            },
                            new AdCategory
                            {
                              Name = $"AdSubCategory{i}.2",
                              CategoryId = Guid.NewGuid().ToString(),
                              ParentAdCategoryId = parentCategoryId,
                              Description = $"Some Description{i}.2",
                              Categories = null,
                              Ads = null
                            },
                            new AdCategory
                            {
                              Name = $"AdSubCategory{i}.3",
                              CategoryId = Guid.NewGuid().ToString(),
                              ParentAdCategoryId = parentCategoryId,
                              Description = $"Some Description{i}.3",
                              Categories = null,
                              Ads = null
                            }
                        }
                    };
                    db.AdCategory.Add(category);
                    db.SaveChanges();
                }
            }
        }

        private static void SeedServiceCategory(AJSDbContext db)
        {
            for (int i = 0; i < 10; i++)
            {
                var serviceCategory = $"ServiceCategory{i}";

                var isCreated = db.ServiceCategory.Any(c => c.Name == serviceCategory);

                if (!isCreated)
                {
                    var parentCategoryId = Guid.NewGuid().ToString();

                    var category = new ServiceCategory
                    {
                        CategoryId = parentCategoryId,
                        Description = $"Some Text{i}",
                        Name = serviceCategory,
                        ParentServiceCategory = null,

                        Categories = new HashSet<ServiceCategory>()
                        {
                           new ServiceCategory
                           {
                             Name = $"ServiceSubCategory{i}.1",
                             CategoryId = Guid.NewGuid().ToString(),
                             ParentServiceCategoryId = parentCategoryId,
                             Description = $"Some Description{i}.1",
                             Categories = null,
                             Services = null
                           },
                           new ServiceCategory
                           {
                             Name = $"ServiceSubCategory{i}.2",
                             CategoryId = Guid.NewGuid().ToString(),
                             ParentServiceCategoryId = parentCategoryId,
                             Description = $"Some Description{i}.2",
                             Categories = null,
                             Services = null
                           },
                           new ServiceCategory
                           {
                             Name = $"ServiceSubCategory{i}.3",
                             CategoryId = Guid.NewGuid().ToString(),
                             ParentServiceCategoryId = parentCategoryId,
                             Description = $"Some Description{i}.3",
                             Categories = null,
                             Services = null
                           }
                        }
                    };

                    db.ServiceCategory.Add(category);
                    db.SaveChanges();
                }
            }
        }

        private static void SeedJobCategory(AJSDbContext db)
        {
            for (int i = 0; i < 10; i++)
            {
                var JobCategory = $"JobCategory{i}";

                var isCreated = db.JobCategory.Any(c => c.Name == JobCategory);

                if (!isCreated)
                {
                    var parentCategoryId = Guid.NewGuid().ToString();

                    var category = new JobCategory
                    {
                        CategoryId = parentCategoryId,
                        Description = $"Some Text{i}",
                        Name = JobCategory,
                        ParentJobCategory = null,

                        Categories = new HashSet<JobCategory>()
                        {
                             new JobCategory
                             {
                               Name = $"JobSubCategory{i}.1",
                               CategoryId = Guid.NewGuid().ToString(),
                               ParentJobCategoryId = parentCategoryId,
                               Description = $"Some Description{i}.1",
                               Categories = null,
                               Jobs = null
                             },
                             new JobCategory
                             {
                               Name = $"JobSubCategory{i}.2",
                               CategoryId = Guid.NewGuid().ToString(),
                               ParentJobCategoryId = parentCategoryId,
                               Description = $"Some Description{i}.2",
                               Categories = null,
                               Jobs = null
                             },
                             new JobCategory
                             {
                               Name = $"JobSubCategory{i}.3",
                               CategoryId = Guid.NewGuid().ToString(),
                               ParentJobCategoryId = parentCategoryId,
                               Description = $"Some Description{i}.3",
                               Categories = null,
                               Jobs = null
                             }
                        }
                    };

                    db.JobCategory.Add(category);
                    db.SaveChanges();
                }
            }
        }

        private static void SeedUser(UserManager<User> userManager)
        {
            for (int i = 0; i < 50; i++)
            {
                var email = $"mail{i}@abv.bg";

                var user = userManager.FindByEmailAsync(email)
                                      .GetAwaiter()
                                      .GetResult();

                if (user == null)
                {
                    var phoneNumber = $"089000000{i}";
                    var userName = $"User{i}";

                    var currentUser = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = userName,
                        UserType = i % 2 == 0 ? UserType.Company : UserType.Person,
                        PhoneNumber = phoneNumber,
                        Email = email,
                    };

                    userManager.CreateAsync(currentUser, $"User{i}").GetAwaiter().GetResult();
                }
            }
        }
    }
}
