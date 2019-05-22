using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GdmStore.Models;
using GdmStore.Services;
using GdmStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using GdmStore.Services.Interfaces;

namespace GdmStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .AddJsonOptions(options =>
                    { 
                      options.SerializerSettings.DateFormatString = "dd.MM.yyyy HH:mm";
                    });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie(options =>
                 {  
                     options.Cookie.HttpOnly = true;
                     options.Cookie.SameSite = SameSiteMode.Lax;
                     options.Cookie.Name = "SimpleTalk.AuthCookieAspNetCore";
                     options.LoginPath = new PathString("/Account/Login");
                     options.AccessDeniedPath = new PathString("/Account/Login");

                 });
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
                options.HttpOnly = HttpOnlyPolicy.None;
            });
            //services.AddMvc(options => options.Filters.Add(new AuthorizeFilter()));

            string conString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(conString));

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
            DbInitializer.Initialize(dataContext);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            //app.UseCookiePolicy();
            //app.UseAuthentication();

            app.UseMvcWithDefaultRoute();


        }
    }
}
