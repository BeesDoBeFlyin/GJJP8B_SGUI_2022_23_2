using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Models
{
    [Table("cheeses")]
    public class Cheese
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        [NotMapped]
        public virtual Milk Milk { get; set; }
        [ForeignKey(nameof(Milk))]
        public int MilkId { get; set; }

    }

    //public class CheeseContext : DbContext
    //{
    //    public virtual DbSet<Cheese> Cheeses { get; set; }

    //    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    //{
    //    //    if (!optionsBuilder.IsConfigured)
    //    //    {
    //    //        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CheeseDatabase1.mdf;Integrated Security=True;MultipleActiveResultSets=True";
    //    //        optionsBuilder
    //    //            .UseLazyLoadingProxies()
    //    //            .UseSqlServer(connectionString);
    //    //    }
    //    //}
    //}
}
