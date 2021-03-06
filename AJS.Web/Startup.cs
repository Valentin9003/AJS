using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using AJS.Web.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using AJS.Data;
using AJS.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using AJS.Web.Infrastructure.EmailSenderConfiguration;
using System.IO;
using NLog;
using AJS.Common.Logger;
using AJS.Web.Models;
using Microsoft.Extensions.Options;

namespace AJS.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), ProjectConstants.NLogConfigFileDirectory));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AJSDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString(ProjectConstants.DefaultConnection))) ;

            services.AddCustomServices();
            services.AddSingleton(Configuration);

            services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<AJSDbContext>();
          
            services.AddAuthentication()
                    .AddFacebook(option =>
                    {
                        option.AppSecret = Configuration.GetValue<string>(ProjectConstants.FacebookAppSecret);
                        option.AppId = Configuration.GetValue<string>(ProjectConstants.FacebookAppId);
                    });

            services.AddAuthorization();


            services.Configure<AuthMessageSenderOptions>(Configuration.GetSection(ProjectConstants.SendGridConfigSection));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddLocalization(option => option.ResourcesPath = ProjectConstants.LanguageResourcesPath);

            services.AddControllersWithViews()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, option => option.ResourcesPath = ProjectConstants.LanguageResourcesPath)
                    .AddDataAnnotationsLocalization();
            
            services.AddCors();
            services.AddSession();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDomainServices();
            services.GetRequestLocalization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler(ProjectConstants.ErrorControllerPath);
                app.UseHsts();
                app.UseLogger();
            }

            app.UseDatabaseMigration();
            app.Seed();
            app.UseCors();
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRequestLocalizationExtension();
            app.SetLocalizationCookie();
            app.UseEndpointsExtension();
        }
    }
}
