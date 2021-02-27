using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace Shop.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent _addDBContent;

        public CategoryRepository(AppDBContent addDBContent) {

            _addDBContent = addDBContent;
        }

        public IEnumerable<Category> AllCategories => _addDBContent.Category;
    }
}
