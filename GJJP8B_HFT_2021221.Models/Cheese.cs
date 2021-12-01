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
    //[Table("Cheese")]
    public class Cheese
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(35)]
        public string Name { get; set; }
        public float Price { get; set; }
        //[ForeignKey(nameof(Milk))]
        public int MilkId { get; set; }
        [JsonIgnore]
        public virtual Milk Milk { get; set; }
        [JsonIgnore]
        public virtual ICollection<Buyer> Buyers { get; set; }
    }
}
