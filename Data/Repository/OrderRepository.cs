using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class OrderRepository : IAllOrder
    {
        private readonly AppDBContent _dBContent;

        private readonly ShopCart _cart;

        public OrderRepository(AppDBContent dBContent, ShopCart cart) {

            _dBContent = dBContent;
            _cart = cart;
        }

        public void OrderCreator(Order order)
        {
            if (order!=null) {

                order.AddTime = DateTime.Now;

                _dBContent.Orders.Add(order);

                foreach (var item in _cart.ListShopItems) {

                    var curtOrder = new OrderDetail() {

                        OrderId = order.Id,
                        Price = item.Price,
                        CarId = item.Id
                    };
                }
            }
        }
    }
}
