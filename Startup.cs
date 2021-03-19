using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Data.Interfaces;
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

        // служит для регистрации плагинов и модулев нашего проекта!!!!!! (пакетов) которые мы хотим успользовать
        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContext<AppDBContent>(option => option.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAllCars, CarRepository>();

            services.AddTransient<ICarsCategory, CategoryRepository>();

            services.AddTransient<IAllOrder,OrderRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //добавление сервиса позволяющего работать пользователям с разными корзинами
            services.AddScoped(sp => ShopCart.GetCart(sp));

            // добавляем поддержку МVS в нашем проекте
            services.AddMvc();

            services.AddMemoryCache();

            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePages(); // отображает коды страницы

            app.UseStaticFiles(); // подключает возможность работы со статическими данными (файлами)

            app.UseDeveloperExceptionPage(); // отображает страницу с ошибками (если есть)

            app.UseSession();

            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("categoryFilt", "Car/{action}/{category?}", new {Controller="Car", action = "List" });
            });

            using (var scope = app.ApplicationServices.CreateScope()) {

                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                //// для работы с Базой данных
                DBObjects.Initial(content);
            }
        }        
    }
}
