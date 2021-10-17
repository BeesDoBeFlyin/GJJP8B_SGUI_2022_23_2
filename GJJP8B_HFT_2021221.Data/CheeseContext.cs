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

            Cheese c1 = new Cheese { Id = 1, Name = "Cheddar", Price = 1500 };
            Cheese c2 = new Cheese{ Id = 2, Name = "GoatCheese", Price = 3500 };
            Cheese c3 = new Cheese{ Id = 3, Name = "Maci", Price = 850 };

            Buyer b1 = new Buyer { Id = 1, Name = "Test Ferenc", Money = 5500 };
            Buyer b2 = new Buyer { Id = 2, Name = "Teás K. Anna", Money = 9800 };
            Buyer b3 = new Buyer() { Id = 3, Name = "Generic Gery", Money = 6500 };
        }
    }
}

