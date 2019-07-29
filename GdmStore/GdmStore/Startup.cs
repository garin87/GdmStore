using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GdmStore.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.SpaServices.Webpack;
using GdmStore.Services.Interfaces;
using GdmStore.Services;

namespace GdmStore
{
    public class Startup
    {
        private IHostingEnvironment _hostingEnvironment;
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            _hostingEnvironment = environment;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .AddJsonOptions(options =>
                    { 
                      options.SerializerSettings.DateFormatString = "dd.MM.yyyy HH:mm";
                    });

            var keysDirectoryName = "Keys";
            var keysDirectoryPath = Path.Combine(_hostingEnvironment.ContentRootPath, keysDirectoryName);
            if (!Directory.Exists(keysDirectoryPath))
            {
                Directory.CreateDirectory(keysDirectoryPath);
            }
            services.AddDataProtection()
              .PersistKeysToFileSystem(new DirectoryInfo(keysDirectoryPath))
              .SetApplicationName("CustomCookieAuthentication");

            services.Configure<CookiePolicyOptions>(options => {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options => {
                  options.LoginPath = new PathString("/Account/Login");
                  options.ExpireTimeSpan = TimeSpan.FromDays(30);
                  options.Cookie.Expiration = TimeSpan.FromDays(30);
                  options.SlidingExpiration = true;
              });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_0);


            string conString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(conString));

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
           
            services.AddScoped<IBaseServices<BaseObject>, BaseService<BaseObject>>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderProductService, OrderProductService>();
            services.AddScoped<IParameterService, ParameterService>();
            services.AddScoped<IProductParameterService, ProductParameterService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataContext dataContext)
        {
            Data.DbInitializer.Initialize(dataContext);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    ProjectPath = Path.Combine(Directory.GetCurrentDirectory(), "ClientApp"),
                    HotModuleReplacement = true
                });
            }

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            //app.UseCookiePolicy();
            //app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
            app.UseMvc();

        }
    }
}
