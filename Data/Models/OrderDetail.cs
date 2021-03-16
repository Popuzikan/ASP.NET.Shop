using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int CarId { get; set; }
 
        public long Price { get; set; }

        public virtual Car Auto { get; set; }

        public virtual Order Order { get; set; }
    }
}
