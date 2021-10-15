using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmDb.Data.Models
{
    public class Employee
    {
        //        - Id
        //- FirstName
        //- LastName
        //- Town
        //- Salary
        //- DepartmentName

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Town { get; set; }
        public decimal Salary { get; set; }
        public string DepartmentName { get; set; }
    }
}
