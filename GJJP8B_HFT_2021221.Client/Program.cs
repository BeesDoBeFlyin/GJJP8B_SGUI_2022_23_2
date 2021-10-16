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

            md.Milks.Add(new Milk() { MilkName = "CowMilk", MilkPrice = 500 });
            md.Milks.Add(new Milk() { MilkName = "GoatMilk", MilkPrice = 700 });

            md.SaveChanges();

            Console.WriteLine("Test milks created!");

            CheeseContext cd = new CheeseContext();

            cd.Cheeses.Add(new Cheese() { CheeseName = "Cheddar", CheesePrice = 3500, MilkId = 1});
            cd.Cheeses.Add(new Cheese() { CheeseName = "Trapista", CheesePrice = 1500, MilkId = 0});
            cd.Cheeses.Add(new Cheese() { CheeseName = "Bear", CheesePrice = 680, MilkId = 1});

            cd.SaveChanges();

            Console.WriteLine("Test cheeses created!");

            BuyerContext bd = new BuyerContext();

            bd.Buyers.Add(new Buyer() { BuyerName = "Test Ferenc", CheeseId = 1 });
            bd.Buyers.Add(new Buyer() { BuyerName = "Teás K. Anna", CheeseId = 0 });
            bd.Buyers.Add(new Buyer() { BuyerName = "Generic Guy", CheeseId = 2 });

            Console.WriteLine("Test buyers created!");

            // Reading all the created stuff
            foreach (var item in md.Milks)
            {
                Console.WriteLine($"{item.MilkId} - {item.MilkName}, price {item.MilkPrice}.");
            }

            foreach (var item in cd.Cheeses)
            {
                Console.WriteLine($"{item.CheeseId} - {item.CheeseName}, price {item.CheesePrice} and is made of {item.MilkId}.");
            }

            foreach (var item in bd.Buyers)
            {
                Console.WriteLine($"{item.BuyerId} - {item.BuyerName}, cheese preference {item.BuyerName}.");
            }

            // Purge databases after

            md.Milks.RemoveRange(md.Milks);
            md.SaveChanges();

            Console.WriteLine("Test milks purged!");

            cd.Cheeses.RemoveRange(cd.Cheeses);
            cd.SaveChanges();

            Console.WriteLine("Test cheeses purged!");

            bd.Buyers.RemoveRange(bd.Buyers);
            bd.SaveChanges();

            Console.WriteLine("Test buyers purged!");
        }
    }
}
