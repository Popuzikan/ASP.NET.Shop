using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Desc{ get; set; }

        public List<Car> Cars { get; set; }
    }
}
