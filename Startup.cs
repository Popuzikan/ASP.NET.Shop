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
using Shop.Data.Models;
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

            services.AddDbContext<AppDBContent>(option => option.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //добавление сервиса позволяющего работать пользователям с разными корзинами
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc();

            services.AddMemoryCache();

            services.AddSession();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseStaticFiles();    
            app.UseDeveloperExceptionPage();
            app.UseSession();

            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                //// для работы с Базой данных
                DBObjects.Initial(content);
            }
        }        
    }
}
