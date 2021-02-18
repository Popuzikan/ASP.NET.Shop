using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;

namespace Shop
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // служит для регистрации плагинов и модулев нашего проекта!!!!!! (пакетов)
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient <IAllCars,MockCars>();
            services.AddTransient<ICarsCategory, MockCategory>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
              
            app.UseStatusCodePages();
            app.UseStaticFiles();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();

            }

            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
