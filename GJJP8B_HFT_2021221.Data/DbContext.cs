using GJJP8B_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Data
{
    class DbContext
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating test stuff!");

            MilkContext md = new MilkContext();

            md.Milks.Add(new Milk() { Name = "CowMilk", Price = 500 });
            md.Milks.Add(new Milk() { Name = "GoatMilk", Price = 700 });

            md.SaveChanges();

            Console.WriteLine("Test milks created!");

            CheeseContext cd = new CheeseContext();

            cd.Cheeses.Add(new Cheese() { Name = "Cheddar", Price = 3500, MilkId = 1 });
            cd.Cheeses.Add(new Cheese() { Name = "Trapista", Price = 1500, MilkId = 0 });
            cd.Cheeses.Add(new Cheese() { Name = "Bear", Price = 680, MilkId = 1 });

            cd.SaveChanges();

            Console.WriteLine("Test cheeses created!");

            BuyerContext bd = new BuyerContext();

            bd.Buyers.Add(new Buyer() { Name = "Test Ferenc", CheeseId = 1 });
            bd.Buyers.Add(new Buyer() { Name = "Teás K. Anna", CheeseId = 0 });
            bd.Buyers.Add(new Buyer() { Name = "Generic Guy", CheeseId = 2 });

            Console.WriteLine("Test buyers created!");

            // Reading all the created stuff
            foreach (var item in md.Milks)
            {
                Console.WriteLine($"{item.Id} - {item.Name}, price {item.Price}.");
            }

            foreach (var item in cd.Cheeses)
            {
                Console.WriteLine($"{item.Id} - {item.Name}, price {item.Price} and is made of {item.MilkId}.");
            }

            foreach (var item in bd.Buyers)
            {
                Console.WriteLine($"{item.Id} - {item.Name}, cheese preference {item.CheeseId}.");
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

