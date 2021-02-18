using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.Data
{
    public class AddDBContent : DbContext
    {
        public AddDBContent(DbContextOptions<AddDBContent> options):base(options) {

        }

        public DbSet<Car> Car { get; set; }

        public DbSet<Category> Category { get; set; }
    }
}
