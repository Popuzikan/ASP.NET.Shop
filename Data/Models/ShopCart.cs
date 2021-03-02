using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Shop.Data.Models
{
    public class ShopCart {

        public string ShopCartId { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }


        private readonly AppDBContent _addDBContent;

        public ShopCart(AppDBContent addDBContent) {
            _addDBContent = addDBContent;
        }

        public static ShopCart GetCart(IServiceProvider service) {

            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = service.GetService<AppDBContent>();

            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Car car) {

            _addDBContent.ShopCartItems.Add( new ShopCartItem() { 
                ShopCartId = ShopCartId,
                Auto = car,
                Price = car.Price
            });

            _addDBContent.SaveChanges();
        }

        public List<ShopCartItem> GetShopItems() {

            return _addDBContent.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Auto).ToList();
        }


    }
}
