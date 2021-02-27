using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars {
            get {
                return new List<Car> {
                        new Car {
                            Name = "Tesla", ShortDesc = "Model-X",
                            LongDesc = "", Img = "/img/telsa.jpg", Price = 35000, IsFavourite = true,
                            Available = true , Category = _categoryCars.AllCategories.First()
                        },
                        new Car {
                            Name = "Mercedes-Benz", ShortDesc = "S-class",
                            LongDesc = "Buisness cars model", Img = "/img/mercedes.jpg", Price = 35000, IsFavourite = false,
                            Available = false , Category = _categoryCars.AllCategories.Last()
                        },
                };
            }
        }

        public IEnumerable<Car> GetFavCars { get ; set ; }

        public Car GetObjCar(int carId)
        {
            throw new Exception();
        }
    }
}
