using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class OrderController: Controller {

        private readonly IAllOrder _allOrder;

        private readonly ShopCart _shopCart;

        public OrderController(IAllOrder allOrder, ShopCart shopCart) {

            _allOrder = allOrder;
            _shopCart = shopCart;
        }

        public IActionResult CheCout()
        {
            return View();
        }

    }
}
