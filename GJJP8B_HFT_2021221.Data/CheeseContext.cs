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

