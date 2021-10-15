using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbProductsORm.Data;
using DbProductsORm.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DbProductsORm.Data.Models
{
   public class ProductContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Integrated Security=true;Database=ProductDb");
        }
        public DbSet<Product> Products { get; set; }
    }
}
