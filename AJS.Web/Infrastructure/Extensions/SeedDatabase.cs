using AJS.Data;
using AJS.Data.Models;
using AJS.Data.Models.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJS.Web.Infrastructure.Extensions
{
    public static class SeedDatabase
    {
        public static IApplicationBuilder Seed(this IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var rolemanager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var db = serviceScope.ServiceProvider.GetRequiredService<AJSDbContext>();
                var configuration = serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();

                AddAdministrator(userManager, rolemanager, configuration);

                SeedUser(userManager);

                SeedAdCategory(db);

                SeedJobCategory(db);

                SeedServiceCategory(db);

                SeedNewsCategory(db);

                SeedAd(db);

                SeedJob(db);

                SeedService(db);

                SeedNews(db);
            }
            return app;
        }


        private static void AddAdministrator(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var adminDataSecret = configuration.GetSection(ProjectConstants.AdminConfigSection).GetChildren().ToDictionary(t => t.Key);

            var adminEmail = adminDataSecret[ProjectConstants.AdminEmailKey].Get<string>();
            var adminPassword = adminDataSecret[ProjectConstants.AdminPasswordKey].Get<string>();
            var adminName = adminDataSecret[ProjectConstants.AdminNameKey].Get<string>();

            if (string.IsNullOrEmpty(adminEmail) || string.IsNullOrEmpty(adminName) || string.IsNullOrEmpty(adminPassword))
            {
                throw new Exception(ProjectConstants.SeedDatabaseNullAdminDataErrorMessage);
            }

            var adminExist = Task.Run(() => userManager.FindByEmailAsync(adminEmail)).GetAwaiter().GetResult();

            if (adminExist == null)
            {
                var administrator = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = adminName,
                    Email = adminEmail,
                };

                Task.Run(() => userManager.CreateAsync(administrator, adminPassword)).GetAwaiter().GetResult();
            }

            var roleExist = Task.Run(() => roleManager.RoleExistsAsync(ProjectConstants.AdminRoleName)).GetAwaiter().GetResult();

            if (!roleExist)
            {
                var role = new IdentityRole
                {
                    Name = ProjectConstants.AdminRoleName
                };

                Task.Run(() => roleManager.CreateAsync(role)).GetAwaiter().GetResult();
            }

            var admin = Task.Run(() => userManager.FindByEmailAsync(adminEmail)).GetAwaiter().GetResult();
           var isInRole = Task.Run(() => userManager.IsInRoleAsync(admin, ProjectConstants.AdminRoleName)).GetAwaiter().GetResult();

            if (!isInRole)
            {
                Task.Run(() => userManager.AddToRoleAsync(admin, ProjectConstants.AdminRoleName)).GetAwaiter().GetResult();
            }
        }

        private static void SeedNewsCategory(AJSDbContext db)
        {
            for (int i = 0; i < 10; i++)
            {
                var categoryName = $"News Category {i}";
                var categoryExist = db.NewsCategory.Any(c => c.Name == categoryName);

                if (!categoryExist)
                {
                    var categoryId = Guid.NewGuid().ToString();
                    
                    var newsCategory = new NewsCategory()
                    {
                        CategoryId = categoryId,
                        Description = $"Some Description {i}",
                        Name = categoryName,

                        Translations = new List<NewsCategoryTranslation>()
                        {
                            new NewsCategoryTranslation()
                            {
                                CategoryId = categoryId,
                                Language = NewsCategoryLanguage.bg,
                                NewsCategoryTranslationId = Guid.NewGuid().ToString(),
                                Translation = $"Категория новини {i}"
                            },

                            new NewsCategoryTranslation()
                            {
                                CategoryId = categoryId,
                                Language = NewsCategoryLanguage.en,
                                NewsCategoryTranslationId = Guid.NewGuid().ToString(),
                                Translation = $"News Category {i}"
                            }
                        }
                    };

                    db.NewsCategory.Add(newsCategory);
                    db.SaveChanges();
                }
            }
        }

        private static void SeedNews(AJSDbContext db)
        {
            var user = db.Users.FirstOrDefault(u => u.UserType == UserType.Person);
            var isCreated = db.News.Any();
            var newsCategory = db.NewsCategory.FirstOrDefault();

            if (user != null && !isCreated && newsCategory != null)
            {
                var userId = user.Id;
                var categoryId = newsCategory.CategoryId;

                for (int i = 0; i <= 50; i++)
                {
                    var news = new News()
                       {
                        NewsId = Guid.NewGuid().ToString(),
                        Description = $"News Description {i}",
                        Location = i % 2 == 0 ? NewsLocation.Bulgaria : NewsLocation.England,
                        PublicationDate = DateTime.Now,
                        Title = $"News Title {i}",
                        CreatorId = userId,
                        ReviewCounter = i,
                        CategoryId = categoryId,
                       };

                    db.News.Add(news);
                    db.SaveChanges();
                }
            }
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
                    var firstSubCategoryId = Guid.NewGuid().ToString();
                    var secondSubCategoryId = Guid.NewGuid().ToString();
                    var thirdSubCategoryId = Guid.NewGuid().ToString();

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
                              CategoryId = firstSubCategoryId,
                              ParentAdCategoryId = parentCategoryId,
                              Description = $"Some Description{i}.1",
                              Categories = null,
                              Ads = null,

                              Translations = new HashSet<AdCategoryTranslation>()
                              {
                                 new AdCategoryTranslation
                                 {
                                     AdCategoryTranslationId = Guid.NewGuid().ToString(),
                                     CategoryId = firstSubCategoryId,
                                     Language = AdCategoryLanguage.bg,
                                     Translation = $"Обява Категория {i}"
                                 },

                                 new AdCategoryTranslation
                                 {
                                     AdCategoryTranslationId = Guid.NewGuid().ToString(),
                                     CategoryId = firstSubCategoryId,
                                     Language = AdCategoryLanguage.en,
                                     Translation = $"Ad Category {i}"
                                 }
                              }
                            },

                            new AdCategory
                            {
                              Name = $"AdSubCategory{i}.2",
                              CategoryId = secondSubCategoryId,
                              ParentAdCategoryId = parentCategoryId,
                              Description = $"Some Description{i}.2",
                              Categories = null,
                              Ads = null,

                              Translations = new List<AdCategoryTranslation>()
                              {
                                  new AdCategoryTranslation
                                  {
                                     AdCategoryTranslationId = Guid.NewGuid().ToString(),
                                     CategoryId = secondSubCategoryId,
                                     Language = AdCategoryLanguage.bg,
                                     Translation = $"Обява Категория {i}"
                                  },
                                  new AdCategoryTranslation
                                  {
                                      AdCategoryTranslationId = Guid.NewGuid().ToString(),
                                      CategoryId = secondSubCategoryId,
                                      Language = AdCategoryLanguage.en,
                                      Translation = $"Ad Category {i}"
                                  }
                              }
                            },

                            new AdCategory
                            {
                              Name = $"AdSubCategory{i}.3",
                              CategoryId = thirdSubCategoryId,
                              ParentAdCategoryId = parentCategoryId,
                              Description = $"Some Description{i}.3",
                              Categories = null,
                              Ads = null,

                              Translations = new List<AdCategoryTranslation>()
                              {
                                  new AdCategoryTranslation
                                  {
                                     AdCategoryTranslationId = Guid.NewGuid().ToString(),
                                     CategoryId = thirdSubCategoryId,
                                     Language = AdCategoryLanguage.bg,
                                     Translation = $"Обява Категория {i}"
                                  },

                                  new AdCategoryTranslation
                                  {
                                      AdCategoryTranslationId = Guid.NewGuid().ToString(),
                                      CategoryId = thirdSubCategoryId,
                                      Language = AdCategoryLanguage.en,
                                      Translation = $"Ad Category {i}"
                                  }
                              }
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
                    var firstSubCategoryId = Guid.NewGuid().ToString();
                    var secondSubCategoryId = Guid.NewGuid().ToString();
                    var thirdSubCategoryId = Guid.NewGuid().ToString();

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
                             CategoryId = firstSubCategoryId,
                             ParentServiceCategoryId = parentCategoryId,
                             Description = $"Some Description{i}.1",

                             Categories = null,
                             Services = null,

                              Translations = new HashSet<ServiceCategoryTranslation>()
                              {
                                 new ServiceCategoryTranslation
                                 {
                                     ServiceCategoryTranslationId = Guid.NewGuid().ToString(),
                                     CategoryId = firstSubCategoryId,
                                     Language = ServiceCategoryLanguage.bg,
                                     Translation = $"Услуги Категория {i}"
                                 },

                                 new ServiceCategoryTranslation
                                 {
                                     ServiceCategoryTranslationId = Guid.NewGuid().ToString(),
                                     CategoryId = firstSubCategoryId,
                                     Language = ServiceCategoryLanguage.en,
                                     Translation = $"Service Category {i}"
                                 }
                              }
                           },

                           new ServiceCategory
                           {
                             Name = $"ServiceSubCategory{i}.2",
                             CategoryId = secondSubCategoryId,
                             ParentServiceCategoryId = parentCategoryId,
                             Description = $"Some Description{i}.2",

                             Categories = null,
                             Services = null,

                              Translations = new HashSet<ServiceCategoryTranslation>()
                              {
                                 new ServiceCategoryTranslation
                                 {
                                     ServiceCategoryTranslationId = Guid.NewGuid().ToString(),
                                     CategoryId = secondSubCategoryId,
                                     Language = ServiceCategoryLanguage.bg,
                                     Translation = $"Услуги Категория {i}"
                                 },

                                 new ServiceCategoryTranslation
                                 {
                                     ServiceCategoryTranslationId = Guid.NewGuid().ToString(),
                                     CategoryId = secondSubCategoryId,
                                     Language = ServiceCategoryLanguage.en,
                                     Translation = $"Service Category {i}"
                                 }
                              }
                           },

                           new ServiceCategory
                           {
                             Name = $"ServiceSubCategory{i}.3",
                             CategoryId = thirdSubCategoryId,
                             ParentServiceCategoryId = parentCategoryId,
                             Description = $"Some Description{i}.3",

                             Categories = null,
                             Services = null,

                              Translations = new HashSet<ServiceCategoryTranslation>()
                              {
                                 new ServiceCategoryTranslation
                                 {
                                     ServiceCategoryTranslationId = Guid.NewGuid().ToString(),
                                     CategoryId = thirdSubCategoryId,
                                     Language = ServiceCategoryLanguage.bg,
                                     Translation = $"Услуги Категория {i}"
                                 },

                                 new ServiceCategoryTranslation
                                 {
                                     ServiceCategoryTranslationId = Guid.NewGuid().ToString(),
                                     CategoryId = thirdSubCategoryId,
                                     Language = ServiceCategoryLanguage.en,
                                     Translation = $"Service Category {i}"
                                 }
                              }
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
                    var firstSubCategoryId = Guid.NewGuid().ToString();
                    var secondSubCategoryId = Guid.NewGuid().ToString();
                    var thirdSubCategoryId = Guid.NewGuid().ToString();

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
                               Jobs = null,

                                Translations = new HashSet<JobCategoryTranslation>()
                                {
                                      new JobCategoryTranslation
                                      {
                                          JobCategoryTranslationId = Guid.NewGuid().ToString(),
                                          CategoryId = firstSubCategoryId,
                                          Language = JobCategoryLanguage.bg,
                                          Translation = $"Работа Категория {i}"
                                      },

                                      new JobCategoryTranslation
                                      {
                                          JobCategoryTranslationId = Guid.NewGuid().ToString(),
                                          CategoryId = firstSubCategoryId,
                                          Language = JobCategoryLanguage.en,
                                          Translation = $"Service Category {i}"
                                      }
                                }
                             },

                             new JobCategory
                             {
                               Name = $"JobSubCategory{i}.2",
                               CategoryId = secondSubCategoryId,
                               ParentJobCategoryId = parentCategoryId,
                               Description = $"Some Description{i}.2",
  
                               Categories = null,
                               Jobs = null,

                               Translations = new HashSet<JobCategoryTranslation>()
                                 {
                                      new JobCategoryTranslation()
                                      {
                                        JobCategoryTranslationId = Guid.NewGuid().ToString(),
                                        CategoryId = secondSubCategoryId,
                                        Language = JobCategoryLanguage.bg,
                                        Translation = $"Работа Категория {i}"
                                      },

                                      new JobCategoryTranslation
                                      {
                                          JobCategoryTranslationId = Guid.NewGuid().ToString(),
                                          CategoryId = secondSubCategoryId,
                                          Language = JobCategoryLanguage.en,
                                          Translation = $"Service Category {i}"
                                      }
                               }
                             },

                             new JobCategory
                             {
                               Name = $"JobSubCategory{i}.3",
                               CategoryId = thirdSubCategoryId,
                               ParentJobCategoryId = parentCategoryId,
                               Description = $"Some Description{i}.3",

                               Categories = null,
                               Jobs = null,

                                Translations = new HashSet<JobCategoryTranslation>()
                                {
                                      new JobCategoryTranslation
                                      {
                                          JobCategoryTranslationId = Guid.NewGuid().ToString(),
                                          CategoryId = thirdSubCategoryId,
                                          Language = JobCategoryLanguage.bg,
                                          Translation = $"Работа Категория {i}"
                                      },

                                      new JobCategoryTranslation
                                      {
                                          JobCategoryTranslationId = Guid.NewGuid().ToString(),
                                          CategoryId = thirdSubCategoryId,
                                          Language = JobCategoryLanguage.en,
                                          Translation = $"Job Category {i}"
                                      }
                                }
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

                var user = userManager.FindByEmailAsync(email).GetAwaiter().GetResult();

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
            var usersExist = db.Users.Any(u => u.UserType == UserType.Person) && db.Users.Any(u => u.UserType == UserType.Company);
            var categoriesExist = db.AdCategory.Any(p => p.ParentAdCategory == null) && db.AdCategory.Any(p => p.ParentAdCategory != null);
            var adExist = db.Ad.Any();

            if (usersExist && categoriesExist && !adExist)
            {
                var userId = db.Users.FirstOrDefault(u => u.UserType == UserType.Person).Id;
                var companyId = db.Users.FirstOrDefault(c => c.UserType == UserType.Company).Id;
                var parentCategoryId = db.AdCategory.FirstOrDefault(p => p.ParentAdCategory == null).CategoryId;
                var subCategoryId = db.AdCategory.FirstOrDefault(p => p.ParentAdCategory != null).CategoryId;

                for (int i = 0; i < 10; i++)
                {
                    var adId = Guid.NewGuid().ToString();

                    var ad = new Ad
                    {
                        AdId = adId,
                        CategoryId = i % 2 == 0 ? parentCategoryId : subCategoryId,
                        CreatorId = i % 2 == 0 ? userId : companyId,
                        ReviewCounter = i,
                        Language = i % 2 == 0 ? AdLanguage.BG : AdLanguage.EN,
                        PublicationDate = DateTime.Now,
                        Title = $"Some Title {i}",

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
                    };

                    db.Ad.Add(ad);
                    db.SaveChanges();
                }
            }
        }

        private static void SeedJob(AJSDbContext db)
        {
            var usersExist = db.Users.Any(u => u.UserType == UserType.Person) && db.Users.Any(u => u.UserType == UserType.Company);
            var categoriesExist = db.AdCategory.Any(p => p.ParentAdCategory == null) && db.AdCategory.Any(p => p.ParentAdCategory != null);
            var jobExist = db.Job.Any();

            if (usersExist && categoriesExist && !jobExist)
            {
                var userId = db.Users.FirstOrDefault(u => u.UserType == UserType.Person).Id;
                var companyId = db.Users.FirstOrDefault(c => c.UserType == UserType.Company).Id;
                var parentCategoryId = db.JobCategory.FirstOrDefault(p => p.ParentJobCategory == null).CategoryId;
                var subCategoryId = db.JobCategory.FirstOrDefault(p => p.ParentJobCategory != null).CategoryId;

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
                        ReviewCounter = i,

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
            var usersExist = db.Users.Any(u => u.UserType == UserType.Person) && db.Users.Any(u => u.UserType == UserType.Company);
            var categoriesExist = db.AdCategory.Any(p => p.ParentAdCategory == null) && db.AdCategory.Any(p => p.ParentAdCategory != null);
            var serviceExist = db.Service.Any();

            if (usersExist && categoriesExist && !serviceExist)
            {
                var userId = db.Users.FirstOrDefault(u => u.UserType == UserType.Person).Id;
                var companyId = db.Users.FirstOrDefault(c => c.UserType == UserType.Company).Id;
                var parentCategoryId = db.ServiceCategory.FirstOrDefault(p => p.ParentServiceCategory == null).CategoryId;
                var subCategoryId = db.ServiceCategory.FirstOrDefault(p => p.ParentServiceCategory != null).CategoryId;

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
                        ReviewCounter = i,

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
