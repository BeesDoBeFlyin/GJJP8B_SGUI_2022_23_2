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
        public int CheeseId { get; set; }
        public string CheeseName { get; set; }
        public float CheesePrice { get; set; }
        [ForeignKey(nameof(Milk))]
        public int MilkId { get; set; }
    }

    public class CheeseContext : DbContext
    {
        public virtual DbSet<Cheese> Cheeses { get; set; }

        public CheeseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /** not working >:(
                optionsBuilder
                    .UseLazyLoadingProxies();
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BlogDatabase.mdf; Integrated Security=True; MultipleActiveResultSets=True");
                */
            }
        }


    }
}
