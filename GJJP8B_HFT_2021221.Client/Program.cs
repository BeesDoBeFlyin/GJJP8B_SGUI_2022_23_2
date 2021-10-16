using GJJP8B_HFT_2021221.Models;
using System;

//Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="|DataDirectory|\Database1.mdf";Integrated Security=True; MultipleActiveResultSets=True

namespace GJJP8B_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating test cheeses!");

            CheeseContext cd = new CheeseContext();

            cd.Cheeses.Add(new Cheese() { Name = "Cheddar", Price = 3500 });
            cd.Cheeses.Add(new Cheese() { Name = "Trapista", Price = 1500 });
            cd.Cheeses.Add(new Cheese() { Name = "Bear", Price = 680 });

            cd.SaveChanges();

            // Reading all the created stuff
            foreach (var item in cd.Cheeses)
            {
                Console.WriteLine($"{item.CheeseId} - {item.Name}, price: {item.Price}");
            }

            // Purge database after

            cd.Cheeses.RemoveRange(cd.Cheeses);
            cd.SaveChanges();

            Console.WriteLine("Test cheeses purged!");
        }
    }
}
