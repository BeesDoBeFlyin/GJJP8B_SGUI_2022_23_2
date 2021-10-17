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
        public DbSet<Milk> Milks { get; set; }
        public DbSet<Cheese> Cheeses { get; set; }
        public DbSet<Buyer> Buyers { get; set; }

        public CheeseContext(DbContextOptions<CheeseContext> options) : base(options)
        {
           
        }

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
            Milk m1 = new Milk { Id = 1, Name = "CowMilk", Price = 250 };
            Milk m2 = new Milk { Id = 2, Name = "GoatMilk", Price = 550 };
            modelBuilder.Entity<Milk>().HasData(m1, m2);

            Cheese c1 = new Cheese { Id = 1, Name = "Cheddar", Price = 1500, MilkId = 1};
            Cheese c2 = new Cheese{ Id = 2, Name = "GoatCheese", Price = 3500, MilkId = 2};
            Cheese c3 = new Cheese{ Id = 3, Name = "Maci", Price = 850, MilkId = 1};
            modelBuilder.Entity<Cheese>().HasData(c1, c2, c3);

            Buyer b1 = new Buyer { Id = 1, Name = "Test Ferenc", Money = 5500, CheeseId = 1};
            Buyer b2 = new Buyer { Id = 2, Name = "Teás K. Anna", Money = 9800, CheeseId = 1};
            Buyer b3 = new Buyer() { Id = 3, Name = "Generic Gery", Money = 6500, CheeseId = 3};
            modelBuilder.Entity<Buyer>().HasData(b1, b2, b3);
        }
    }
}

