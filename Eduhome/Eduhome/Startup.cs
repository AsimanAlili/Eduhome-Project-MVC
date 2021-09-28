using Eduhome.Data;
using Eduhome.Data.Entities;
using Eduhome.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            }).AddIdentity<AppUser, IdentityRole>(options =>
             {
                 options.Password.RequireNonAlphanumeric = false;
                 options.Password.RequireUppercase = false;
                 options.Password.RequiredLength = 8;
                 options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
                 options.Lockout.MaxFailedAccessAttempts = 3;

             }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            services.AddControllersWithViews();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Member_Auth";
                options.DefaultSignInScheme = "Member_Auth";
            })
            .AddCookie("Member_Auth", options =>
            {
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/login";
            })
           .AddCookie("Admin_Auth", options =>
           {
               options.LoginPath = "/manage/account/login";
               options.AccessDeniedPath = "/manage/account/login";
           });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
            });
            services.AddTransient<LayoutViewModelService>();
            services.AddSignalR();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.Use(async (context, next) =>
            {
                var area = context.Request.RouteValues["area"];
                string scheme = null;
                if (context.Request.Path.ToString().Contains("hub"))
                {
                    foreach (var item in context.Request.Cookies)
                    {
                        if (item.Key.Contains("Auth"))
                        {
                            scheme = item.Key.Substring(item.Key.LastIndexOf('.') + 1);
                            break;
                        }
                    }
                }
                else
                if (area == null)
                {
                    foreach (var item in context.Request.Cookies)
                    {
                        if (item.Key.Contains("Member_Auth"))
                        {
                            scheme = "Member_Auth";
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var item in context.Request.Cookies)
                    {
                        if (item.Key.Contains("Admin_Auth"))
                        {
                            scheme = "Admin_Auth";
                            break;
                        }
                    }
                }

                if (scheme != null)
                {
                    var result = await context.AuthenticateAsync(scheme);
                    if (result.Succeeded)
                    {
                        context.User = result.Principal;
                    }
                }

                await next();

                
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHub<EduhomeHub>("/hub");

            });
        }
    }
}
