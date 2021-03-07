using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent _addDBContent;

        public CarRepository(AppDBContent addDBContent) {

            _addDBContent = addDBContent;
        }

        public IEnumerable<Car> Cars => _addDBContent.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars => _addDBContent.Car.Where(p => p.IsFavourite).Include(c => c.Category);

        public Car GetObjCar(int carId) => _addDBContent.Car.FirstOrDefault(p => p.Id.Equals(carId));  
    }
}
