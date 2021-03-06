using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
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

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category) {

            string _category = category;

            IEnumerable<Car> cars = null;

            string _currCategory = "";

            if (string.IsNullOrEmpty(category)) 
                cars = _allCars.Cars.OrderBy(i => i.Id);      

            else {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase)) {

                    cars = _allCars.Cars.Where(i => i.Category.Name.Equals("Электромобили")).OrderBy(i => i.Id);

                    _currCategory = category;
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase)) {

                    cars = _allCars.Cars.Where(i => i.Category.Name.Equals("Классические автомобили")).OrderBy(i => i.Id);

                    _currCategory = category;
                }
                   
            }

            

            var carObj = new CarsListViewModel {

                AllCars = cars,

                CurrCategory = _currCategory
            };

            ViewBag.Title = "Pages whis Auto";
            return View(carObj);
           
        }   
    }
}
 