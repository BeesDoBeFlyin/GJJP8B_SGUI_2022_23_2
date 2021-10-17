using GJJP8B_HFT_2021221.Data;
using GJJP8B_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // INITIALISATION
            CheeseContext cd = new CheeseContext();

            Milk m1 = new Milk() { Name = "CowMilk", Price = 500 };
            Milk m2 = new Milk() { Name = "GoatMilk", Price = 720 };
            Cheese c1 = new Cheese() { Name = "Cheddar", Price = 1500 };
            Cheese c2 = new Cheese() { Name = "GoatCheese", Price = 3500 };
            Cheese c3 = new Cheese() { Name = "Maci", Price = 850 };
            Buyer b1 = new Buyer() { Name = "Test Ferenc" };
            Buyer b2 = new Buyer() { Name = "Teás K. Anna" };
            Buyer b3 = new Buyer() { Name = "Generic Gery" };

            m1.Cheeses.Add(c1);
            m1.Cheeses.Add(c3);
            m2.Cheeses.Add(c2);

            c1.Buyers.Add(b2);
            c2.Buyers.Add(b1);
            c3.Buyers.Add(b3);

            cd.Milks.Add(m1);
            cd.Milks.Add(m2);
            cd.Cheeses.Add(c1);
            cd.Cheeses.Add(c2);
            cd.Cheeses.Add(c3);
            cd.Buyers.Add(b1);
            cd.Buyers.Add(b2);
            cd.Buyers.Add(b3);

            cd.SaveChanges();

            Console.WriteLine("Test data created! Listing them now!");

            foreach (var item in cd.Milks)
            {
                Console.WriteLine($"{item.Id} - {item.Name}");
            }

            foreach (var item in cd.Cheeses)
            {
                Console.WriteLine($"{item.Id} - {item.Name}, price {item.Price}, made from {cd.Milks.Find(item.MilkId).Name}");
            }

            foreach (var item in cd.Buyers)
            {
                Console.WriteLine($"{item.Id} - {item.Name}, prefers {cd.Cheeses.Find(item.CheeseId).Name}");
            }
        }
    }
}
}
