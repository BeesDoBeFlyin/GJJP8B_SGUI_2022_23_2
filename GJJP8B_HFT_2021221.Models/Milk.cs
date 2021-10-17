﻿using Microsoft.EntityFrameworkCore;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public virtual ICollection<Cheese> Cheeses { get; set; }
    }

    //public class MilkContext : DbContext
    //{
    //    public virtual DbSet<Milk> Milks { get; set; }

    //    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    //{
            
    //    //    if (!optionsBuilder.IsConfigured)
    //    //    {
    //    //        optionsBuilder
    //    //            .UseLazyLoadingProxies()
    //    //            .UseSqlServer(connectionString);
    //    //    }
    //    //}
    //}
}
