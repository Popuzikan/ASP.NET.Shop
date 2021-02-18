using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;
using Shop.Data.Repository;

namespace Shop
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IWebHostEnvironment hostEnv) {

               _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        // служит для регистрации плагинов и модулев нашего проекта!!!!!! (пакетов)
        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContext<AddDBContent>(option => option.UseSqlServer());

            services.AddTransient <IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddMvc();
        }
     
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
              
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints => {

                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
