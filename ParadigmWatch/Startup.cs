using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParadigmWatch.Data;
using ParadigmWatch.Models;
using ParadigmWatch.Models.ViewModels;
using Microsoft.AspNetCore.StaticFiles;
/// <summary>
/// </summary>
namespace ParadigmWatch
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

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddSession();

            services.AddDbContext<ParadigmWatchContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"))
                );

            // WE WILL ENABLES THIS AGAIN ONCE WE HAVE A DATABASE READY :)  
            services.AddDbContext<ParadigmWatchContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));


            services.AddIdentity<AppUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ParadigmWatchContext>()
            .AddDefaultTokenProviders();

            //services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Users/Login");

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var options = new StaticFileOptions
            {
                ContentTypeProvider = new FileExtensionContentTypeProvider()
            };
            ((FileExtensionContentTypeProvider)options.ContentTypeProvider).Mappings.Add(
                new KeyValuePair<string, string>(".glb", "text/plain"));

            


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(
                new StaticFileOptions
                {   /* unknown mime types (ie: .fx) files will not be served, otherwise! */
                    ServeUnknownFileTypes = true
                }
);
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                        name: "",
                        pattern: "Store/{watchName}",
                        defaults: new
                        {
                            controller = "ProductPage",
                            action = "Index"
                        }
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //AppIdentityDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
        }
    }
}
