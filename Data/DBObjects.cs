using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects {
       
        public static void Initial(AppDBContent content) {
            
               
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(                   
                    new Car {
                        Name = "Tesla",
                         ShortDesc = "Model-X",
                          LongDesc = "Parspective Car",
                           Img = "/img/telsa.jpg",
                            Price = 30000,
                             IsFavourite = true,
                              Available = true,
                               Category = Categories["Электромобили"] 
                    },
                    new Car {
                            Name = "Mercedes-Benz w222",
                             ShortDesc = "S-class",
                              LongDesc = "Buisness cars model",
                               Img = "/img/mercedes.jpg",
                                Price = 30000,
                                 IsFavourite = false,
                                  Available = false,
                                   Category = Categories["Классические автомобили"]
                    }); 
            }

            content.SaveChanges();
        }

        private static IDictionary<string, Category> _categories;
  
        public static IDictionary<string, Category> Categories {

            get {
                if (_categories == null) {
                    var list = new Category[] {

                        new Category {Name = "Электромобили", Desc = "Современный вид транспорта" },
                        new Category {Name = "Классические автомобили", Desc = "Машины с ДВС" }
                    };

                    _categories = new Dictionary<string, Category>();

                    foreach (Category item in list)
                            _categories.Add(item.Name, item);
                }
                return _categories;
            }
        }
    }
}
