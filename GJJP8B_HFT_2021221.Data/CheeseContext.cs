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
            //modelBuilder.Entity<Cheese>(entity =>
            //{
            //    entity.HasOne(cheese => cheese.Milk)
            //        .WithMany(milk => milk.Cheeses)
            //        .HasForeignKey(cheese => cheese.MilkId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);
            //});

            //modelBuilder.Entity<Buyer>(entity =>
            //{
            //    entity.HasOne(buyer => buyer.Cheese)
            //    .WithMany(cheese => cheese.Buyers)
            //    .HasForeignKey(buyer => buyer.CheeseId)
            //    .OnDelete(DeleteBehavior.ClientSetNull);
            //});
        }
    }
}

