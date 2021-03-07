using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Car
    {
        // Id конкретного товара
        public int Id { get; set; }

        // URL адрес для доступа картинки товара
        public string Img { get; set; }

        // имя товара
        public string Name { get; set; }

        // цена товара
        public ushort Price { get; set; }
  
        public bool Available { get; set; }

        // категория товара
        public int CategoryId { get; set; }

        // длинное описание
        public string LongDesc { get; set; }

        // избранный товар
        public bool IsFavourite { get; set; }

        // небольшое описание
        public string ShortDesc { get; set; }

        // категория каждого авто Электрическое или на ДВС
        public virtual Category Category { get; set; }

    }
}
