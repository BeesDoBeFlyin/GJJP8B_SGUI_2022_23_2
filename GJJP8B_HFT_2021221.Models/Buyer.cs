using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GJJP8B_HFT_2021221.Models
{
    //[Table("buyers")]
    public class Buyer
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public float Money { get; set; }
        public int CheeseId { get; set; }
        [JsonIgnore]
        public virtual Cheese CheeseVirtual { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}'s treasury: {Money} pieces of money, and their prefferred cheese's id is {CheeseId}.";
        }

    }
}
