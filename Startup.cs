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

        // ������ ��� ����������� �������� � ������� ������ �������!!!!!! (�������) ������� �� ����� ������������
        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContext<AppDBContent>(option => option.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAllCars, CarRepository>();

            services.AddTransient<ICarsCategory, CategoryRepository>();

            services.AddTransient<IAllOrder,OrderRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //���������� ������� ������������ �������� ������������� � ������� ���������
            services.AddScoped(sp => ShopCart.GetCart(sp));

            // ��������� ��������� �VS � ����� �������
            services.AddMvc();

            services.AddMemoryCache();

            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePages(); // ���������� ���� ��������

            app.UseStaticFiles(); // ���������� ����������� ������ �� ������������ ������� (�������)

            app.UseDeveloperExceptionPage(); // ���������� �������� � �������� (���� ����)

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
                //// ��� ������ � ����� ������
                DBObjects.Initial(content);
            }
        }        
    }
}
