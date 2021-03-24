using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
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

        public IActionResult CheCout() => View();

        [HttpPost]
        public IActionResult Checout(Order order) {

            _shopCart.ListShopItems = _shopCart.GetShopItems();

            if (ModelState.IsValid) {

                _allOrder.OrderCreator(order);

                return Redirect("Complete");
            }
            return View();
        }

        public IActionResult Complete() {

            ViewBag.Message = "Product added successfully !";          

            return View();     
        } 
    }
}
