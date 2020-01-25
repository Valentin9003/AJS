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

                SeedAd(db);

                SeedJob(db);

                SeedService(db);
            }
            return app;
        }

        private static void SeedAdCategory(AJSDbContext db)
        {
            for (int i = 0; i < 10; i++)
            {
                var adCategory = $"AdCategory{i}";

                var isCreated = db.AdCategory
                                  .Any(c => c.Name == adCategory);

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

        private static void SeedAd(AJSDbContext db)
        {
            var usersExist = db.Users
                               .Any(u => u.UserType == UserType.Person) && db.Users.Any(u => u.UserType == UserType.Company);

            var categoriesExist = db.AdCategory
                                    .Any(p => p.ParentAdCategory == null) && db.AdCategory.Any(p => p.ParentAdCategory != null);

            var adExist = db.Ad.Any();

            if (usersExist && categoriesExist && !adExist)
            {
                var userId = db.Users
                               .FirstOrDefault(u => u.UserType == UserType.Person)
                               .Id;

                var companyId = db.Users
                                  .FirstOrDefault(c => c.UserType == UserType.Company)
                                  .Id;

                var parentCategoryId = db.AdCategory
                                         .FirstOrDefault(p => p.ParentAdCategory == null)
                                         .CategoryId;

                var subCategoryId = db.AdCategory
                                      .FirstOrDefault(p => p.ParentAdCategory != null)
                                      .CategoryId;

                for (int i = 0; i < 10; i++)
                {
                    var adId = Guid.NewGuid().ToString();

                    var ad = new Ad
                    {
                        AdId = adId,
                        CategoryId = i % 2 == 0 ? parentCategoryId : subCategoryId,
                        CreatorId = i % 2 == 0 ? userId : companyId,

                        Pictures = new List<AdPicture>()
                        {
                            new AdPicture
                            {
                                PictureByteArray = new byte[1]{ 0},
                                AdId = adId,
                                IsMainPicture = true,
                                PictureId = Guid.NewGuid().ToString()
                            }
                        },
                        Description = new AdDescription
                        {
                            DescriptionId = Guid.NewGuid().ToString(),
                            AdId = adId,
                            State = AdState.New,
                            Description = $"Some Description{i}"
                        },
                        Location = new AdLocation
                        {
                            LocationId = Guid.NewGuid().ToString(),
                            AdId = adId,
                            Address = $"Some address {i}",
                            Street = $"Some street {i}",
                            City = $"Some city {i}",
                            Country = $"Some country {i}",
                            PostCode = $"2000",
                        },
                        Prices = new List<AdPrice>()
                        {
                            new AdPrice
                            {
                                AdPriceId = Guid.NewGuid().ToString(),
                                AdId = adId,
                                Currency = "BG",
                                Price = 200 + i,
                            }
                        },
                        Language = i % 2 == 0 ? AdLanguage.BG : AdLanguage.EN,
                        PublicationDate = DateTime.Now,
                        Title = $"Some Title {i}"
                    };

                    db.Ad.Add(ad);
                    db.SaveChanges();
                }
            }
        }

        private static void SeedJob(AJSDbContext db)
        {
            var usersExist = db.Users
                               .Any(u => u.UserType == UserType.Person) && db.Users.Any(u => u.UserType == UserType.Company);

            var categoriesExist = db.AdCategory
                                    .Any(p => p.ParentAdCategory == null) && db.AdCategory.Any(p => p.ParentAdCategory != null);

            var jobExist = db.Job.Any();

            if (usersExist && categoriesExist && !jobExist)
            {
                var userId = db.Users
                               .FirstOrDefault(u => u.UserType == UserType.Person)
                               .Id;

                var companyId = db.Users
                                  .FirstOrDefault(c => c.UserType == UserType.Company)
                                  .Id;

                var parentCategoryId = db.JobCategory
                                         .FirstOrDefault(p => p.ParentJobCategory == null)
                                         .CategoryId;

                var subCategoryId = db.JobCategory
                                      .FirstOrDefault(p => p.ParentJobCategory != null)
                                      .CategoryId;

                for (int i = 0; i < 10; i++)
                {
                    var jobId = Guid.NewGuid().ToString();

                    var job = new Job
                    {
                        JobId = jobId,

                        CategoryId = i % 2 == 0 ? parentCategoryId : subCategoryId,

                        CreatorId = i % 2 == 0 ? userId : companyId,

                        Language = i % 2 == 0 ? JobLanguage.BG : JobLanguage.EN,

                        PublicationDate = DateTime.Now,

                        Title = $"Some Title {i}",

                        Picture = new JobPicture
                        {
                            PictureByteArray = new byte[1] { 0 },
                            JobId = jobId,
                            PictureId = Guid.NewGuid().ToString()
                        },

                        Description = new JobDescription
                        {
                            DescriptionId = Guid.NewGuid().ToString(),
                            JobId = jobId,
                            Description = $"Some Description{i}"
                        },

                        Location = new JobLocation
                        {
                            LocationId = Guid.NewGuid().ToString(),
                            JobId = jobId,
                            Address = $"Some address {i}",
                            Street = $"Some street {i}",
                            City = $"Some city {i}",
                            Country = $"Some country {i}",
                            PostCode = $"200{i}",
                        },

                        Prices = new List<JobPrice>()
                        {
                            new JobPrice
                            {
                                JobPriceId = Guid.NewGuid().ToString(),
                                JobId = jobId,
                                Currency = "BG",
                                Price = 200 + i,
                            }
                        },
                    };

                    db.Job.Add(job);
                    db.SaveChanges();
                }
            }
        }
        private static void SeedService(AJSDbContext db)
        {
            var usersExist = db.Users
                               .Any(u => u.UserType == UserType.Person) && db.Users.Any(u => u.UserType == UserType.Company);

            var categoriesExist = db.AdCategory
                                    .Any(p => p.ParentAdCategory == null) && db.AdCategory.Any(p => p.ParentAdCategory != null);

            var serviceExist = db.Service.Any();

            if (usersExist && categoriesExist && !serviceExist)
            {
                var userId = db.Users
                               .FirstOrDefault(u => u.UserType == UserType.Person)
                               .Id;

                var companyId = db.Users
                                  .FirstOrDefault(c => c.UserType == UserType.Company)
                                  .Id;

                var parentCategoryId = db.ServiceCategory
                                         .FirstOrDefault(p => p.ParentServiceCategory == null)
                                         .CategoryId;

                var subCategoryId = db.ServiceCategory
                                      .FirstOrDefault(p => p.ParentServiceCategory != null)
                                      .CategoryId;

                for (int i = 0; i < 10; i++)
                {
                    var serviceId = Guid.NewGuid().ToString();

                    var service = new Service
                    {
                        ServiceId = serviceId,

                        CategoryId = i % 2 == 0 ? parentCategoryId : subCategoryId,

                        CreatorId = i % 2 == 0 ? userId : companyId,

                        Language = i % 2 == 0 ? ServiceLanguage.BG : ServiceLanguage.EN,

                        PublicationDate = DateTime.Now,

                        Title = $"Some Title {i}",

                        Pictures = new List<ServicePicture>()
                        {
                            new ServicePicture
                            {
                                PictureByteArray = new byte[1] { 0 },
                                ServiceId = serviceId,
                                PictureId = Guid.NewGuid().ToString()
                            }
                        },

                        Description = new ServiceDescription
                        {
                            DescriptionId = Guid.NewGuid().ToString(),
                            ServiceId = serviceId,
                            Description = $"Some Description{i}"
                        },

                        Location = new ServiceLocation
                        {
                            LocationId = Guid.NewGuid().ToString(),
                            ServiceId = serviceId,
                            Address = $"Some address {i}",
                            Street = $"Some street {i}",
                            City = $"Some city {i}",
                            Country = $"Some country {i}",
                            PostCode = $"200{i}",
                        },

                        Prices = new List<ServicePrice>()
                        {
                            new ServicePrice
                            {
                                ServicePriceId = Guid.NewGuid().ToString(),
                                ServiceId = serviceId,
                                Currency = "BG",
                                Price = 200 + i,
                            }
                        },
                    };

                    db.Service.Add(service);
                    db.SaveChanges();
                }
            }
        }
    }
}
