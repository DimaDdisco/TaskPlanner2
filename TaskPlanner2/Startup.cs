using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskPlanner2.Models.DataBase;
using TaskPlanner2.Services;
using TaskPlanner2.Services.Abstract;


namespace TaskPlanner2
{
    public class Startup 
    {
        private IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Database
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TaskPlannerContext>(options => options.UseSqlServer(connection));

            // Unit of work (Supposed to be singleton, but Database is scoped)
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // MVC 
            services.AddControllersWithViews();

            // Authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            // Authentication service
            services.AddHttpContextAccessor();
            services.AddScoped<IAuthentication, Authentication>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
