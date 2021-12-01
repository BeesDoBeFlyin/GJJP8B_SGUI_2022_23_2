using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GJJP8B_HFT_2021221.Models
{
    //[Table("milks")]
    public class Milk
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(35)]
        public string Name { get; set; }
        public float Price { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cheese> Cheeses { get; set; }


    }
}
