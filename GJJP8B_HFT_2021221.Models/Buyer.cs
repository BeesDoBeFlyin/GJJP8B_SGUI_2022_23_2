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
        [NotMapped]
        public virtual Cheese Cheese { get; set; }
        [ForeignKey(nameof(Cheese))]
        public int CheeseId { get; set; }
    }
}
