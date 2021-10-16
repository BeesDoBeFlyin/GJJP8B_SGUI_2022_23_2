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

            md.Milks.Add(new Milk() { MilkName = "CowCheese", MilkPrice = 500 });

            CheeseContext cd = new CheeseContext();

            cd.Cheeses.Add(new Cheese() { CheeseName = "Cheddar", CheesePrice = 3500, MilkId = 1});
            cd.Cheeses.Add(new Cheese() { CheeseName = "Trapista", CheesePrice = 1500, MilkId = 0});
            cd.Cheeses.Add(new Cheese() { CheeseName = "Bear", CheesePrice = 680, MilkId = 1});

            cd.SaveChanges();

            // Reading all the created stuff
            foreach (var item in cd.Cheeses)
            {
                Console.WriteLine($"{item.CheeseId} - {item.CheeseName}, price {item.CheesePrice} and is made of {item.MilkId}.");
            }

            // Purge database after

            cd.Cheeses.RemoveRange(cd.Cheeses);
            cd.SaveChanges();

            Console.WriteLine("Test cheeses purged!");
        }
    }
}
