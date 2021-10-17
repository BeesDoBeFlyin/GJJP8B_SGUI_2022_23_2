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
            modelBuilder.Entity<Milk>().HasData(new Milk { Id = 1, Name = "CowMilk", Price = 350 },
            new Milk() { Id = 2, Name = "GoatMilk", Price = 500 }
            );

            modelBuilder.Entity<Cheese>().HasData(new Cheese() { Id = 1, Name = "Cheddar", Price = 1500 },
            new Cheese() { Id = 2, Name = "GoatCheese", Price = 3500 },
            new Cheese() { Id = 3, Name = "Maci", Price = 850 }
            );

            modelBuilder.Entity<Buyer>().HasData(new Buyer() { Id = 1, Name = "Test Ferenc", Money = 5500 },
            new Buyer() { Id = 2, Name = "Teás K. Anna", Money = 9800 },
            new Buyer() { Id = 3, Name = "Generic Gery", Money = 6500 }
            );
        }
    }
}

