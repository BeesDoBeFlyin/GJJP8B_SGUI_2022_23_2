using GJJP8B_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GJJP8B_HFT_2021221.Data
{
    public class CheeseContext : DbContext
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;MultipleActiveResultSets=True";
        public DbSet<Milk> Milks { get; set; }
        public DbSet<Cheese> Cheeses { get; set; }
        public DbSet<Buyer> Buyers { get; set; }

        
        public CheeseContext()
        {
            //for some reason sometimes
           this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && optionsBuilder != null)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Cheese>()
            //    .HasOne<Milk>(c => c.Milk)
            //    .WithMany(m => m.Cheeses)
            //    .HasForeignKey(c => c.MilkId)
            //    .OnDelete(DeleteBehavior.ClientSetNull);
            //modelBuilder.Entity<Buyer>()
            //    .HasOne<Cheese>(b => b.Cheese)
            //    .WithMany(c => c.Buyers)
            //    .HasForeignKey(b => b.CheeseId)
            //    .OnDelete(DeleteBehavior.ClientSetNull);

            Milk m1 = new() { Id = 1, Name = "CowMilk", Price = 250, CheesesNonDb = new List<Cheese>() };
            Milk m2 = new() { Id = 2, Name = "GoatMilk", Price = 550, CheesesNonDb = new List<Cheese>() };

            Cheese c1 = new() { Id = 1, Name = "Cheddar", Price = 1500, MilkId = 1, BuyersNonDb = new List<Buyer>() };
            Cheese c2 = new() { Id = 2, Name = "GoatCheese", Price = 3500, MilkId = 2, BuyersNonDb = new List<Buyer>() };
            Cheese c3 = new() { Id = 3, Name = "Maci", Price = 850, MilkId = 1, BuyersNonDb = new List<Buyer>() };

            Buyer b1 = new() { Id = 1, Name = "Test Ferenc", Money = 1200, CheeseId = 1 };
            Buyer b2 = new() { Id = 2, Name = "Teás K. Anna", Money = 9800, CheeseId = 2 };
            Buyer b3 = new() { Id = 3, Name = "Sigh Kyle", Money = 6500, CheeseId = 3 };


            modelBuilder.Entity<Milk>().HasData(m1, m2);
            modelBuilder.Entity<Cheese>().HasData(c1, c2, c3);
            modelBuilder.Entity<Buyer>().HasData(b1, b2, b3);
        }
    }
}

