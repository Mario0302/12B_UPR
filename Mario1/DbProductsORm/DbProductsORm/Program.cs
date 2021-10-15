using DbProductsORM.Data;
using DbProductsORM.Presentation;
using System;

namespace DbProductsORM
{
    class Program
    {

        static void Main(string[] args)
        {
            ProductContext db = new ProductContext();
            db.Database.EnsureCreated();
            Display display = new Display();
        }
    }
}
