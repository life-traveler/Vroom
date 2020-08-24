using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vroom.Models;

namespace Vroom
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //register services
        public void ConfigureServices(IServiceCollection services)
        {

           ///// services.AddMvc(options => options.EnableEndpointRouting = false);

            //registered AppDbContext with the dependency injection
            //using SqlServer as database provider for our applicatiom
            // to read the connection value which is stoted in json file format we use Iconfiguration service provided by asp.net core
            //use integrated windows authentication instead of sql
            services.AddDbContextPool<VroomAppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Default") ));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            ////custom route // conventional based routing
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        "byYearMonth",
            //        //url parameter
            //        "make/bikes/{year: int:length(4)}/{month: int:range(1,12)}",
            //        //for default we use annonymous object
            //        new { controller = "make", action = "ByYearMonth" });
            //});

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        "default",
            //        "{controller=Home}/{action=Index}/{id?}"
            //        );
            //});

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute()


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
