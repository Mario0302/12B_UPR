using FirmDb.Buisness;
using FirmDb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmDb.Presentation
{
    public class Display
    {
        private int closeOperationId = 6;
        private EmployeeBusiness employeeBusiness = new EmployeeBusiness();


        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update new entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;

                }
            } while (operation != closeOperationId);
        }

        public Display()
        {
            Input();
        }

        private void Add()
        {
            Employee employee = new Employee();
            Console.WriteLine("Entry FirstName: ");
            employee.FirstName = Console.ReadLine();
            Console.WriteLine("Entry LastName: ");
            employee.LastName = Console.ReadLine();
            Console.WriteLine("Entry salary: ");
            employee.Salary = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Town: ");
            employee.Town = Console.ReadLine();
            Console.WriteLine("Entry DepartmentName: ");
            employee.DepartmentName = Console.ReadLine();
            employeeBusiness.Add(employee);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "EMPLOYEES" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var products = employeeBusiness.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", item.Id, item.FirstName, item.LastName, item.Town, item.Salary, item.DepartmentName);
            }
        }

        private void Update()
        {
            Console.WriteLine("Entry ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Employee employee = employeeBusiness.Get(id);
            if (employee != null)
            {
                Console.WriteLine("Entry FirstName: ");
                employee.FirstName = Console.ReadLine();
                Console.WriteLine("Entry LastName: ");
                employee.LastName = Console.ReadLine();
                Console.WriteLine("Entry salary: ");
                employee.Salary = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Entry Town");
                employee.Town = Console.ReadLine();
                Console.WriteLine("Entry DepartmentName");
                employee.DepartmentName = Console.ReadLine();
                employeeBusiness.Update(employee);
            }
            else
            {
                Console.WriteLine("Employee not found!");
            }
        }

        private void Fetch()
        {
            Console.WriteLine("Entry ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Employee employee = employeeBusiness.Get(id);
            if (employee != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + employee.Id);
                Console.WriteLine("FirstName: " + employee.FirstName);
                Console.WriteLine("LastName: " + employee.LastName);
                Console.WriteLine("Salary: " + employee.Salary);
                Console.WriteLine("Town: " + employee.Town);
                Console.WriteLine("DepartmentName: " + employee.DepartmentName);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Delete()
        {
            Console.WriteLine("Entry ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            employeeBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}

