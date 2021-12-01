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
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        public int Money { get; set; }
        public int CheeseId { get; set; }
        [JsonIgnore]
        public virtual Cheese Cheese { get; set; }

    }
}
