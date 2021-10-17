using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Models
{
    public class Milk
    {
        [Key]
        public int MilkId { get; set; }
        public string MilkName { get; set; }
        public float MilkPrice { get; set; }
    }

    public class MilkContext : DbContext
    {
        public virtual DbSet<Milk> Milks { get; set; }

        public MilkContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BlogDatabase.mdf; Integrated Security=True; MultipleActiveResultSets=True";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString);
            }
        }
    }
}
