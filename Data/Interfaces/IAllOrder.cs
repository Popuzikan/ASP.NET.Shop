using System;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface IAllOrder {
        void OrderCreator(Order order);
    }
}
