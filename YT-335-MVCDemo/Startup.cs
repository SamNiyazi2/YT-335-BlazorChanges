using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YT_335_MVCDemo
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
            services.AddRazorPages();


            // 08/20/2021 03:06 pm - SSN - [20210820-1506] - [001] - 01 - Adding Blazor
            // Need to install Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation (5.0.0)
            // services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddServerSideBlazor();



            // Enable Razor server.  Razor Web Assembly is another option.


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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                // 08/20/2021 03:21 pm - SSN - [20210820-1506] - [005] - 01 - Adding Blazor
                endpoints.MapBlazorHub();



                endpoints.MapRazorPages();
            });
        }
    }
}
