using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRep;

        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart) {

            _carRep = carRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index() {

            var items = _shopCart.GetShopItems();

            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id) {

            var item = _carRep.Cars.FirstOrDefault(i => i.Id.Equals(id));

            if (item != null)
                _shopCart.addToCart(item);

            return RedirectToAction("Index");

        }
    }
}
