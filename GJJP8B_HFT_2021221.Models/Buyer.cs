using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;

namespace GJJP8B_HFT_2021221.Models
{
    public class Buyer
    {
        [Key]
        public int BuyerId { get; set; }
        public String BuyerName { get; set; }
        [ForeignKey(nameof(Cheese))]
        public int CheeseId { get; set; }
    }

    public class BuyerContext : DbContext
    {
        public virtual DbSet<Buyer> Buyers { get; set; }

        public BuyerContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /** still no work
                optionsBuilder
                    .UseLazyLoadingProxies();
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BlogDatabase.mdf; Integrated Security=True; MultipleActiveResultSets=True");
                */
            }
        }
    }
}
