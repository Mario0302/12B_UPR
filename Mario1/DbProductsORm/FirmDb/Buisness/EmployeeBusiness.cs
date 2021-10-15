using FirmDb.Data;
using FirmDb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmDb.Buisness
{
    public class EmployeeBusiness
    {
        private EmployeeContext employeeContext;
        public List<Employee> GetAll()
        {
            using (employeeContext = new EmployeeContext())
            {
                return employeeContext.Products.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (employeeContext = new EmployeeContext())
            {
                return employeeContext.Products.Find(id);
            }
        }

        public void Add(Employee employee)
        {
            using (employeeContext = new EmployeeContext())
            {
                employeeContext.Products.Add(employee);
                employeeContext.SaveChanges();
            }
        }

        public void Update(Employee employee)
        {
            using (employeeContext = new EmployeeContext())
            {
                var item = employeeContext.Products.Find(employee.Id);
                if (item != null)
                {
                    employeeContext.Entry(item).CurrentValues.SetValues(employee);
                    employeeContext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (employeeContext = new EmployeeContext())
            {
                var product = employeeContext.Products.Find(id);
                if (product != null)
                {
                    employeeContext.Products.Remove(product);
                    employeeContext.SaveChanges();
                }
            }
        }

    }
}

