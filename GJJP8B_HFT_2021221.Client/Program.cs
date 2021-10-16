using GJJP8B_HFT_2021221.Models;
using System;

//Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="|DataDirectory|\Database1.mdf";Integrated Security=True; MultipleActiveResultSets=True

namespace GJJP8B_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating test stuff!");

            MilkContext md = new MilkContext();

            CheeseContext cd = new CheeseContext();

            cd.Cheeses.Add(new Cheese() { Name = "Cheddar", Price = 3500, MilkId = 1});
            cd.Cheeses.Add(new Cheese() { Name = "Trapista", Price = 1500, MilkId = 0});
            cd.Cheeses.Add(new Cheese() { Name = "Bear", Price = 680, MilkId = 1});

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
