using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;

        private readonly ICarsCategory _allCategory;

        public CarsController(IAllCars allCars, ICarsCategory allCarsCategory)
        {
            _allCars = allCars;
            _allCategory = allCarsCategory;
        }

        public ViewResult List() {
            ViewBag.Title = "Pages whis Auto";

            CarsListViewModel obj = new CarsListViewModel() {

                AllCars = _allCars.Cars,

                CurrCategory = "Auto"
            };

            return View(obj);
        }   
    }
}
 