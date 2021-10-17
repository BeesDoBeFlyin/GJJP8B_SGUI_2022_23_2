using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GJJP8B_HFT_2021221.Models
{
    public class Buyer
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        [ForeignKey(nameof(Cheese))]
        public int CheeseId { get; set; }
    }

    //public class BuyerContext : DbContext
    //{
    //    public virtual DbSet<Buyer> Buyers { get; set; }

    //    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    //{
    //    //    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BuyerDatabase1.mdf;Integrated Security=True;MultipleActiveResultSets=True";
    //    //    if (!optionsBuilder.IsConfigured)
    //    //    {
    //    //        optionsBuilder
    //    //            .UseLazyLoadingProxies()
    //    //            .UseSqlServer(connectionString);
    //    //    }
    //    //}
    //}
}
