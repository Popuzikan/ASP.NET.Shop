using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
namespace Shop.Data.Models
{
    public class ShopCart {

        public string ShopCartId { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }


        private readonly AppDBContent _addDBContent;

        public ShopCart(AppDBContent addDBContent)
        {

            _addDBContent = addDBContent;
        }

        public static ShopCart GetCart(IServiceProvider service) {

            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = service.GetService<AppDBContent>();

            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

    }
}
