using FirmDb.Data;
using FirmDb.Presentation;
using System;

namespace FirmDb
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeContext db = new EmployeeContext();
            db.Database.EnsureCreated();
            Display display = new Display();
        }
    }
}
