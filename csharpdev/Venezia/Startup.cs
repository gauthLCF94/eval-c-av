using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Venezia.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Venezia.Filters;

namespace Venezia
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(config => {
                config.Filters.Add(new AuthFilter());
            });

            services.AddControllersWithViews();
            
            services.AddRazorPages();

            services.AddSession();

            services.AddDbContext<VeneziaContext>(options => options
                    .UseLoggerFactory(VeneziaContext.SqlLogger)
                    .UseSqlServer(Configuration.GetConnectionString("VeneziaContext")));

            services.AddDbContext<VeneziaIdentityUserContext>(options => options
                    .UseLoggerFactory(VeneziaContext.SqlLogger)
                    .UseSqlServer(Configuration.GetConnectionString("VeneziaUserContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
