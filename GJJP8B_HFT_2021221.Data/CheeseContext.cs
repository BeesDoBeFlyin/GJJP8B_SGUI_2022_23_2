using GJJP8B_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Data
{
    public class CheeseContext : DbContext
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True";
        public virtual DbSet<Milk> Milks { get; set; }
        public virtual DbSet<Cheese> Cheeses { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }

        public CheeseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cheese>(entity =>
            {
                entity.HasOne(cheese => cheese.Milk)
                    .WithMany(milk => milk.Cheeses)
                    .HasForeignKey(cheese => cheese.MilkId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasOne(buyer => buyer.Cheese)
                .WithMany(cheese => cheese.Buyers)
                .HasForeignKey(buyer => buyer.CheeseId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
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

            cd.SaveChanges();
        }
    }
    //static void Main(string[] args)
    //{
    //    Console.WriteLine("Creating test stuff!");

    //    MilkContext md = new MilkContext();

    //    md.Milks.Add(new Milk() { Name = "CowMilk", Price = 500 });
    //    md.Milks.Add(new Milk() { Name = "GoatMilk", Price = 700 });

    //    md.SaveChanges();

    //    Console.WriteLine("Test milks created!");

    //    Models.CheeseContext cd = new Models.CheeseContext();

    //    cd.Cheeses.Add(new Cheese() { Name = "Cheddar", Price = 3500, MilkId = 1 });
    //    cd.Cheeses.Add(new Cheese() { Name = "Trapista", Price = 1500, MilkId = 0 });
    //    cd.Cheeses.Add(new Cheese() { Name = "Bear", Price = 680, MilkId = 1 });

    //    cd.SaveChanges();

    //    Console.WriteLine("Test cheeses created!");

    //    BuyerContext bd = new BuyerContext();

    //    bd.Buyers.Add(new Buyer() { Name = "Test Ferenc", CheeseId = 1 });
    //    bd.Buyers.Add(new Buyer() { Name = "Teás K. Anna", CheeseId = 0 });
    //    bd.Buyers.Add(new Buyer() { Name = "Generic Guy", CheeseId = 2 });

    //    Console.WriteLine("Test buyers created!");

    //    // Reading all the created stuff
    //    foreach (var item in md.Milks)
    //    {
    //        Console.WriteLine($"{item.Id} - {item.Name}, price {item.Price}.");
    //    }

    //    foreach (var item in cd.Cheeses)
    //    {
    //        Console.WriteLine($"{item.Id} - {item.Name}, price {item.Price} and is made of {item.MilkId}.");
    //    }

    //    foreach (var item in bd.Buyers)
    //    {
    //        Console.WriteLine($"{item.Id} - {item.Name}, cheese preference {item.CheeseId}.");
    //    }

    //    // Purge databases after

    //    md.Milks.RemoveRange(md.Milks);
    //    md.SaveChanges();

    //    Console.WriteLine("Test milks purged!");

    //    cd.Cheeses.RemoveRange(cd.Cheeses);
    //    cd.SaveChanges();

    //    Console.WriteLine("Test cheeses purged!");

    //    bd.Buyers.RemoveRange(bd.Buyers);
    //    bd.SaveChanges();

    //    Console.WriteLine("Test buyers purged!");
    //}
}

