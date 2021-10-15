using FirmDb.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmDb.Data
{
    public class EmployeeContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Integrated Security=true; Database=ProductDb");
        }

        public DbSet<Employee> Products { get; set; }
    }
}
