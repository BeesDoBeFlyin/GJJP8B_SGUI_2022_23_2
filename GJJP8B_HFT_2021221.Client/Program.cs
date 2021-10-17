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

            cd.SaveChanges();

            Console.WriteLine("Test data created! Listing them now!");

            // WRINTING OUT TEST DATA

            Console.WriteLine("###### Milks ######");

            foreach (var item in cd.Milks)
            {
                Console.WriteLine($"{item.Id} - {item.Name}, price {item.Price}.");
            }

            Console.WriteLine("#### Cheeses ####");

            foreach (var item in cd.Cheeses)
            {
                Console.WriteLine($"{item.Id} - {item.Name}, price {item.Price}.");
            }

            Console.WriteLine("#### Buyers ####");

            foreach (var item in cd.Buyers)
            {
                Console.WriteLine($"{item.Id} - {item.Name}, with {item.Money} money.");
            }

            Console.WriteLine("Done! Exiting!");
            Console.ReadKey();
        }
    }
}

